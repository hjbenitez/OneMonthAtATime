using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1
{
    List<string[]> dialogue;

    public Day1()
    {
        dialogue = new List<string[]>();

        dialogue.Add(new string[] { "02CAN'T YOU SEE I'M BLAZING", "01STILL MY HEART IS BLAZING", "04IF I LOSE MY WINGS", "05I DON'T NEED A NEW WORLD ORDER", "06CAN'T FEEL A THING" });
        dialogue.Add(new string[] { "04THERE WILL BE BLOOD....SHED", "12THE MAN IN THE MIRROR NODES HIS HEAD", "01THE ONLY ONE...LEFT", "11WILL RIDE UPON THE DRAGON'S BACK" });
        dialogue.Add(new string[] { "03AND IT WILL COME", "13LIKE A FLODD OF PAIN", "16POURING DOWN ON ME", "12AND IT WILL NOT LET UP", "03UNTIL THE END IS HERE" });
    }

    public List<string[]> getDialogue()
    {
        return dialogue;
    }
}
