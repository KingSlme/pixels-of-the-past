using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAgroSystem : MonoBehaviour
{
    BossFollow bossFollow;

    CircleCollider2D bossCircleCollider2D;

    void Start()
    {
        bossCircleCollider2D = GetComponent<CircleCollider2D>();
        bossFollow = FindObjectOfType<BossFollow>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Begin Agro
        if(bossCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            bossFollow.bossCanMove = true;
            // Enables Walking Animation
            bossFollow.bossAnimator.SetBool("isWalking", true);
        }
    }
}
