using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip mazeTrack;

    private AudioManager musicController;

    void Start()
    {
        musicController = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (mazeTrack != null)
            {
                musicController.ChangeBGM(mazeTrack);
            }
        }
    }
}
