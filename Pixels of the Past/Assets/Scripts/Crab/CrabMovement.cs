using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    public Rigidbody2D CrabRigidbody;

    
    // For Agro Movement
    public bool crabCanMove = false;
    CircleCollider2D crabCircleCollider2D;
    public Animator crabAnimator;

    // For Multisize
    [SerializeField] float xScale = 1f;
    [SerializeField] float yScale = 1f;

    void Start()
    {
        // Sets crab scale
        transform.localScale = new Vector2(xScale, yScale);

        CrabRigidbody = GetComponent<Rigidbody2D>();
        crabCircleCollider2D = GetComponent<CircleCollider2D>();
        crabAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // De-Agro
        if(!crabCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            crabCanMove = false;
            CrabRigidbody.velocity = new Vector2(0f, 0f);
            // Enables Idling Animation
            crabAnimator.SetBool("isWalking", false);
        }
        EnableCrabMoving();
    }

    public void EnableCrabMoving()
    {
        if(crabCanMove)
        {
            CrabRigidbody.velocity = new Vector2(moveSpeed, 0f);
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
        if(crabCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            crabCanMove = true;
            // Enable Walking Animation
            crabAnimator.SetBool("isWalking", true);
        }
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(CrabRigidbody.velocity.x) * yScale, 1f * xScale);
    }
}
