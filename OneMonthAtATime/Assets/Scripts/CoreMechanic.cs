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
     public float mentalHealthValue;
     float academicsValue;
     float energyValue = 1f;

     //toying with variables
     bool buttonsSet = false; //ensures the buttons are set only once
     public int day = 1;
     bool daySet = false;
     List<string> schedule;
     List<string[]> conversations;
     int dialogueIndex;
     int scheduleIndex;
     public DialogueSystem dialogueSystem;
     HousingSelection house;

     [Header("Characters")]
     public Sprite[] victoria; //1
     public Sprite[] ashley;   //2
     public Sprite[] jackson;  //3 
     public Sprite[] olivia;   //4
     public Sprite[] chris;    //5
     public Sprite[] harry;    //6

     [Header("Locations")]
     public Image currentLocation;
     public Sprite[] locations;
     int locationIndex;
     bool locationGrabbed;

     /*Location Index
      * 0 = Home
      * 1 = School
      * 2 = Work
      * 3 = Parent's House
      * 4 = Grocery Store
      */

     Event chosenEvent;
     public bool playerChose = false;
     public bool dialogueSet = false;

     //testing variables
     List<Event> newEvents;
     int eventIndex;
     float wage = 15.5f;
     Day currentDay;
     public int maxMentalHealth;
     Dictionary<int, string> scheduleKey;

     // Start is called before the first frame update
     void Start()
     {
          //grabs the current values of each resource at the start
          moneyValue = 500;
          academicsValue = 3.0f;
          //mentalHealthValue = 80f;
          //day = 1;

          conversations = new List<string[]>();
          house = GetComponent<HousingSelection>();

          eventIndex = 0;
          maxMentalHealth = 100;
          locationGrabbed = false;

          scheduleKey = new Dictionary<int, string>();
          scheduleKey.Add(1, "1School");
          scheduleKey.Add(2, "2Work");

     }

     // Update is called once per frame
     void Update()
     {
          Debug.Log(house.getSelection());
          //Updates the UI text to reflect the values every frame
          money.text = moneyValue.ToString();
          healthIcon.fillAmount = mentalHealthValue / 100f;
          academicIcon.fillAmount = academicsValue / 4f;
          energyBar.fillAmount = energyValue;

          //makes sure the values don't exceed the max or min values
          checkValues();

          if (!daySet)
          {
               switch (day)
               {
                    //DAY 1
                    case 1:
                         currentDay = new Day1();
                         break;
                    //DAY 2
                    case 2:
                         currentDay = new Day2();
                         break;
                    //DAY 3
                    case 3:
                         currentDay = new Day3();
                         break;
                    //DAY 4
                    case 4:
                         currentDay = new Day4();
                         break;
                    //DAY 5
                    case 5:
                         currentDay = new Day5();
                         break;
                    //DAY 6
                    case 6:
                         currentDay = new Day6();
                         break;
                    //DAY 7
                    case 7:
                         currentDay = new Day7();
                         break;
                    //DAY 8
                    case 8:
                         currentDay = new Day8();
                         break;
                    //DAY 9
                    case 9:
                         currentDay = new Day9();
                         break;
                    //DAY 10
                    case 10:
                         currentDay = new Day10();
                         break;
                    //DAY 11
                    case 11:
                         currentDay = new Day11();
                         break;
                    //DAY 12
                    case 12:
                         currentDay = new Day12();
                         break;
                    //DAY 13
                    case 13:
                         currentDay = new Day13();
                         break;
                    //DAY 14
                    case 14:
                         currentDay = new Day14();
                         break;
               }

               schedule = currentDay.getSchedule().ToList(); ;
               conversations = currentDay.getDialogue();
               newEvents = currentDay.getEvents();

               //checkDebuffs();

               daySet = true;
               energyValue += 0.5f;
               scheduleIndex = 0;
               dialogueIndex = 0;
               eventIndex = 0;
               locationIndex = 0;
          }

          else
          {
               Debug.Log(eventIndex + " " + newEvents.Count);
               if (!locationGrabbed)
               {
                    locationIndex = int.Parse(schedule[scheduleIndex].Substring(0, 1));
                    currentLocation.sprite = locations[locationIndex];
                    schedule[scheduleIndex] = schedule[scheduleIndex].Remove(0, 1);
                    locationGrabbed = true;
               }

               if (schedule[scheduleIndex] == "Event" && !buttonsSet)
               {
                    chosenEvent = newEvents[eventIndex];

                    schedule.Insert(scheduleIndex + 1, new string(locationIndex + "Dialogue")); //after event

                    setButtonVisibility(true, true, true);
                    setEventButtons(chosenEvent.option1, chosenEvent.option2, chosenEvent.option3);
                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "Work" && !buttonsSet)
               {
                    setButtonVisibility(true, true, true);
                    setWorkButtons(currentDay.getHours()); ;
                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "Start" && !buttonsSet)
               {
                    setButtonVisibility(true, false, false);
                    setStartButton();
                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "Dialogue")
               {
                    setButtonVisibility(false, false, false);
                    dialogueSystem.getDialogue(conversations[dialogueIndex]);
                    dialogueSet = true;
               }

               else if (schedule[scheduleIndex] == "End" && !buttonsSet)
               {
                    setButtonVisibility(true, false, false);
                    setSleepButton();
                    buttonsSet = true;
               }

               else
               {
                    schedule.Insert(scheduleIndex + 1, new string(locationIndex + "Event")); //event
                    progressDay();

               }

          }
     }

     public void setEventButtons(Option op1, Option op2, Option op3)
     {
          if(op1.toEvent == 0 )
          {
               if ((Mathf.Sign(op1.energy) == -1 && energyValue >= Mathf.Abs(op1.energy)) || Mathf.Sign(op1.energy) == 1)
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
          }

          else
          {
               option1.onClick.AddListener(() =>
               {
                    schedule.Insert(scheduleIndex + 1, scheduleKey[op1.toEvent]);
                    schedule.Insert(scheduleIndex + 1, locationIndex + "Dialogue");
                    conversations.Insert(dialogueIndex, op1.response);
                    progressDay();
                    eventIndex++;
               });
          }

          if(op2.toEvent == 0)
          {
               if ((Mathf.Sign(op2.energy) == -1 && energyValue >= Mathf.Abs(op2.energy)) || Mathf.Sign(op2.energy) == 1)
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
          }

          else
          {
               option2.onClick.AddListener(() =>
               {
                    schedule.Insert(scheduleIndex + 1, scheduleKey[op2.toEvent]);
                    schedule.Insert(scheduleIndex + 1, "Dialogue");
                    conversations.Insert(dialogueIndex, op2.response);
                    progressDay();
                    eventIndex++;
               });
          }

          if (op3.toEvent == 0)
          {
               if ((Mathf.Sign(op3.energy) == -1 && energyValue >= Mathf.Abs(op3.energy)) || Mathf.Sign(op3.energy) == 1)
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
          }

          else
          {
               option3.onClick.AddListener(() =>
               {
                    schedule.Insert(scheduleIndex + 1, scheduleKey[op3.toEvent]);
                    conversations.Insert(dialogueIndex, op3.response);
                    progressDay();
                    eventIndex++;
               });
          }

          option1.GetComponentInChildren<TextMeshProUGUI>().SetText(op1.optionText);
          option2.GetComponentInChildren<TextMeshProUGUI>().SetText(op2.optionText);
          option3.GetComponentInChildren<TextMeshProUGUI>().SetText(op3.optionText);
     }
     
     public void setWorkButtons(int hours)
     {
          if(energyValue >= 0.25)
          {
               option1.onClick.AddListener(() =>
               {
                    setValues(Mathf.Round(hours * wage * 1.25f), -10, 0, -0.25f);
                    progressDay();
               });
          }

          else
          {
               option1.interactable = false;
          }

          option2.onClick.AddListener(() =>
          {
               setValues(Mathf.Round(hours * wage), 0, 0, 0);
               progressDay();
          });

          if(energyValue >= 0.6f)
          {
               option3.onClick.AddListener(() =>
               {
                    setValues(Mathf.Round(hours * wage * 1.4f), -20, 0, -0.6f);
                    progressDay();
               });
          }

          else
          {
               option3.interactable = false;
          }

          option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Business as Usual");
          option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Slack Off");
          option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Hard Work");
     }

     public void progressDay()
     {
          scheduleIndex++;
          locationGrabbed = false;
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
          mentalHealthValue = Mathf.Clamp(mentalHealthValue, 0, maxMentalHealth);
          academicsValue = Mathf.Clamp(academicsValue, 0, 4);
          energyValue = Mathf.Clamp(energyValue, 0, 1);
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
          energyValue += energy;
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

     void checkDebuffs()
     {
          if (day == 1)
          {
               mentalHealthValue -= 40;
               maxMentalHealth -= 40;
          }

          if (day == 2)
          {
               maxMentalHealth += 40;
               mentalHealthValue += 40;
          }
     }
}
