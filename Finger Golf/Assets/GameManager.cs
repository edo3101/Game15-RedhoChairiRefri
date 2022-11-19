using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] PlayerControlleer player;
    [SerializeField] Hole hole;
    // Start is called before the first frame update
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if(hole.Entered && gameOverPanel.activeInHierarchy == false)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Finished!!! Shoot Count: " + player.ShootCount;
        }
    }

    public void BackToMainMenu()
    {
        SceneLoader.Load("MainMenu");
    }

    public void Replay()
    {
        SceneLoader.ReloadLevel();
    }

    public void PlayNext()
    {
        SceneLoader.LoadNextLevel();
    }
}
