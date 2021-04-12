using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EndCurrentDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.name.Equals("Character") || collision.gameObject.name.Equals("ForestCharacter"))
            {

            TriggerDialogue();
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character") || collision.gameObject.name.Equals("ForestCharacter"))
        {

            EndCurrentDialogue();
        }
    }
}

