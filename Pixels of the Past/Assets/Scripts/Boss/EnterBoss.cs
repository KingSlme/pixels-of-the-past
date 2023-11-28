using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoss : MonoBehaviour
{

    [SerializeField]  GameObject music;
    [SerializeField] GameObject bossMusic;

    PlayerHealth playerHealthRef;

    void Start()
    {
        playerHealthRef = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Transform playerTransform = other.GetComponentInChildren<Transform>();
            playerTransform.transform.position = new Vector3(-10.32f, -14.1f, 0f);
            playerHealthRef.playerHealth = 100;
        }

        // Music Switch
        music.SetActive(false);
        bossMusic.SetActive(true);
    }
}
