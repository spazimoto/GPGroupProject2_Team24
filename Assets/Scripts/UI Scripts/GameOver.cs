using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    void Update()
    {
        float selectVert = Input.GetAxis("Vertical");
        float selectHorz = Input.GetAxis("Vertical");
    }
    public void Restart()
    {
        SceneManager.LoadScene("startmenu");
    }
}
