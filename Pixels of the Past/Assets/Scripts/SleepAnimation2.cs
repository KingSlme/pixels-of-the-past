using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAnimation2 : MonoBehaviour
{
    GameObject pictureFrame;
    Animator animator;
    Textbox2 textbox2;
    bool hasDoneAnimation = false;

    void Start()
    {
        pictureFrame = GameObject.Find("Picture Frame");
        animator = pictureFrame.GetComponent<Animator>();
        textbox2 = FindObjectOfType<Textbox2>();
    }

    void Update()
    {
        doAnimation();
    }

    void doAnimation()
    {
        if(textbox2.hasFinished && !hasDoneAnimation)
        {
            hasDoneAnimation = true;
            animator.SetTrigger("hasEnded");
        }
    }
}
