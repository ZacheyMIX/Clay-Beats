using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText; // name of npc
    public Text dialogueText;
    public Animator animator;
    public float textSpeed;
    public Queue<float> pauseTimes;
    private Queue<string> sentences;
    private Queue<int> fontSizes;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        pauseTimes = new Queue<float>();
        fontSizes = new Queue<int>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // animator for dialogue box
        animator.SetBool("IsOpen", true);

        // npc name
        nameText.text = dialogue.name;
        textSpeed = dialogue.textSpeed;

        sentences.Clear();
        pauseTimes.Clear();
        fontSizes.Clear();

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
            if (i < dialogue.pauseTimes.Length)
            {
                pauseTimes.Enqueue(dialogue.pauseTimes[i]);
            }
            else
            {
                pauseTimes.Enqueue(1f);
            }
            if (i < dialogue.fontSizes.Length)
            {
                fontSizes.Enqueue(dialogue.fontSizes[i]);
            }
            else
            {
                fontSizes.Enqueue(dialogueText.fontSize);
            }
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

        string sentence = sentences.Dequeue();
        float pauseTime = pauseTimes.Dequeue();
        int fontSize = fontSizes.Dequeue();

        dialogueText.fontSize = fontSize;

        // Letters of the dialogue show up one by one
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, pauseTime));
    }

    // Letters of the dialogue show up one by one
    IEnumerator TypeSentence (string sentence, float pauseTime)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            // wait textSpeed (seconds) before displaying next letter
            yield return new WaitForSeconds(textSpeed); 
        }
        yield return new WaitForSeconds(pauseTime);
        DisplayNextSentence();
    }

    void EndDialogue ()
    {
        animator.SetBool("IsOpen", false);
    }
}