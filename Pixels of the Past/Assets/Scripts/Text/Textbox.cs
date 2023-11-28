using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Textbox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;
    private int currentTextboxIndex = 0;
    string[] texts = {"2014, October 26th. A group of friends, Jae, Robin, and Chloe…\n(Press Enter to Continue)",
    "This photo was taken during preparation for their yearly Halloween party…\n(Press Enter to Continue)",
    "What were they like again? I guess there were costumes, maybe food. Did we even go Trick-or-Treating?\n(Press Enter to Continue)",
    "Seems like it's been a while without the noise of Jae's flashing camera as he would take pictures of what Chloe was doing…\n(Press Enter to Continue)", 
    "Or Chloe clicking away at her phone trying to upload the pictures.\n(Press Enter to Continue)",
    "How many years has it been since I had to move away from town…\n(Press Enter to Continue)",
    "It couldn't be that long, surely…\n(Press Enter to Continue)"
    };
    bool hasMoreText = true;
    bool hasRecentlyPressedEnter = false;
    public bool hasFinished = false;

    // Audio
    [SerializeField] AudioClip textDingSFX;

    void Start()
    {
        textBoxText.text = texts[currentTextboxIndex];
        currentTextboxIndex = 1;
    }

    /*
    void OnEnter()
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
    */

    // Temp Enter Fix using Old Input:
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
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
    }

    IEnumerator LoadNextScene()
    {
        // Gets index of current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        hasFinished = true;
        textBoxText.text = "It's 2022...";
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(nextSceneIndex);
    }
}
