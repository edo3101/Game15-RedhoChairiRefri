using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField]GameObject eagelPrefab;
    [SerializeField]int spawnZpos = 7;
    [SerializeField]Player player;
    [SerializeField]float timeOut = 5;
    public AudioSource keadilan;
    float timer = 0;
    int palyerLastMaxTravel = 0 ;

     private void SpawnEagle()
    {
        player.enabled = false;
        var position = new Vector3(player.transform.position.x,1,player.CurrentTravel + spawnZpos);
        var rotation = Quaternion.Euler(0,180,0);
        var eagleObject = Instantiate(eagelPrefab, position, rotation);
        var eagle = eagleObject.GetComponent<Eagle>();
        eagle.SetUpTarget(player);
        keadilan.Play();
    }

    private void Update()
    {
        if(player.MaxTravel!=palyerLastMaxTravel)
        {
            timer=0;
            palyerLastMaxTravel=player.MaxTravel;
            return;
        }

        if(timer < timeOut)
        {
            timer += Time.deltaTime;
            return;
        }

        if(player.IsJumping()==false && player.IsDie == false)
            SpawnEagle();
    }
}
