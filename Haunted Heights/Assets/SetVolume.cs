using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public float volLvl;
    public gameManager data;
    private void Awake() 
    {
        volLvl = data.gameData.volume;
        mixer.SetFloat("MusicVol", MathF.Log10(volLvl)* 20);
    }
    public void SetLevel (float sliderValue)
    {
        volLvl=sliderValue;
        mixer.SetFloat ("MusicVol", Mathf.Log10 (volLvl) * 20);
        data.gameData.volume = volLvl;
        SaveSystem.Save(data.gameData);
    }
}
