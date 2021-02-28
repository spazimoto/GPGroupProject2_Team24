using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void GoBack()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
