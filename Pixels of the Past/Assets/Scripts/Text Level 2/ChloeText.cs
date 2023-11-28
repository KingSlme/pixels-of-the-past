using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChloeText: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;

    // For Avatars
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite robin;
    [SerializeField] Sprite chloe;
    Sprite[] avatars;

    private int currentTextboxIndex = 0;
    string[] texts = {"[Robin]: Hey, Chloe.\n(Press Enter to Continue)",
    "[Chloe]: Sup.\n(Press Enter to Continue)",
    "[Robin]: What are…uh, how have you been?\n(Press Enter to Continue)",
    "[Chloe]: Fine for the most part, my latest Winstagram post got fewer likes than I hoped. No one really appreciates the old-fashioned scenery anymore.\n(Press Enter to Continue)",
    "[Robin]: Cool, cool, what do you, um, remember about me?\n(Press Enter to Continue)",
    "[Chloe]: Well, you used to be super into cameras, not sure why though.\n(Press Enter to Continue)",
    "[Robin]: What do you mean you don't remember? Wait, weren't you and Jae into cameras?\n(Press Enter to Continue)",
    "[Chloe]: Not sure.\n(Press Enter to Continue)",
    "[Robin]: But…\n(Press Enter to Continue)",
    "[Chloe]: Not sure.\n(Press Enter to Continue)",
    "[Robin]: …\n(Press Enter to Continue)"
    };
    bool hasMoreText = true;
    bool hasRecentlyPressedEnter = false;

    // Audio
    [SerializeField] AudioClip textDingSFX;

    PlayerMovement playerMovement;

    void Start()
    {
        // For Avatars
        avatars = new Sprite[] {robin, chloe, robin,
        chloe, robin, chloe,
        robin, chloe, robin,
        chloe, robin};
        ChangeAvatarImage(avatars[currentTextboxIndex]);

        textBoxText.text = texts[currentTextboxIndex];
        currentTextboxIndex = 1;

        playerMovement = FindObjectOfType<PlayerMovement>();
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
                // Enable Movement and SetActive to False?
                gameObject.SetActive(false);
                playerMovement.canDoAnything = true;
                // LoadNextScene();
            }

            // For Avatars
            avatars = new Sprite[] {robin, chloe, robin,
            chloe, robin, chloe,
            robin, chloe, robin,
            chloe, robin};
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
                    // Enable Movement and SetActive to False?
                    gameObject.SetActive(false);
                    playerMovement.canDoAnything = true;
                    // LoadNextScene();
                }

                // For Avatars
                avatars = new Sprite[] {robin, chloe, robin,
                chloe, robin, chloe,
                robin, chloe, robin,
                chloe, robin};
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

    /*void LoadNextScene()
    {
        // Gets index of current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }*/
}
