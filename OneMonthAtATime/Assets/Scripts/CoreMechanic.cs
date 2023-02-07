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

     float takeNotesEnergy = -0.6f;
     float payAttentionEnergy = -0.1f;
     float workAsUsualEnergy = -0.2f;
     float workHardEnergy = -0.6f;

     public Sprite[] victoria;
     public Sprite[] ashley;

     Events events;
     Event chosenEvent;
     public bool playerChose = false;
     public bool dialogueSet = false;

     // Start is called before the first frame update
     void Start()
     {
          //grabs the current values of each resource at the start
          moneyValue = 500;
          academicsValue = 3.0f;
          mentalHealthValue = 80f;
          //day = 1;

          conversations = new List<string[]>();
          events = new Events();
          house = GetComponent<HousingSelection>();
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
                         schedule = new string[] { "Dialogue", "School", "Dialogue", "Work", "EventWork", "Dialogue", "End" }.ToList();

                         Day1 day1 = new Day1();
                         conversations = day1.getDialogue();
                         daySet = true;
                         scheduleIndex = 0;
                         dialogueIndex = 0;
                         break;
                    // DAY 1 END ------------------------------------------------------

                    case 2:
                         schedule = new string[] { "Dialogue", "School", "EventSchool", "Dialogue", "Freetime", "School", "Dialogue", "End" }.ToList();
                         Day2 day2 = new Day2();
                         conversations = day2.getDialogue();
                         daySet = true;
                         energy += 0.5f;
                         scheduleIndex = 0;
                         dialogueIndex = 0;
                         break;

                    case 3:
                         Debug.Log("LOL");
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

               else if (schedule[scheduleIndex] == "Dialogue")
               {
                    setButtonVisibility(false, false, false);
                    dialogueSystem.getDialogue(conversations[dialogueIndex]);
                    dialogueSet = true;
               }

               else if (schedule[scheduleIndex] == "Freetime" && !buttonsSet)
               {
                    setButtonVisibility(true, true, true);
                    setFreetimeButtons("Go to Work", "Go home and study with Olivia", "Go home and play the new game");
                    buttonsSet = true;
               }

               //WORK EVENTS --------------------------------------------------
               else if (schedule[scheduleIndex] == "EventWork")
               {
                    chosenEvent = events.getEvent(1);

                    if (chosenEvent.options)
                    {
                         schedule.Insert(scheduleIndex + 1, "Dialogue");
                         schedule.Insert(scheduleIndex + 1, "EventChoice");

                         schedule.Insert(scheduleIndex + 1, "Dialogue");
                         conversations.Insert(dialogueIndex, chosenEvent.dialogue);
                         progressDay();
                    }

                    else
                    {
                         schedule.Insert(scheduleIndex + 1, "Dialogue");
                         conversations.Insert(dialogueIndex, chosenEvent.dialogue);
                         progressDay();
                    }

               }

               //SCHOOL EVENTS ------------------------------------------------------------
               else if (schedule[scheduleIndex] == "EventSchool")
               {
                    chosenEvent = events.getEvent(0);

                    if (chosenEvent.options)
                    {
                         schedule.Insert(scheduleIndex + 1, "Dialogue"); //after event
                         schedule.Insert(scheduleIndex + 1, "EventChoice"); //event

                         schedule.Insert(scheduleIndex + 1, "Dialogue"); //before even
                         conversations.Insert(dialogueIndex, chosenEvent.dialogue);
                         progressDay();
                    }

                    else
                    {
                         schedule.Insert(scheduleIndex + 1, "Dialogue");
                         conversations.Insert(dialogueIndex, chosenEvent.dialogue);
                         progressDay();
                    }

               }

               else if (schedule[scheduleIndex] == "EventChoice" && !buttonsSet)
               {
                    setButtonVisibility(true, true, true);
                    setEventButtons(chosenEvent.option1, chosenEvent.option2, chosenEvent.option3);
                    buttonsSet = true;
               }
          }
     }

     public void setEventButtons(Option op1, Option op2, Option op3)
     {
          option1.onClick.AddListener(() =>
          {
               mentalHealthValue += op1.valueMentalHealth;
               moneyValue += op1.valueMoney;
               academicsValue += op1.valueAcademic;
               conversations.Insert(dialogueIndex, op1.response);
               progressDay();
          });

          option2.onClick.AddListener(() =>
          {
               mentalHealthValue += op2.valueMentalHealth;
               moneyValue += op2.valueMoney;
               academicsValue += op2.valueAcademic;
               conversations.Insert(dialogueIndex, op2.response);
               progressDay();
          });

          option3.onClick.AddListener(() =>
          {
               mentalHealthValue += op3.valueMentalHealth;
               moneyValue += op3.valueMoney;
               academicsValue += op3.valueAcademic;
               conversations.Insert(dialogueIndex, op3.response);
               progressDay();
          });

          option1.GetComponentInChildren<TextMeshProUGUI>().SetText(op1.optionText);
          option2.GetComponentInChildren<TextMeshProUGUI>().SetText(op2.optionText);
          option3.GetComponentInChildren<TextMeshProUGUI>().SetText(op3.optionText);
     }

     void setFreetimeButtons(string op1, string op2, string op3)
     {
          option1.onClick.AddListener(goToWork);
          option2.onClick.AddListener(studyWithOlivia);
          option3.onClick.AddListener(playGames);

          option1.GetComponentInChildren<TextMeshProUGUI>().SetText(op1);
          option2.GetComponentInChildren<TextMeshProUGUI>().SetText(op2);
          option3.GetComponentInChildren<TextMeshProUGUI>().SetText(op3);
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
     void studyWithOlivia()
     {
          setValues(0f, 0, 0.05f, 0f);
          schedule.Insert(scheduleIndex + 1, "Dialogue");
          conversations.Insert(dialogueIndex, new Day2().getStudyDialogue(0));
          scheduleIndex++;
     }

     void playGames()
     {
          setValues(0f, 10f, 0f, 0.25f);

          schedule.Insert(scheduleIndex + 1, "Dialogue");
          conversations.Insert(dialogueIndex, new Day2().getGameDialogue(0));
          scheduleIndex++;
     }

     void goToWork()
     {
          schedule.Insert(scheduleIndex + 1, "Dialogue"); //dialogue after work
          conversations.Insert(dialogueIndex, new Day2().getWorkDialogue(1));

          schedule.Insert(scheduleIndex + 1, "Work"); //working

          schedule.Insert(scheduleIndex + 1, "Dialogue"); //dialogue before work       
          conversations.Insert(dialogueIndex, new Day2().getWorkDialogue(0));

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

          if (energy > Mathf.Abs(takeNotesEnergy))
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

          if (energy > Mathf.Abs(workAsUsualEnergy))
          {
               option2.onClick.AddListener(WorkAsUsual);
          }

          else
          {
               option2.interactable = false;
          }

          if (energy > Mathf.Abs(workHardEnergy))
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
