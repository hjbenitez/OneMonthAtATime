using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT",
    "Skip to Day 5",
    "Starts the game on Day 5")]

public class SkipToDay5 : Command
{
    public override void OnEnter()
    {
        GameManager.instance.SkipToDay5();

        Continue();
    }
}