using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAgroSystem : MonoBehaviour
{
    //bool canMove = false;
    CircleCollider2D crabCircleCollider2D;
    //Animator crabAnimator;

    CrabMovement crabMovement;

    void Start()
    {
        crabCircleCollider2D = GetComponent<CircleCollider2D>();
        crabMovement = FindObjectOfType<CrabMovement>();
    }

    void Update()
    {
        // De-Agro
        if(!crabCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            crabMovement.crabCanMove = false;
            crabMovement.CrabRigidbody.velocity = new Vector2(0f, 0f);
            // Enables Idling Animation
            crabMovement.crabAnimator.SetBool("isWalking", false);
        }
        crabMovement.EnableCrabMoving();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Agro
        if(crabCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            crabMovement.crabCanMove = true;
            // Enable Walking Animation
            crabMovement.crabAnimator.SetBool("isWalking", true);
        }
    }
}
