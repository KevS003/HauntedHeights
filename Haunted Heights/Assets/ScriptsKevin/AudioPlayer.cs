using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public SetVolume volRef;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volRef.volLvl;
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
