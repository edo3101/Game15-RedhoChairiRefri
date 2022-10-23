using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public Slider SFX;
    public Slider BGM;
    public AudioMixer mixer;
    // public AudioMixerGroup BGM;

    private void Start()
    {
        float db;

        if(mixer.GetFloat("SFX_VOL", out db))
            SFX.value = (db + 80) / 80;

        if(mixer.GetFloat("BGM_VOL", out db))
            BGM.value = (db + 80) / 80;
    }
    public void SFXVolume(float value)
    {
        value = value*80 - 80;

        mixer.SetFloat("SFX_VOL", value);
    }

    public void BGMVolume(float value)
    {
        value = value*80 - 80;

        mixer.SetFloat("BGM_VOL", value);
    }
}

