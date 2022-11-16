using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreMechanic : MonoBehaviour
{
    //this displays the values onto the UI
    public TextMeshProUGUI money;
    public TextMeshProUGUI mentalHealth;
    public TextMeshProUGUI academics;

    //Debug buttons for each resource
    //Money debug buttons
    public Button moneyPlus;
    public Button moneyMinus;

    //Mental health debug buttons
    public Button mentalPlus;
    public Button mentalMinus;

    //Academic debug buttons
    public Button academicPlus;
    public Button academicMinus;

    //values of each resource
    //this is what gets changed in the script that is then referenced by the TextMeshPro
    public float moneyValue; 
    public float mentalHealthValue;
    public float academicsValue;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the current values of each resource at the start
        moneyValue = float.Parse(money.text);
        mentalHealthValue = float.Parse(mentalHealth.text);
        academicsValue = float.Parse(academics.text);

        //Adds events for when the buttons are clicked
        moneyPlus.onClick.AddListener(increaseMoney);
        moneyMinus.onClick.AddListener(decreaseMoney);

        mentalPlus.onClick.AddListener(increaseMental);
        mentalMinus.onClick.AddListener(decreaseMental);

        academicPlus.onClick.AddListener(increaseGPA);
        academicMinus.onClick.AddListener(decreaseGPA);
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the UI text to reflect the values every frame
        money.text = moneyValue.ToString();
        mentalHealth.text = mentalHealthValue.ToString();
        academics.text = academicsValue.ToString();
    }


    //functions used to increase/decrease the value of each resource 
    void increaseMoney()
    {
        moneyValue += 20;
    }

    void decreaseMoney()
    {
        moneyValue -= 20;
    }

    void increaseMental()
    {
        mentalHealthValue += 5;
    }

    void decreaseMental()
    {
        mentalHealthValue -= 5;
    }

    void increaseGPA()
    {
        academicsValue += 0.2f;
    }

    void decreaseGPA()
    {
        academicsValue -= 0.2f;
    }

}
