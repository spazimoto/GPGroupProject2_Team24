using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePaused = false; //can pitch down sounds using this bool
    public GameObject pauseMenu;

    public Image black;
    public Animator anim;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            if (gamePaused == true)
            {
                Resume();
            }   
            else 
            {
                Pause();
            }
        }
    }

    void Pause ()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(Fading());
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("startscreen");
    }
}
