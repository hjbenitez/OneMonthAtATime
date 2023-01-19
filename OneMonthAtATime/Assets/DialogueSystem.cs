using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    string [] dialogue;
    int index;

    public TextMeshProUGUI dialogueBox;
    public Image profilePic;
    public CoreMechanic coreMechanic;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.text = "Hello There!";
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coreMechanic.getCurrentTime() == "Dialogue")
        {
            changeDialogue(dialogue[index]);
            index++;

            if (index == dialogue.Length)
            {
                coreMechanic.progressDay();
                coreMechanic.nextDialogue();
                index = 0;
            }
        }      
    }

    void changeDialogue(string text)
    {
        dialogueBox.text = text;
    }

    public void getDialogue(string[] chain)
    {
        dialogue = chain;
    }
}
