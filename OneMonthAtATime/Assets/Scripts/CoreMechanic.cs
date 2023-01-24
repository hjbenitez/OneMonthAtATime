using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CoreMechanic : MonoBehaviour
{
    //this displays the values onto the UI
    public TextMeshProUGUI money;
    public TextMeshProUGUI mentalHealth;
    public TextMeshProUGUI academics;

    //region variables
    public TextMeshProUGUI region; //displays region

    public Button option1;
    public Button option2;
    public Button option3;

    public Image energyBar;
    public Image moneyIcon;
    public Image healthIcon;
    public Image academicIcon;

    //values of each resource
    //this is what gets changed in the script that is then referenced by the TextMeshPro
    float moneyValue;
    float mentalHealthValue;
    float academicsValue;

    //toying with variables
    bool buttonsSet = false; //ensures the buttons are set only once
    int day = 1;
    bool daySet = false;
    List<string> schedule;
    List<string[]> conversations;
    int dialogueIndex;
    int scheduleIndex;
    public DialogueSystem dialogueSystem;
    float energy = 1f;

    float takeNotesEnergy = -0.6f;
    float payAttentionEnergy = -0.1f;
    float workAsUsualEnergy = -0.2f;
    float workHardEnergy = -0.6f;

    public Sprite[] victoria;
    public Sprite[] ashley;

    Events events;
    Event chosenEvent;
    int eventEnd;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the current values of each resource at the start
        moneyValue = float.Parse(money.text);
        mentalHealthValue = float.Parse(mentalHealth.text);
        academicsValue = float.Parse(academics.text);
        day = 1;

        conversations = new List<string[]>();
        events = new Events();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scheduleIndex);
        //Updates the UI text to reflect the values every frame
        money.text = moneyValue.ToString();
        mentalHealth.text = mentalHealthValue.ToString();
        academics.text = System.Math.Round(academicsValue, 2).ToString();
        energyBar.fillAmount = energy;

        //makes sure the values don't exceed the max or min values
        checkValues();
        updateIcons();

        if (!daySet)
        {
            switch (day)
            {
                //DAY 1
                case 1:
                    schedule = new string[8] { "Start", "Dialogue", "School", "Event", "Dialogue", "Work", "Dialogue", "End" }.ToList();

                    Day1 day1 = new Day1();
                    conversations = day1.getDialogue();
                    daySet = true;
                    scheduleIndex = 0;
                    dialogueIndex = 0;
                    break; 
                    // DAY 1 END ------------------------------------------------------
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
                dialogueSystem.getDialogue(conversations[dialogueIndex]);
            }

            else if (schedule[scheduleIndex] == "Event")
            {
                chosenEvent = events.getEvent(0);
                schedule.Insert(scheduleIndex + 1, "EventEnd");
                schedule.Insert(scheduleIndex + 1, "EventChoice");
                schedule.Insert(scheduleIndex + 1, "EventDialogue");
                progressDay();

            }

            else if (schedule[scheduleIndex] == "EventEnd")
            {
                setButtonVisibility(false, false, false);
            }

            else if (schedule[scheduleIndex] == "EventChoice" && !buttonsSet)
            {
                setButtonVisibility(true, true, true);
                setEventButtons(chosenEvent.option1, chosenEvent.option2, chosenEvent.option3);
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "EventDialogue")
            {
                setButtonVisibility(false, false, false);
                dialogueSystem.getDialogue(chosenEvent.dialogue); 
            }
        }
    }

    public void setEventButtons(Option op1, Option op2, Option op3)
    {
        option1.onClick.AddListener(() => {
            mentalHealthValue += op1.valueMentalHealth;
            moneyValue += op1.valueMoney;
            academicsValue += op1.valueAcademic;
            dialogueSystem.getDialogue(op1.response);
            progressDay();
        });

        option2.onClick.AddListener(() => {
            mentalHealthValue += op2.valueMentalHealth;
            moneyValue += op2.valueMoney;
            academicsValue += op2.valueAcademic;
            dialogueSystem.getDialogue(op2.response);
            progressDay();
        });

        option3.onClick.AddListener(() => {
            mentalHealthValue += op3.valueMentalHealth;
            moneyValue += op3.valueMoney;
            academicsValue += op3.valueAcademic;
            dialogueSystem.getDialogue(op3.response);
            progressDay();
        });

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText(op1.optionText);
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText(op2.optionText);
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText(op3.optionText);
    }

    public void progressDay()
    {
        scheduleIndex++;
    }

    public void nextDialogue()
    {
        dialogueIndex++;
    }

    public string getCurrentTime()
    {
        return schedule[scheduleIndex];
    }

    //checks if the values exceed the max and min values
    void checkValues()
    {
        moneyValue = Mathf.Clamp(moneyValue, 0, 999999);
        mentalHealthValue = Mathf.Clamp(mentalHealthValue, 0, 100);
        academicsValue = Mathf.Clamp(academicsValue, 0, 4);
    }

    void updateIcons()
    {
        healthIcon.fillAmount = mentalHealthValue / 100f;
        academicIcon.fillAmount = academicsValue / 4f;
    }

    //changes the region to school
    void goToSchool()
    {
        scheduleIndex++;
    }

    //resets buttons to blanks when clicked
    public void removeAllListners()
    {
        option1.onClick.RemoveAllListeners();
        option2.onClick.RemoveAllListeners();
        option3.onClick.RemoveAllListeners();

        option1.interactable = true;
        option2.interactable = true;
        option3.interactable = true;
        buttonsSet = false;
    }

    public void setValues(float money, float mentalHealth, float academics, float energyUse)
    {
        moneyValue += money;
        mentalHealthValue += mentalHealth;
        academicsValue += academics;
        energy += energyUse;
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
        option1.onClick.AddListener(SlackOff);

        if (energy > Mathf.Abs(payAttentionEnergy))
        {
            option2.onClick.AddListener(PayAttention);
        }

        else
        {
            option2.interactable = false;
        }

        if(energy > Mathf.Abs(takeNotesEnergy))
        {
            option3.onClick.AddListener(TakeNotes);
        }

        else
        {
            option3.interactable = false;
        }

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Slack Off");
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Take Notes");
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Pay Attention");
    }
    //EDIT THESE VALUES
    public void PayAttention()
    {
        setValues(0, -2, 0.02f, payAttentionEnergy);
        progressDay();
    }

    public void SlackOff()
    {
        setValues(0, 4, 0.04f, 0f);
        progressDay();
    }

    public void TakeNotes()
    {
        setValues(0, -6, 0.1f, takeNotesEnergy);
        progressDay();
    }

    //Work Methods -------------------------------------------------------------
    public void setWorkButtons()
    {
        option1.onClick.AddListener(TakeItEasy);

        if(energy > Mathf.Abs(workAsUsualEnergy))
        {
            option2.onClick.AddListener(WorkAsUsual);
        }

        else
        {
            option2.interactable = false;
        }

        if(energy > Mathf.Abs(workHardEnergy))
        {
            option3.onClick.AddListener(WorkHard);
        }

        else
        {
            option3.interactable = false;
        }

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Take it Easy");
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Business as Usual");
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Work Hard");
    }
    //EDIT THESE VALUES
    public void WorkAsUsual()
    {
        setValues(200, -5, 0, workAsUsualEnergy);
        progressDay();
    }

    public void TakeItEasy()
    {
        setValues(120, 5, 0, 0);
        progressDay();
    }

    public void WorkHard()
    {
        setValues(350, -15, 0, workHardEnergy);
        progressDay();
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
