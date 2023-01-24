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
    string[] schedule;
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

    // Start is called before the first frame update
    void Start()
    {
        //grabs the current values of each resource at the start
        moneyValue = float.Parse(money.text);
        mentalHealthValue = float.Parse(mentalHealth.text);
        academicsValue = float.Parse(academics.text);
        day = 1;

        conversations = new List<string[]>();
    }

    // Update is called once per frame
    void Update()
    {
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
                    schedule = new string[7] { "Start", "Dialogue", "School", "Dialogue", "Work", "Dialogue", "End" };
                    /*conversations.Add(new string[] { "2CAN'T YOU SEE I'M BLAZING", "1STILL MY HEART IS BLAZING", "4IF I LOSE MY WINGS", "5I DON'T NEED A NEW WORLD ORDER", "6CAN'T FEEL A THING" });
                    conversations.Add(new string[] {"4THERE WILL BE BLOOD....SHED", "2THE MAN IN THE MIRROR NODES HIS HEAD", "1THE ONLY ONE...LEFT", "1WILL RIDE UPON THE DRAGON'S BACK" });
                    conversations.Add(new string[] { "3AND IT WILL COME", "3LIKE A FLODD OF PAIN", "6POURING DOWN ON ME", "2AND IT WILL NOT LET UP", "3UNTIL THE END IS HERE" });
                    */
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
        }
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
