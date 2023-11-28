using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    [SerializeField] float bossMaxHealth = 300f;
    float bossHealth;
    [SerializeField] float bossDamage = 20f;

    CapsuleCollider2D bossCollider;
    Animator bossAnimator;
    public bool hasDied = false;

    [SerializeField] GameObject lastRef;

    [SerializeField] Slider bossHealthBar;

    void Start()
    {
        bossCollider = GetComponent<CapsuleCollider2D>();
        bossHealth = bossMaxHealth;
        bossAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        bossHealthBar.value = bossHealth;
        AttackPlayer();
        if(bossHealth <= 0)
        {
            StartCoroutine(BossDeath());
        }
    }

    void AttackPlayer()
    {
        if(bossCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !hasDied)
        {
            FindObjectOfType<PlayerHealth>().damagePlayer(bossDamage);
        }
    }

    public void DamageBoss(float damageAmount)
    {
        bossHealth -= damageAmount;
    }

    IEnumerator BossDeath()
    {
        if(!hasDied)
        {
            hasDied = true;
            bossAnimator.SetTrigger("isDead");
            // Turns off capsule collider in this line (pushes when dead if you don't)
            bossCollider.isTrigger = true;
            lastRef.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
            Destroy(gameObject);
        }
    }
}
