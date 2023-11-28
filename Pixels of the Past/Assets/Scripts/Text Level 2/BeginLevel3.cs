using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginLevel3 : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
