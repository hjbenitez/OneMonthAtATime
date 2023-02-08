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
    public int day = 1;
    bool daySet = false;
    List<string> schedule;
    List<string[]> conversations;
    int dialogueIndex;
    int scheduleIndex;
    public DialogueSystem dialogueSystem;
    float energy = 1f;
    HousingSelection house;


    public Sprite[] victoria;
    public Sprite[] ashley;

    Event chosenEvent;
    public bool playerChose = false;
    public bool dialogueSet = false;

    //day3 testing variables
    List<Event> newEvents;
    int eventIndex;
    Day3 day3;
    Event freetime;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the current values of each resource at the start
        moneyValue = 500;
        academicsValue = 3.0f;
        mentalHealthValue = 80f;
        //day = 1;

        conversations = new List<string[]>();
        house = GetComponent<HousingSelection>();

        eventIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(house.getSelection());
        //Updates the UI text to reflect the values every frame
        money.text = moneyValue.ToString();
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
                    Day1 day1 = new Day1();

                    schedule = day1.getSchedule().ToList(); ;
                    conversations = day1.getDialogue();
                    newEvents = day1.getEvents();

                    daySet = true;
                    energy += 0.5f;
                    scheduleIndex = 0;
                    dialogueIndex = 0;
                    eventIndex = 0;
                    break;
                // DAY 1 END ------------------------------------------------------

                //DAY 2
                case 2:
                    Day2 day2 = new Day2();

                    schedule = day2.getSchedule().ToList();
                    conversations = day2.getDialogue();
                    newEvents = day2.getEvents();

                    daySet = true;
                    energy += 0.5f;
                    scheduleIndex = 0;
                    dialogueIndex = 0;
                    eventIndex = 0;
                    break;
                // DAY 2 END ------------------------------------------------------

                //DAY 3 - TESTING
                case 3:
                    day3 = new Day3();

                    schedule = day3.getSchedule().ToList();
                    conversations = day3.getDialogue();
                    newEvents = day3.getEvents();

                    daySet = true;
                    energy += 0.5f;
                    scheduleIndex = 0;
                    dialogueIndex = 0;
                    eventIndex = 0;
                    break;
                // DAY 3 END ------------------------------------------------------
            }
        }

        else
        {
            if (schedule[scheduleIndex] == "Event" && !buttonsSet)
            {
                chosenEvent = newEvents[eventIndex];

                schedule.Insert(scheduleIndex + 1, "Dialogue"); //after event

                setButtonVisibility(true, true, true);
                setEventButtons(chosenEvent.option1, chosenEvent.option2, chosenEvent.option3);
                buttonsSet = true;
            }

            if (schedule[scheduleIndex] == "newFreetime")
            {
                schedule.Insert(scheduleIndex + 1, "Event"); //event
                progressDay();
            }

            if (schedule[scheduleIndex] == "Start" && !buttonsSet)
            {
                setButtonVisibility(true, false, false);
                setStartButton();
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "School")
            {
                schedule.Insert(scheduleIndex + 1, "Event"); //event
                progressDay();
            }

            else if (schedule[scheduleIndex] == "Work")
            {
                schedule.Insert(scheduleIndex + 1, "Event"); //event
                progressDay();
            }

            else if (schedule[scheduleIndex] == "End" && !buttonsSet)
            {
                setButtonVisibility(true, false, false);
                setSleepButton();
                buttonsSet = true;
            }

            else if (schedule[scheduleIndex] == "Dialogue")
            {
                setButtonVisibility(false, false, false);
                dialogueSystem.getDialogue(conversations[dialogueIndex]);
                dialogueSet = true;
            }

            else if (schedule[scheduleIndex] == "Freetime")
            {
                schedule.Insert(scheduleIndex + 1, "Event"); //event
                progressDay();
            }
        }
    }

    public void setEventButtons(Option op1, Option op2, Option op3)
    {
        if ((Mathf.Sign(op1.energy) == -1 && energy >= Mathf.Abs(op1.energy)) || Mathf.Sign(op1.energy) == 1)
        {
            option1.onClick.AddListener(() =>
            {
                setValues(op1.valueMoney, op1.valueMentalHealth, op1.valueAcademic, op1.energy);

                conversations.Insert(dialogueIndex, op1.response);
                progressDay();
                eventIndex++;
            });
        }

        else
        {
            option1.interactable = false;
        }

        if ((Mathf.Sign(op2.energy) == -1 && energy >= Mathf.Abs(op2.energy)) || Mathf.Sign(op2.energy) == 1)
        {
            option2.onClick.AddListener(() =>
            {
                setValues(op2.valueMoney, op2.valueMentalHealth, op2.valueAcademic, op2.energy);

                conversations.Insert(dialogueIndex, op2.response);
                progressDay();
                eventIndex++;
            });
        }

        else
        {
            option2.interactable = false;
        }

        if ((Mathf.Sign(op3.energy) == -1 && energy >= Mathf.Abs(op3.energy)) || Mathf.Sign(op3.energy) == 1)
        {
            option3.onClick.AddListener(() =>
            {
                setValues(op3.valueMoney, op3.valueMentalHealth, op3.valueAcademic, op3.energy);

                conversations.Insert(dialogueIndex, op3.response);
                progressDay();
                eventIndex++;
            });
        }

        else
        {
            option3.interactable = false;
        }

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText(op1.optionText);
        option2.GetComponentInChildren<TextMeshProUGUI>().SetText(op2.optionText);
        option3.GetComponentInChildren<TextMeshProUGUI>().SetText(op3.optionText);
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

    public void setValues(float money, float mentalHealth, float academics, float energy)
    {
        moneyValue += money;
        mentalHealthValue += mentalHealth;
        academicsValue += academics;
        energy += energy;
    }

    public void setButtonVisibility(bool but1, bool but2, bool but3)
    {
        option1.gameObject.SetActive(but1);
        option2.gameObject.SetActive(but2);
        option3.gameObject.SetActive(but3);
    }

    public void setSleepButton()
    {
        option1.onClick.AddListener(sleep);

        option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Get Some Rest");
    }

    public void sleep()
    {
        daySet = false;
        day++;
    }

    public void setStartButton()
    {
        //option1.onClick.AddListener(goToSchool);

        //option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Go to School");
    }

    public void optionSelected()
    {
        playerChose = true;
    }

    public string nextEvent()
    {
        return schedule[scheduleIndex + 1];
    }

    public int getDay()
    {
        return day;
    }
}
