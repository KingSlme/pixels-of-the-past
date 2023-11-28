using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugStats : MonoBehaviour
{
    [SerializeField] float slugMaxHealth = 30f;
    float slugHealth;
    [SerializeField] float slugDamage = 34f;

    CapsuleCollider2D slugCollider;
    Animator slugAnimator;
    bool hasDied = false;

    void Start()
    {
        slugCollider = GetComponent<CapsuleCollider2D>();
        slugHealth = slugMaxHealth;
        slugAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackPlayer();
        if(slugHealth <= 0)
        {
            StartCoroutine(SlugDeath());
        }
    }

    void AttackPlayer()
    {
        if(slugCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !hasDied)
        {
            FindObjectOfType<PlayerHealth>().damagePlayer(slugDamage);
        }
    }

    public void DamageSlug(float damageAmount)
    {
        slugHealth -= damageAmount;
    }

    IEnumerator SlugDeath()
    {
        if(!hasDied)
        {
            hasDied = true;
            slugAnimator.SetTrigger("isDead");
            // Turns off capsule collider in this line (pushes when dead if you don't)
            slugCollider.isTrigger = true;
            yield return new WaitForSecondsRealtime(2f);
            Destroy(gameObject);
        }

    }
}
