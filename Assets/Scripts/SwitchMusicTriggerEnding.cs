using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTriggerEnding : MonoBehaviour
{
    public AudioClip endTrack;

    private AudioManager musicController;

    void Start()
    {
        musicController = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (endTrack != null)
            {
                musicController.ChangeBGM(endTrack);
            }
        }
    }
}
