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
    */
    string [] dialogue;
    int index;

    public TextMeshProUGUI dialogueBox;
    public Image profilePic;
    public CoreMechanic coreMechanic;

    int pfpIndex;
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
        setProfilePic(pfpIndex);
        if (Input.GetKeyDown(KeyCode.Space) && coreMechanic.getCurrentTime() == "Dialogue")
        {
            pfpIndex = getProfilePic(dialogue[index]);
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
        text = text.Remove(0, 1);
        dialogueBox.text = text;
    }

    public void getDialogue(string[] chain)
    {
        dialogue = chain;
    }

    void setProfilePic(int i)
    {
        profilePic.sprite = coreMechanic.victoria[i];
    }

    int getProfilePic(string dialogue)
    {
        int pfp = int.Parse(dialogue.Substring(0, 1));
        return pfp;
    }
}
