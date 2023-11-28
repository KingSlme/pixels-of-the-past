using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxPlayerHealth = 100;
    public float playerHealth;
    bool canBeAttacked = true;

    [SerializeField] Slider healthBar;

    // Use OnAwake() ?
    void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    void Update() 
    {
        healthBar.value = playerHealth;
        
    }
    
    public void damagePlayer(float damageAmount)
    {
        if(canBeAttacked)
        {
            // Coroutine in conditonal prevents stacking the method and stacking damage
            StartCoroutine(delayAttacks());
            playerHealth -= damageAmount;
        }
        // Adds delay between possible damage instances 
        
    }

    public IEnumerator delayAttacks()
    {
        canBeAttacked = false;
        yield return new WaitForSecondsRealtime(1);
        canBeAttacked = true;
    }
}
