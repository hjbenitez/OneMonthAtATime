using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3
{
    List<string[]> dialogue;

    public Day3()
    {
        dialogue = new List<string[]>();

        dialogue.Add(new string[] {"001", "002", "003" });

        dialogue.Add(new string[] { "004", "005", "006" });

        dialogue.Add(new string[] { "007", "008", "009" });

        dialogue.Add(new string[] { "00a", "00b", "00c" });

        dialogue.Add(new string[] { "00d", "00e", "00f" });

        dialogue.Add(new string[] { "00g", "00h", "00i" });
    }

    public List<string[]> getDialogue()
    {
        return dialogue;
    }
}
