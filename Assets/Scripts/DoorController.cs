using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public GameObject interact;

    public Text interactText;

    public Text locationText;

    public Image black;
    public Animator anim;

    void Start()
    {
        interact.SetActive(false);
        interactText.text = "";    //possibly put in void update-- checks to see what input the player is using, changes interactText based on last known interaction either with mouse or keyboard
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TakeMacGuffin")
        {
            StartCoroutine(Fading());
        }
    }
    void OnTriggerStay(Collider collider)
    {
        /*if(collider.tag == "Door")
        {
            interactText.text = "Press Space or the A button to open!";
            interact.SetActive(true);
            Animator doorAnim = collider.GetComponentInChildren<Animator>();
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Interact"))
            {
                doorAnim.SetTrigger("OpenClose");
            }
        }*/

        if(collider.tag == "MacGuffin")
        {
            interactText.text= "Leave?";
            interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Interact"))
            {
                StartCoroutine(Fading());
            }        
        }

        if(collider.tag == "Tree")
        {
            interactText.text = "Why would you want to leave my garden? Hmm? It has everything a mouse could ever need, soft grass, fresh grain, and a big beautiful sky... Please reconsider this, small one.";
            interact.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        interact.SetActive(false);
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Win Screen");
    }

}
