﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{

    private Animator doorAnim;
    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            doorAnim.Play("Open", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("Close", 0, 0.0f);
            doorOpen = false;
        }
    }
}
