using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D myRigidbody;

    // For Agro Movement
    bool canMove = false;
    CircleCollider2D octopusCircleCollider2D;
    // Animator octopusAnimator;

    // For Multisize
    [SerializeField] float xScale = 1f;
    [SerializeField] float yScale = 1f;

    void Start()
    {
        // Sets octopus scale
        transform.localScale = new Vector2(xScale, yScale);

        myRigidbody = GetComponent<Rigidbody2D>();
        octopusCircleCollider2D = GetComponent<CircleCollider2D>();
        // octopusAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // De-Agro
        if(!octopusCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            canMove = false;
            myRigidbody.velocity = new Vector2(0f, 0f);
            // Enables Idling Animation
            // octopusAnimator.SetBool("isWalking", false);
        }
        EnableMoving();
    }

    void EnableMoving()
    {
        if(canMove)
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
        // Agro
        if(octopusCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            canMove = true;
            // Enable Walking Animation
            // octopusAnimator.SetBool("isWalking", true);
        }
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x) * yScale, 1f * xScale);
    }
}
