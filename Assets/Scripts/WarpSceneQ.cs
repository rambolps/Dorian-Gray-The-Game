using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WarpSceneQ : MonoBehaviour
{
    private bool isRunning = false;
    public IEnumerator nextScene(string SceneName)
    {
        isRunning = true;
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        yield return StartCoroutine(sf.FadeToBlack());

        SceneManager.LoadScene(SceneName);
        isRunning = false;
    }

    public void Answer(string SceneName)
    {
        if (!isRunning)
        {
            StopAllCoroutines();
            StartCoroutine(nextScene(SceneName));
        }
    }

    public void killSibyl()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().isSibylAlive = false;
    }
    public void aliveSibyl()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().isSibylAlive = true;
    }

    public void madBasil()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().isBasilMad = true;
    }
    public void notMadBasil()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().isBasilMad = false;
    }

    public void quitGame()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            AudioManager aud = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            yield return StartCoroutine(sf.FadeToBlack());

            if (aud.isSibylAlive)
            {
                if (aud.isBasilMad)
                {
                    SceneManager.LoadScene("EndSibyl");
                }
                else
                {
                    SceneManager.LoadScene("EndSibylBasil");
                }
            }
            else
            {
                if (aud.isBasilMad)
                {
                    SceneManager.LoadScene("EndGood");
                }
                else
                {
                    SceneManager.LoadScene("EndBasil");
                }
            }
        }
    }
}
