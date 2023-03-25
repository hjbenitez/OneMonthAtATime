using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo ("OMAAT", 
    "Dim Victoria", 
    "Dim Victoria when she is not talking")]

public class DimVictoria : Command
{
    public override void OnEnter()
    {
        GameManager.instance.DimVictoria();
        Continue();
    }
}
