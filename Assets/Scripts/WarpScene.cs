using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpScene : MonoBehaviour
{
    public string SceneName;
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<WarpManager>().isWarping = true;

            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            yield return StartCoroutine(sf.FadeToBlack());

            SceneManager.LoadScene(SceneName);

            FindObjectOfType<WarpManager>().isWarping = false;
        }
    }
}
