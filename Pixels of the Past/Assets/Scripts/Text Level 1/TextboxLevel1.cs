using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextboxLevel1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;

    // For Avatars
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite nonpixelatedRobin;
    [SerializeField] Sprite pixelatedRobin;
    Sprite[] avatars;

    private int currentTextboxIndex = 0;
    string[] texts = {"[Robin]: Who are you?\n(Press Enter to Continue)",
    "[???]: Oh wow, yeah, that's pretty disappointing. Little rough around the edges, smells of take-out too.\n(Press Enter to Continue)",
    "[Robin]: Hey, what are you?\n(Press Enter to Continue)",
    "[???]: \"What\" isn't how you talk to who you wish you were.\n(Press Enter to Continue)",
    "[Robin]: What are you talking about?\n(Press Enter to Continue)",
    "[???]: \"What\", \"about\", there's always something unknown, but those unknowns make even more things a mystery, like a virus, it spreads.\n(Press Enter to Continue)",
    "[Robin]: Stop spewing nonsense, this isn't my choice, this isn't how I wanted it.\n(Press Enter to Continue)"
    };
    bool hasMoreText = true;
    bool hasRecentlyPressedEnter = false;

    // Audio
    [SerializeField] AudioClip textDingSFX;

    void Awake()
    {
        // For Avatars
        avatars = new Sprite[] {nonpixelatedRobin, pixelatedRobin,
        nonpixelatedRobin, pixelatedRobin,
        nonpixelatedRobin, pixelatedRobin,
        nonpixelatedRobin};
        ChangeAvatarImage(avatars[currentTextboxIndex]);

        textBoxText.text = texts[currentTextboxIndex];
        currentTextboxIndex = 1;
    }

    /*()
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
                LoadNextScene();
            }

            // For Avatars
            avatars = new Sprite[] {nonpixelatedRobin, pixelatedRobin,
            nonpixelatedRobin, pixelatedRobin,
            nonpixelatedRobin, pixelatedRobin,
            nonpixelatedRobin};
            ChangeAvatarImage(avatars[currentTextboxIndex-1]);
        }
    }*/

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
                    LoadNextScene();
                }

                // For Avatars
                avatars = new Sprite[] {nonpixelatedRobin, pixelatedRobin,
                nonpixelatedRobin, pixelatedRobin,
                nonpixelatedRobin, pixelatedRobin,
                nonpixelatedRobin};
                ChangeAvatarImage(avatars[currentTextboxIndex-1]);
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

    // For Avatars
    void ChangeAvatarImage(Sprite avatarImageSprite)
    {
        avatarImage.sprite = avatarImageSprite;
    }

    void LoadNextScene()
    {
        // Gets index of current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
