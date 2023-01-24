using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1
{
    List<string[]> dialogue;

    public Day1()
    {
        dialogue = new List<string[]>();

        dialogue.Add(new string[] { "2CAN'T YOU SEE I'M BLAZING", "1STILL MY HEART IS BLAZING", "4IF I LOSE MY WINGS", "5I DON'T NEED A NEW WORLD ORDER", "6CAN'T FEEL A THING" });
        dialogue.Add(new string[] { "4THERE WILL BE BLOOD....SHED", "2THE MAN IN THE MIRROR NODES HIS HEAD", "1THE ONLY ONE...LEFT", "1WILL RIDE UPON THE DRAGON'S BACK" });
        dialogue.Add(new string[] { "3AND IT WILL COME", "3LIKE A FLODD OF PAIN", "6POURING DOWN ON ME", "2AND IT WILL NOT LET UP", "3UNTIL THE END IS HERE" });
    }

    public List<string[]> getDialogue()
    {
        return dialogue;
    }
}
