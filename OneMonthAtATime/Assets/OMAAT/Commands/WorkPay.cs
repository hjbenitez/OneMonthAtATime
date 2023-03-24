using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT",
    "Work Pay",
    "Calculate the earned pay working")]

public class WorkPay : Command
{
    public int hours;
    public float multiplier;
    public int energy;
    public override void OnEnter()
    {
        GameManager.instance.WorkPay(hours, multiplier);
        GameManager.instance.SetValues(0, 0, 0, energy);
        Continue();
    }
}
