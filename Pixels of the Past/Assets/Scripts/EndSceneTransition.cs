using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneTransition : MonoBehaviour
{   
    [SerializeField] Image image;
    [SerializeField] Sprite img1;
    [SerializeField] Sprite img2;

    void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        image.sprite = img1;
        yield return new WaitForSecondsRealtime(4f);
        image.sprite = img2;

    }
}
