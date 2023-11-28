using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossText: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;

    // For Avatars
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite robin;
    [SerializeField] Sprite pixelatedRobin;
    Sprite[] avatars;

    private int currentTextboxIndex = 0;
    string[] texts = {"[???]: It's always about them isn't it, what about me, what ever happened to what we had?\n(Press Enter to Continue)",
    "[Robin]: It's not like that, I just don't know.\n(Press Enter to Continue)",
    "[???]: Of course you don't know, you don't remember… What even are you?\n(Press Enter to Continue)",
    "[Robin]: I'm… I'm…\n(Press Enter to Continue)",
    "[???]: You're a man who's lost even more by thinking about everything he's lost. You don't even know how this world was created.\n(Press Enter to Continue)",
    };
    bool hasMoreText = true;
    bool hasRecentlyPressedEnter = false;

    // Audio
    [SerializeField] AudioClip textDingSFX;

    PlayerMovement playerMovement;

    void Start()
    {
        // For Avatars
        avatars = new Sprite[] {pixelatedRobin, robin,
        pixelatedRobin, robin, pixelatedRobin};
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
                FindObjectOfType<BossFollow>().enabled = true;
                // LoadNextScene();
            }

            // For Avatars
            avatars = new Sprite[] {pixelatedRobin, robin,
            pixelatedRobin, robin, pixelatedRobin};
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
                    FindObjectOfType<BossFollow>().enabled = true;
                    // LoadNextScene();
                }

                // For Avatars
                avatars = new Sprite[] {pixelatedRobin, robin,
                pixelatedRobin, robin, pixelatedRobin};
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
