using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class School : ScriptableObject
{
    CoreMechanic coreMechanic;
    // Start is called before the first frame update

    public School()
    {
        coreMechanic = GameObject.Find("GameManager").GetComponent<CoreMechanic>();
    }

    //3 options
    //Pay Attention - Go through the class as you would normally
    //Slack Off - Play a game and don't pay much attention
    //Take Notes - Take meticulous notes of the lecture

    public void setButtons(Button option1, Button option2, Button option3)
    { 
        option1.onClick.AddListener(PayAttention);
        option2.onClick.AddListener(SlackOff);
        option3.onClick.AddListener(TakeNotes);


        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Pay Attention");
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Slack OFf");
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Take Notes");
    }


    public void PayAttention()
    {
        coreMechanic.setValues(2, 2, 2);
    }

    public void SlackOff()
    {
        coreMechanic.setValues(4, 4, 4);
    }

    public void TakeNotes()
    {
        coreMechanic.setValues(-10, -10, -10);
    }

}
