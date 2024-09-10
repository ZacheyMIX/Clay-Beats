using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to store and trigger the dialogue
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    // Call this function to start the dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
