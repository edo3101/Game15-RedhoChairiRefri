using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button mulai;
    public AudioSource music;
    [SerializeField] Player player;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject grass;
    [SerializeField] GameObject road;
    [SerializeField] int extent = 7;
    [SerializeField] int frontDistance = 10;
    [SerializeField] int backDistance = -5;
    [SerializeField] int maxSameTerrainRepeat = 3;

    Dictionary<int, TerrainBlock> map = new Dictionary<int, TerrainBlock>(50);
    TMP_Text gameOverText;

    private void Start() 
    {
        music.Play();
        gameOverPanel.SetActive(false);
        gameOverText = gameOverPanel.GetComponentInChildren<TMP_Text>();

        for(int z = backDistance; z <=0; z++)
        {
            CreateTerrain(grass, z);
        }
        for(int z = 1; z <= frontDistance; z++)
        {
            var prefab = GetNextRandomTerrainPrefab(z);

            CreateTerrain(prefab, z);
        }

        player.SetUp(backDistance, extent);
    }

    private int palyerLastMaxTravel;
    private void Update()
    {

        if(player.IsDie && gameOverPanel.activeInHierarchy==false)
            StartCoroutine(ShowGameOverPanel());

        if(player.MaxTravel==palyerLastMaxTravel)
            return;

        palyerLastMaxTravel = player.MaxTravel;

        //infinity map
        var randTbPrefab = GetNextRandomTerrainPrefab(player.MaxTravel+frontDistance);
        CreateTerrain(randTbPrefab,player.MaxTravel+frontDistance);

        //delete map belakang
        var lastTB = map[player.MaxTravel-1+backDistance];
        map.Remove(player.MaxTravel-1+backDistance);
        Destroy(lastTB.gameObject);

        player.SetUp(player.MaxTravel+backDistance,extent);
        
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);

        Debug.Log("GameOver");
        gameOverText.text = "Your Score : " + player.MaxTravel;
        gameOverPanel.SetActive(true);
    }

    private void CreateTerrain(GameObject prefab, int zPos)
    {
        var go = Instantiate(prefab,new Vector3(0,0,zPos),Quaternion.identity);
        var tb = go.GetComponent<TerrainBlock>();
        tb.Build(extent);

        map.Add(zPos,tb);
    }

    private GameObject GetNextRandomTerrainPrefab(int nextPos)
    {
        bool isUniform = true;
        var tbRef = map[nextPos - 1];
        for(int distance = 2; distance <= maxSameTerrainRepeat; distance++)
        {
            if(map[nextPos - distance].GetType() != tbRef.GetType())
            {
                isUniform = false;
                break;
            }
        }

        if(isUniform)
        {
            if(tbRef is Grass)
                return road;
            else
                return grass;
        }
        return Random.value > 0.5f ? road : grass;
    }
}
