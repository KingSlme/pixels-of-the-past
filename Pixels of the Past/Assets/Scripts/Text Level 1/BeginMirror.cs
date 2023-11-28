using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginMirror : MonoBehaviour
{
    // Canvas textCanvas;
    [SerializeField] Canvas textCanvas;
    PlayerMovement playerMovement;
    
    void Start()
    {
        // textCanvas = FindObjectOfType<Canvas>();
        textCanvas.gameObject.SetActive(false);

        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            textCanvas.gameObject.SetActive(true);
            playerMovement.canDoAnything = false;
            playerMovement.myAnimator.SetBool("isRunning", false);
            playerMovement.myRigidBody2D.velocity = new Vector2(0f, 0f);
        }
    }
}
