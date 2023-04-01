using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("Variables",
    "Set Resource Values",
    "Set the values of the resources")]

public class SetResourceValues : Command
{
    public int money;
    public int mental;
    public int academic;
    public int energy;

    public override void OnEnter()
    {
        GameManager.instance.SetValues(money, mental, academic, energy);

        Continue();
    }
}
