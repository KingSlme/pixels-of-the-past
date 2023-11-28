using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : MonoBehaviour
{
    // This helper script is designed to fix Cross Type Inputs
    [SerializeField] Textbox textBox; 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            
        }
    }
}
