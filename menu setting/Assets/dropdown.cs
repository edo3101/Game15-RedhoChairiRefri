using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropdown : MonoBehaviour
{
    public void window(int value)
    {
        if(value == 0)
        {
            Debug.Log("Layar Fullscren");
        }
        else
        {
            Debug.Log("Layar Windowed");
        }
    }

    public void res(int value)
    {
        if(value == 0)
        {
            Debug.Log("Resolusi QHD");
        }
        else if(value == 1)
        {
            Debug.Log("Resolusi FHD");
        }
        else
        {
            Debug.Log("Resolusi HD");
        }
    }
}
