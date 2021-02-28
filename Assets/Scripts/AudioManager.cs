using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm;

    void Start()
    {

    }

    public void ChangeBGM(AudioClip music)
    {
        bgm.Stop();
        bgm.clip = music;
        bgm.Play();
    }
}
