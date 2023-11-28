using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStats : MonoBehaviour
{
    [SerializeField] float crabMaxHealth = 30f;
    float crabHealth;
    [SerializeField] float crabDamage = 34f;

    CapsuleCollider2D slugCollider;
    Animator crabAnimator;
    bool hasDied = false;

    void Start()
    {
        slugCollider = GetComponent<CapsuleCollider2D>();
        crabHealth = crabMaxHealth;
        crabAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackPlayer();
        if(crabHealth <= 0)
        {
            StartCoroutine(CrabDeath());
        }
    }

    void AttackPlayer()
    {
        if(slugCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !hasDied)
        {
            FindObjectOfType<PlayerHealth>().damagePlayer(crabDamage);
        }
    }

    public void DamageCrab(float damageAmount)
    {
        crabHealth -= damageAmount;
    }

    IEnumerator CrabDeath()
    {
        if(!hasDied)
        {
            hasDied = true;
            crabAnimator.SetTrigger("isDead");
            // Turns off capsule collider in this line (pushes when dead if you don't)
            slugCollider.isTrigger = true;
            yield return new WaitForSecondsRealtime(2f);
            Destroy(gameObject);
        }

    }
}
