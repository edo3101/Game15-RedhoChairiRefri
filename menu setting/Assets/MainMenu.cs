using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Game START");
    }

    public void Exit()
    {
        Debug.Log("Game EXIT");
        Application.Quit();
    }
}
