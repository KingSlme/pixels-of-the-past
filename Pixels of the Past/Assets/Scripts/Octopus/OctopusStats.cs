using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStats : MonoBehaviour
{
    [SerializeField] float octopusMaxHealth = 100f;
    float octopusHealth;
    [SerializeField] float octopusDamage = 34f;

    CapsuleCollider2D octopusCollider;
    Animator octopusAnimator;
    bool hasDied = false;

    void Start()
    {
        octopusCollider = GetComponent<CapsuleCollider2D>();
        octopusHealth = octopusMaxHealth;
        octopusAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackPlayer();
        if(octopusHealth <= 0)
        {
            StartCoroutine(OctopusDeath());
        }
    }

    void AttackPlayer()
    {
        if(octopusCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !hasDied)
        {
            FindObjectOfType<PlayerHealth>().damagePlayer(octopusDamage);
        }
    }

    public void DamageOctopus(float damageAmount)
    {
        octopusHealth -= damageAmount;
    }

    IEnumerator OctopusDeath()
    {
        if(!hasDied)
        {
            hasDied = true;
            octopusAnimator.SetTrigger("isDead");
            // Turns off capsule collider in this line (pushes when dead if you don't)
            octopusCollider.isTrigger = true;
            yield return new WaitForSecondsRealtime(2f);
            Destroy(gameObject);
        }
    }
}
