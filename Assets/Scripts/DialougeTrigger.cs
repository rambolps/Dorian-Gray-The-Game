using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge;
    private bool inRange;

    private void Update()
    {
        if (inRange)
        {
            goDialouge();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inRange = true;
            Debug.Log("true");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inRange = false;
        }

        Debug.Log("False");
    }

    void goDialouge()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!FindObjectOfType<DialougeManager>().activeD)
            {
                FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
            }
            else
            {
                FindObjectOfType<DialougeManager>().DisplayNextSentence();
            }
        }
    }
}
