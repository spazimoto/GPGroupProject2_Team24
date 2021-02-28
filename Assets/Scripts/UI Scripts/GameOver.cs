using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float selectVert = Input.GetAxis("Vertical");
        float selectHorz = Input.GetAxis("Vertical");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
