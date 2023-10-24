using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public PlayerController playerController;
    public DialogueManager dialogueManager;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }
    void Update()
    {
        if (playerController.CanViewDialogue && !dialogueManager.DialogueTriggered)
        {
            TriggerDialogue();
            dialogueManager.DialogueTriggered = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
