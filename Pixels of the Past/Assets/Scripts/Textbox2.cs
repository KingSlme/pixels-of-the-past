using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Textbox2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;
    // private int currentTextboxIndex = 0;
    // string[] texts = {""};
    // bool hasMoreText = true;
    // bool hasRecentlyPressedEnter = false;
    public bool hasFinished = false;

    // Audio
    // [SerializeField] AudioClip textDingSFX;

    void Start()
    {
        // textBoxText.text = texts[currentTextboxIndex];
        // currentTextboxIndex = 1;
        StartCoroutine(LoadNextScene());
    }

    /*void OnEnter()
    {
        if(!hasRecentlyPressedEnter)
        {
            StartCoroutine(EnterDelay());
            // Audio
            AudioSource.PlayClipAtPoint(textDingSFX, Camera.main.transform.position);

            if(hasMoreText)
            {
                GetNextText();
            }
            else
            {
                StartCoroutine(LoadNextScene());
            }
        }
    }

    IEnumerator EnterDelay()
    {
        hasRecentlyPressedEnter = true;
        yield return new WaitForSecondsRealtime(1f);
        hasRecentlyPressedEnter = false;
    }

    void GetNextText()
    {   if(currentTextboxIndex < texts.Length)
        {
            textBoxText.text = texts[currentTextboxIndex];
            currentTextboxIndex++;
        }
        if(currentTextboxIndex > texts.Length -1)
        {
            hasMoreText = false;
        }
    }*/

    IEnumerator LoadNextScene()
    {
        // Gets index of current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        hasFinished = true;
        // textBoxText.text = "";
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(nextSceneIndex);
    }
}
