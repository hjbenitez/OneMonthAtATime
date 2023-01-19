using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    List<string> dialogue = new List<string>();
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
        if (index == dialogue.Count)
        {
            coreMechanic.progressDay();
            index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeDialogue(dialogue[index]);
            index++;
        }      
    }

    void changeDialogue(string text)
    {
        dialogueBox.text = text;
    }

    public void getDialogue(List<string> chain)
    {
        dialogue = chain;
    }
}
