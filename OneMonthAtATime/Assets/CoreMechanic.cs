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

    public Button option1;
    public Button option2;
    public Button option3;
    public Button goHome;

    //values of each resource
    //this is what gets changed in the script that is then referenced by the TextMeshPro
    float moneyValue;
    float mentalHealthValue;
    float academicsValue;

    //toying with variables
    bool buttonsSet = false; //ensures the buttons are set only once
    int day = 1;
    bool daySet = false;
    string[] schedule;
    List<string> conversation;
    int scheduleIndex;
    public DialogueSystem dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the current values of each resource at the start
        moneyValue = float.Parse(money.text);
        mentalHealthValue = float.Parse(mentalHealth.text);
        academicsValue = float.Parse(academics.text);
        goHome.onClick.AddListener(goingHome);
        region.SetText("Home");
        day = 1;


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
        if (!daySet)
        {
            switch (day)
            {
                case 1:
                    schedule = new string[7] { "Start", "Dialogue", "School", "Dialogue", "Work", "Dialogue", "End" };
                    conversation = new List<string>() { "CAN'T YOU SEE I'M BLAZING", "STILL MY HEART IS BLAZING", "IF I LOSE MY WINGS", "I DON'T NEED A NEW WORLD ORDER", "CAN'T FEEL A THING" };
                    daySet = true;
                    scheduleIndex = 0;
                    break;
            }
        }

        else
        {
            if (schedule[scheduleIndex] == "Start" && !buttonsSet)
            {
                setButtonVisibility(true, false, false);
                setStartButton();
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "School" && !buttonsSet)
            {
                setButtonVisibility(true, true, true);
                setSchoolButtons();
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "Work" && !buttonsSet)
            {
                setButtonVisibility(true, true, true);
                setWorkButtons();
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "End" && !buttonsSet)
            {
                setButtonVisibility(true, false, false);
                setSleepButton();
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "Dialogue" )
            {
                setButtonVisibility(false, false, false);
            }
        }

        /*
        //At Home
        if(regionID == 0 && !buttonsSet)
        {
            setButtonVisibility(true, false, false);
            option1.onClick.AddListener(goToSchool);
            buttonsSet = true;
        }

        //At School
        if (regionID == 1 && !buttonsSet)
        {
            setButtonVisibility(true, true, true);
            setSchoolButtons(option1, option2, option3);
            buttonsSet = true;
        }
        */
    }
    void test()
    {
        scheduleIndex++;
    }
    public void progressDay()
    {
        scheduleIndex++;
    }

    //checks if the values exceed the max and min values
    void checkValues()
    {
        moneyValue = Mathf.Clamp(moneyValue, 0, 999999);
        mentalHealthValue = Mathf.Clamp(mentalHealthValue, 0, 100);
        academicsValue = Mathf.Clamp(academicsValue, 0, 4);
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
        //changeRegion("School", 1);
        scheduleIndex++;
    }

    //changes the region to home
    void goingHome()
    {
        changeRegion("Home", 0);
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
        option3.onClick.RemoveAllListeners();
        buttonsSet = false;
    }

    public void setValues(float money, float mentalHealth, float academics)
    {
        moneyValue += money;
        mentalHealthValue += mentalHealth;
        academicsValue += academics;
    }

    public void setButtonVisibility(bool but1, bool but2, bool but3)
    {
        option1.gameObject.SetActive(but1);
        option2.gameObject.SetActive(but2);
        option3.gameObject.SetActive(but3);
    }

    //School Methods -----------------------------------------------------------
    public void setSchoolButtons()
    {
        option1.onClick.AddListener(PayAttention);
        option2.onClick.AddListener(SlackOff);
        option3.onClick.AddListener(TakeNotes);


        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Pay Attention");
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Slack Off");
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Take Notes");
    }

    public void PayAttention()
    {
        setValues(2, 2, 2);
        scheduleIndex++;
    }

    public void SlackOff()
    {
        setValues(4, 4, 4);
        scheduleIndex++;
    }

    public void TakeNotes()
    {
        setValues(4, 4, 4);
        scheduleIndex++;
    }

    //Work Methods -------------------------------------------------------------
    public void setWorkButtons()
    {
        option1.onClick.AddListener(WorkAsUsual);
        option2.onClick.AddListener(TakeItEasy);
        option3.onClick.AddListener(WorkHard); 

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Business as Usual");
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Take it Easy");
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Work Hard");
    }

    public void WorkAsUsual()
    {
        setValues(2, 2, 1);
        scheduleIndex++;
    }

    public void TakeItEasy()
    {
        setValues(2, 2, 1);
        scheduleIndex++;
    }

    public void WorkHard()
    {
        setValues(2, 2, 1);
        scheduleIndex++;
    }

    public void setSleepButton()
    {
        option1.onClick.AddListener(sleep);

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Get Some Rest");
    }

    public void sleep()
    {
        Application.Quit();
    }

    public void setStartButton()
    {
        option1.onClick.AddListener(goToSchool);

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Go to School");
    }

}
