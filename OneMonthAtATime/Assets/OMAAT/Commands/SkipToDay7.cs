using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT",
    "Skip to Day 7",
    "Starts the game on Day 5")]

public class SkipToDay7 : Command
{
    public override void OnEnter()
    {
        GameManager.instance.SkipToDay7();

        Continue();
    }
}