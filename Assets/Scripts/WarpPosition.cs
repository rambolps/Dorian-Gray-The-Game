using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPosition : MonoBehaviour
{
    public Transform warpTarget;

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<WarpManager>().isWarping = true;
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            yield return StartCoroutine(sf.FadeToBlack());

            other.gameObject.transform.position = warpTarget.position;
            Camera.main.transform.position = warpTarget.position;

            yield return StartCoroutine(sf.FadeToClear());
            FindObjectOfType<WarpManager>().isWarping = false;
        }
    }
}
