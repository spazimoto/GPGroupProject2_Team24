using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Image black;
    public Animator anim;

    void Update()
    {
        float selectVert = Input.GetAxis("Vertical");
        float selectHorz = Input.GetAxis("Vertical");
    }

    public void PlayGame()
    {
        StartCoroutine(Fading());
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls Screen");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

        IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("maingame");
    }
}
