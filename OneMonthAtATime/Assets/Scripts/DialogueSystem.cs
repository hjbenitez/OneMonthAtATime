using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    /*PROFILE PIC INDEX MEANINGS
    *0 = angry
    *1 = confused
    *2 = happy
    *3 = neutral
    *4 = sad
    *5 = sighing
    *6 = tired
    *7 = fear
    *8 = disgust
    *9 = surpirse
    */
    string [] dialogue;
    int index;

    public TextMeshProUGUI dialogueBox;
    public Image profilePic;
    public CoreMechanic coreMechanic;

    int pfpIndex;
    int charIndex;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.text = "Hello There!";
        index = 0;
        pfpIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        setCharacter(charIndex, pfpIndex);
        if (Input.GetKeyDown(KeyCode.Space) && coreMechanic.getCurrentTime() == "Dialogue" || coreMechanic.getCurrentTime() == "EventDialogue")
        {
            getCharacter(dialogue[index]);
            setDialogue(dialogue[index]);
            index++;

            if (index == dialogue.Length)
            {
                coreMechanic.progressDay();
                coreMechanic.nextDialogue();
                index = 0;
            }
        }      
    }

    void setDialogue(string text)
    {
        text = text.Remove(0, 2);
        dialogueBox.text = text;
    }

    public void getDialogue(string[] chain)
    {
        dialogue = chain;
    }

    void setCharacter(int character, int pfp)
    {
        if(character == 0)
        {
            profilePic.sprite = coreMechanic.victoria[pfp];
        }

        if(character == 1)
        {
            profilePic.sprite = coreMechanic.ashley[pfp];
        }
    }

    void getCharacter(string dialogue)
    {
        charIndex = int.Parse(dialogue.Substring(0, 1));
        pfpIndex = int.Parse(dialogue.Substring(1, 1));
    }
}
