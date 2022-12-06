using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class CoreMechanic : MonoBehaviour
{
    //this displays the values onto the UI
    public TextMeshProUGUI money;
    public TextMeshProUGUI mentalHealth;
    public TextMeshProUGUI academics;

    //region variables
    public TextMeshProUGUI region; //displays region
    int regionID = 0; //tracks what region the player is in

    //max values for mental health and academic
    float maxMentalHealth = 100;
    float maxGPA = 4.0f;

    public Button option1;
    public Button option2;
    public Button goHome;

    //Debug buttons for each resource ------------------
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
    float moneyValue; 
    float mentalHealthValue;
    float academicsValue;

    //toying with variables
    bool buttonsSet = false; //ensures the buttons are set only once



    // Start is called before the first frame update
    void Start()
    {
        //grabs the current values of each resource at the start
        moneyValue = float.Parse(money.text);
        mentalHealthValue = float.Parse(mentalHealth.text);
        academicsValue = float.Parse(academics.text);
        goHome.onClick.AddListener(goingHome);
        region.SetText("Home");

        /* Un-comment to use for debug
        moneyPlus.onClick.AddListener(increaseMoney);
        moneyMinus.onClick.AddListener(decreaseMoney);

        mentalPlus.onClick.AddListener(increaseMental);
        mentalMinus.onClick.AddListener(decreaseMental);

        academicPlus.onClick.AddListener(increaseGPA);
        academicMinus.onClick.AddListener(decreaseGPA);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the UI text to reflect the values every frame
        money.text = moneyValue.ToString();
        mentalHealth.text = mentalHealthValue.ToString();
        academics.text = System.Math.Round(academicsValue, 2).ToString();

        //makes sure the values don't exceed the max or min values
        checkValues();

        //At Home
        if(regionID == 0 && !buttonsSet)
        {
            option1.onClick.AddListener(goToSchool);
            option2.onClick.AddListener(goToWork);

            option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Go to School");
            option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Go to Work");
            buttonsSet = true;
        }

        //At School
        if (regionID == 1 && !buttonsSet)
        {
            option1.onClick.AddListener(study);
            option2.onClick.AddListener(takeBreak);

            option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Study");
            option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Take Break");
            buttonsSet = true;
        }

        //At Work
        if (regionID == 2 && !buttonsSet)
        {
            option1.onClick.AddListener(waitTables);
            option2.onClick.AddListener(takeBreak);

            option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Wait Tables");
            option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Take Break");
            buttonsSet = true;
        }


    }


    //checks if the values exceed the max and min values
    void checkValues()
    {
        //checks if the values go below 0
        if(moneyValue < 0)
        {
            moneyValue = 0;
        }

        if(mentalHealthValue < 0)
        {
            mentalHealthValue = 0;
        }

        if (academicsValue < 0)
        {
            academicsValue = 0;
        }

        //checks if the values go above their respective maxes 
        if (mentalHealthValue > maxMentalHealth)
        {
            mentalHealthValue = maxMentalHealth;
        }

        if (academicsValue > maxGPA)
        {
            academicsValue = maxGPA;
        }
    }

    //Methods used to change the regions
    //changes the region to work
    void goToWork()
    {
        changeRegion("Work", 2);
    }

    //changes the region to school
    void goToSchool()
    {
        changeRegion("School", 1);
    }

    //changes the region to home
    void goingHome()
    {
        changeRegion("Home", 0);
    }

    //Victoria waits tables to make money
    void waitTables()
    {
        moneyValue += 10;
        mentalHealthValue -= 2;
        academicsValue -= 0.05f;
    }

    //Victoria studies to get better grades
    void study()
    {
        mentalHealthValue -= 4;
        academicsValue += 0.1f;
    }

    //Victoria takes a break to restore her mental fortitude
    void takeBreak()
    {
        mentalHealthValue += 5;
    }

    //base method to change region
    void changeRegion(string name, int id)
    {
        region.SetText(name);
        regionID = id;
    }

    //resets buttons to blanks when clicked
    public void removeAllListners()
    {
        option1.onClick.RemoveAllListeners();
        option2.onClick.RemoveAllListeners();
        buttonsSet = false;
    }


    //DEBUGGING METHODS ----------------------------------------------------
    /*functions used to increase/decrease the value of each resource 
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
    */
}
