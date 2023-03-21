using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT",
    "GetDay",
    "Gets the current day from the game manager")]

public class GetDay : Command
{
    [SerializeField] protected AnyVariableAndDataPair anyVar = new AnyVariableAndDataPair();

    public override void OnEnter()
    {

        GameManager.instance.GetDay();
    }
}
