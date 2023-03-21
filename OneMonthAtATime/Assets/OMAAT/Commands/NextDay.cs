using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT",
    "NextDay",
    "Progresses the current day to the next")]

public class NextDay : Command
{
    public override void OnEnter()
    {
        GameManager.instance.NextDay();
        Continue();
    }
}
