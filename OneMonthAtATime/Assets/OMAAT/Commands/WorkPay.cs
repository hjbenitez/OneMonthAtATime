using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Fungus;

[CommandInfo("OMAAT",
    "Work Pay",
    "Calculate the earned pay working")]

public class WorkPay : Command
{
    public int hours;
    public int workHardEnergy;
    public int businessAsUsualEnergy;

    public override void OnEnter()
    {
        //Work Hard
        GameManager.instance.GetOption1().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues((int)Mathf.Round(15.5f * hours * 1.4f), 0, 0, workHardEnergy);
        });

        //Business As Usual
        GameManager.instance.GetOption2().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues((int)Mathf.Round(15.5f * hours * 1.2f), 0, 0, workHardEnergy);
        });

        //Slack Off
        GameManager.instance.GetOption3().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues((int)Mathf.Round(15.5f * hours), 0, 0, workHardEnergy);
        });

        Continue();
    }
}
