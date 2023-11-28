using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastText: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;

    // For Avatars
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite robin;
    [SerializeField] Sprite pixelatedRobin;
    [SerializeField] Sprite robin2;
    Sprite[] avatars;

    private int currentTextboxIndex = 0;
    string[] texts = {"[Robin]: Do you think they still remember?\n(Press Enter to Continue)",
    "[Robin?]: Who knows, after all, I am just you. Just don't forget yourself next time…\n(Press Enter to Continue)",
    "[Robin]: I used to do this? Did I really make all this up?\n(Press Enter to Continue)",
    "[Robin?]: Every little detail, but what's the point of overthinking every detail anyway, you'll just lose more, trying to grasp onto the things that never truly mattered..\n(Press Enter to Continue)",
    "[Robin]: The fault of stories is that their authors usually talk about everything but themselves. All this time I've been focused on the stories of others, but never my own.\n(Press Enter to Continue)",
    "[Robin]: I'll try to work on my own story now, less of the past, more of the future.\n(Press Enter to Continue)"
    };
    bool hasMoreText = true;
    bool hasRecentlyPressedEnter = false;

    // Audio
    [SerializeField] AudioClip textDingSFX;

    PlayerMovement playerMovement;

    void Start()
    {
        // For Avatars
        avatars = new Sprite[] {robin, pixelatedRobin,
        robin, pixelatedRobin, robin2, robin2};
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
                // FindObjectOfType<BossFollow>().enabled = true;
                // LoadNextScene();
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(currentSceneIndex);
            }

            // For Avatars
            avatars = new Sprite[] {robin, pixelatedRobin,
            robin, pixelatedRobin, robin2, robin2};
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
                    // FindObjectOfType<BossFollow>().enabled = true;
                    // LoadNextScene();
                    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    SceneManager.LoadScene(currentSceneIndex);
                }

                // For Avatars
                avatars = new Sprite[] {robin, pixelatedRobin,
                robin, pixelatedRobin, robin2, robin2};
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
