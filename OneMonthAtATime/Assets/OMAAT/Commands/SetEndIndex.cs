using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT", 
    "SetEndAnimation",
    "Sets the index for the end day animation")]

public class SetEndIndex : Command
{
    public int endScreenIndex;

    public override void OnEnter()
    {
        GameManager.instance.SetEndIndex(endScreenIndex);

        Continue();
    }
}
