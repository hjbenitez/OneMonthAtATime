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
    public override void OnEnter()
    {
        GameManager.instance.WorkPay(hours, multiplier);

        Continue();
    }
}
