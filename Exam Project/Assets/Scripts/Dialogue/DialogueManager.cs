using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public PlayerController playerController;
    public bool DialogueTriggered = false;

    public Animator anim;

    private Queue<string> sentences;
  

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
        playerController.CanViewDialogue = false;
        DialogueTriggered = false;
        anim.SetBool("isOpen", false);
        Debug.Log("End of Conversation...");
    }

}
