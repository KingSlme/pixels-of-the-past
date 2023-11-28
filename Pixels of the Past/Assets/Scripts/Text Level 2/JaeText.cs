using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JaeText: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBoxText;

    // For Avatars
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite robin;
    [SerializeField] Sprite jae;
    Sprite[] avatars;

    private int currentTextboxIndex = 0;
    string[] texts = {"[Robin]: Is that really you, Jae?\n(Press Enter to Continue)",
    "[Jae]: Who else would it be? Long time no see.\n(Press Enter to Continue)",
    "[Robin]: What are you up to?\n(Press Enter to Continue)",
    "[Jae]: Just taking photos.\n(Press Enter to Continue)",
    "[Robin]: Of what?\n(Press Enter to Continue)",
    "[Jae]: Just taking photos.\n(Press Enter to Continue)",
    "[Robin]: Yeah I get that, of what, man?\n(Press Enter to Continue)",
    "[Jae]: Just taking photos.\n(Press Enter to Continue)",
    "[Robin]: Jae, I thought, I uh…\n(Press Enter to Continue)"
    };
    bool hasMoreText = true;
    bool hasRecentlyPressedEnter = false;

    // Audio
    [SerializeField] AudioClip textDingSFX;

    PlayerMovement playerMovement;

    void Start()
    {
        // For Avatars
        avatars = new Sprite[] {robin, jae, robin,
        jae, robin, jae,
        robin, jae, robin};
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
            avatars = new Sprite[] {robin, jae, robin,
            jae, robin, jae,
            robin, jae, robin};
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
                avatars = new Sprite[] {robin, jae, robin,
                jae, robin, jae,
                robin, jae, robin};
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
