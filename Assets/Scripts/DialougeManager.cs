using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialougeText;

    private Queue<string> sentences;
    
    public bool activeD;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        activeD = false;
    }

    public void StartDialouge(Dialouge dialouge)
    {
        activeD = true;
        animator.SetBool("isOpen", true);
        nameText.text = dialouge.name;

        sentences.Clear();

        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialougeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

    void EndDialouge()
    {
        activeD = false;
        animator.SetBool("isOpen", false);     
    }
}
