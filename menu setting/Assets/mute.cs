using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour
{
    public void Print(bool value)
    {
        if(value)
        {
            Debug.Log("Suara di Mute");
        }
        else
        {
            Debug.Log("Suara Tidak di Mute");
        }
    }

     public void Print1(bool value)
    {
        if(value)
        {
            Debug.Log("Subtitle Nyala");
        }
        else
        {
            Debug.Log("Subtitle Mati");
        }
    }
}
