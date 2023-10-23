using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public GameObject SentenceAvailableTxt;

    public Animator anim;

    private Queue<string> sentences;
  

    void Start()
    {
        //SentenceAvailableTxt.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //SentenceAvailableTxt.SetActive(false);
            EndDialogue();
            return;
        }
        if (sentences.Count > 0)
        {
            Debug.Log("Show next sentence");
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        anim.SetBool("isOpen", false);
        Debug.Log("End of Conversation...");
    }

}
