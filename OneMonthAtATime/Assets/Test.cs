using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    List<string> dialogue;
    bool setDialogue = false;

    public DialogueSystem dialogueSystem;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = new List<string>() { "CAN'T YOU SEE I'M BLAZING", "STILL MY HEART IS BLAZING", "IF I LOSE MY WINGS", "I DON'T NEED A NEW WORLD ORDER", "CAN'T FEEL A THING"};
    }

    // Update is called once per frame
    void Update()
    {
        if(!setDialogue)
        {
            dialogueSystem.getDialogue(dialogue);
            setDialogue = true;
        }
    }
}
