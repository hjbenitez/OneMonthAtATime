using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

[CommandInfo("OMAAT",
    "Set Buttons",
    "Sets the values so the button can hover properly")]

public class SetHoverValues : Command
{
    [Header("Option 1")]
    public int money1;
    public int mentalHealth1;
    public int academics1;
    public int energy1;

    [Header("Option 2")]
    public int money2;
    public int mentalHealth2;
    public int academics2;
    public int energy2;

    [Header("Option 3")]
    public int money3;
    public int mentalHealth3;
    public int academics3;
    public int energy3;

    public override void OnEnter()
    {
        GameManager.instance.GetOption1().setValue(money1, mentalHealth1, academics1, energy1);
        GameManager.instance.GetOption2().setValue(money2, mentalHealth2, academics2, energy2);
        GameManager.instance.GetOption3().setValue(money3, mentalHealth3, academics3, energy3);

        //setting option 1 values
        GameManager.instance.GetOption1().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues(mentalHealth1, academics1, money1, energy1);
        });

        GameManager.instance.GetOption2().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues(mentalHealth2, academics2, money2, energy2);
        });

        GameManager.instance.GetOption3().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues(mentalHealth2, academics2, money3, energy2);
        });


        Continue();
    }
}
