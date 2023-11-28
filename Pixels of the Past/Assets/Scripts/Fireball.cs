using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;

    float damageAmount = 10f;
    bool hasHitEnemy = false;

    // Audio
    [SerializeField] AudioClip fireballCastSFX;

    void Start()
    {
        AudioSource.PlayClipAtPoint(fireballCastSFX, Camera.main.transform.position);

        myRigidbody = GetComponent<Rigidbody2D>();
        // Lets you shoot left when facing left
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        gameObject.transform.localScale = new Vector3(player.transform.localScale.x * .75f,.75f,1f);
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    // For Bullet Collisions On Enemies
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Crab" && !hasHitEnemy)
        {
            hasHitEnemy = true;
            // Comment below is bad because it accesses all crabs' health values
            //FindObjectOfType<CrabStats>().DamageCrab(damageAmount);
            other.GetComponent<CrabStats>().DamageCrab(damageAmount);
        }
        else if(other.tag == "Octopus" && !hasHitEnemy)
        {
            hasHitEnemy = true;
            other.GetComponent<OctopusStats>().DamageOctopus(damageAmount);
        }
        else if(other.tag == "Slug" && !hasHitEnemy)
        {
            hasHitEnemy = true;
            other.GetComponent<SlugStats>().DamageSlug(damageAmount);
        }
        else if(other.tag == "Boss" && !hasHitEnemy)
        {
            hasHitEnemy = true;
            other.GetComponent<BossStats>().DamageBoss(damageAmount);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
