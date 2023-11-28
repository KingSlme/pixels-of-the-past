using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAnimation : MonoBehaviour
{
    GameObject pictureFrame;
    Animator animator;
    Textbox textbox;
    bool hasDoneAnimation = false;

    void Start()
    {
        pictureFrame = GameObject.Find("Picture Frame");
        animator = pictureFrame.GetComponent<Animator>();
        textbox = FindObjectOfType<Textbox>();
    }

    void Update()
    {
        doAnimation();
    }

    void doAnimation()
    {
        if(textbox.hasFinished && !hasDoneAnimation)
        {
            hasDoneAnimation = true;
            animator.SetTrigger("hasEnded");
        }
    }
}
