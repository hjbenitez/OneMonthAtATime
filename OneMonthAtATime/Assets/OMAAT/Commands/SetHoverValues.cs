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
    public float money1;
    public int mentalHealth1;
    public int academics1;
    public int energy1;

    [Header("Option 2")]
    public float money2;
    public int mentalHealth2;
    public int academics2;
    public int energy2;

    [Header("Option 3")]
    public float money3;
    public int mentalHealth3;
    public int academics3;
    public int energy3;

    public override void OnEnter()
    {
        GameManager.instance.GetOption1().setValue((int)money1, mentalHealth1, academics1, energy1);
        GameManager.instance.GetOption2().setValue((int)money2, mentalHealth2, academics2, energy2);
        GameManager.instance.GetOption3().setValue((int)money3, mentalHealth3, academics3, energy3);

        //setting option 1 values
        GameManager.instance.GetOption1().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues((int)money1, mentalHealth1, academics1, energy1);
        });

        GameManager.instance.GetOption2().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues((int)money2, mentalHealth2, academics2, energy2);
        });

        GameManager.instance.GetOption3().GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.instance.SetValues((int)money3, mentalHealth3, academics3, energy3);
        });


        Continue();
    }
}
