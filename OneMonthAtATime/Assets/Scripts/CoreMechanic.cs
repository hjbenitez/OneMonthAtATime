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
     int moneyValue;
     public int mentalHealthValue;
     int academicsValue;
     int energyValue = 1;

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
          academicsValue = 75;
          mentalHealthValue = 80;
          //day = 1;

          conversations = new List<string[]>();
          house = GetComponent<HousingSelection>();

          eventIndex = 0;
          maxMentalHealth = 100;
          locationGrabbed = false;

          scheduleKey = new Dictionary<int, string>();
          scheduleKey.Add(1, "1School");
          scheduleKey.Add(2, "2School");
          scheduleKey.Add(3, "Work");
     }

     // Update is called once per frame
     void Update()
     {
          Debug.Log(locationIndex);
          //Updates the UI text to reflect the values every frame
          money.text = moneyValue.ToString();
          healthIcon.fillAmount = mentalHealthValue / 100f;
          academicIcon.fillAmount = academicsValue / 100f;
          energyBar.fillAmount = energyValue/100;

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
                    //DEBUG DAY
                    case 31:
                         currentDay = new Day31();
                         break;

               }

               schedule = currentDay.getSchedule().ToList(); ;
               conversations = currentDay.getDialogue();
               newEvents = currentDay.getEvents();

               //checkDebuffs();

               daySet = true;
               energyValue += 50;
               scheduleIndex = 0;
               dialogueIndex = 0;
               eventIndex = 0;
               locationIndex = 0;
               dialogueSystem.setLocationIndex(0);
               locationGrabbed = false;
          }

          else
          {
               string scheduleString = "";

               foreach (string time in schedule)
               {
                    scheduleString += new string(" " + time);
               }

               Debug.Log(scheduleString);

               locationIndex = dialogueSystem.getLocationIndex();
               currentLocation.sprite = locations[locationIndex];

               if (!locationGrabbed)
               {
                    //locationIndex = int.Parse(schedule[scheduleIndex].Substring(0, 1));
                    //schedule[scheduleIndex] = schedule[scheduleIndex].Remove(0, 1);
                    locationGrabbed = true;
               }

               if (schedule[scheduleIndex] == "Event" && !buttonsSet)
               {
                    chosenEvent = newEvents[eventIndex];

                    schedule.Insert(scheduleIndex + 1, new string("Dialogue")); //after event locationIndex + 

                    setButtonVisibility(chosenEvent.options);
                    setEventButtons(chosenEvent.option1, chosenEvent.option2, chosenEvent.option3);
                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "Work" && !buttonsSet)
               {
                    setButtonVisibility(3);

                    setWorkButtons(currentDay.getHours()); ;

                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "Start" && !buttonsSet)
               {
                    setButtonVisibility(1);
                    setStartButton();
                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "Dialogue")
               {
                    setButtonVisibility(0);
                    dialogueSystem.getDialogue(conversations[dialogueIndex]);
                    dialogueSet = true;
               }

               else if (schedule[scheduleIndex] == "End" && !buttonsSet)
               {
                    setButtonVisibility(1);
                    setSleepButton();
                    buttonsSet = true;
               }

               else if (schedule[scheduleIndex] == "School")
               {
                    schedule.Insert(scheduleIndex + 1, new string("Event")); //event locationIndex + 
                    progressDay();
               }

               else if (schedule[scheduleIndex] == "Freetime")
               {
                    schedule.Insert(scheduleIndex + 1, new string("Event")); //event /locationIndex + 
                    progressDay();
               }

               else if(schedule[scheduleIndex] == "Check")
               {
                    schedule.Insert(scheduleIndex + 1, "Dialogue");
                    conversations.Insert(dialogueIndex, currentDay.getUniqueEvent(schedule.ToArray(), mentalHealthValue, moneyValue, academicsValue, energyValue).ToArray());
                    progressDay();
               }

          }
     }

     public void setEventButtons(Option op1, Option op2, Option op3)
     {
          //Checks if the button doesn't lead to an event
          if (op1.toEvent == 0)
          {
               if ((Mathf.Sign(op1.energy) == -1 && energyValue >= Mathf.Abs(op1.energy)) || Mathf.Sign(op1.energy) == 1)
               {
                    option1.onClick.AddListener(() =>
                    {
                         setValues(op1.valueMoney, op1.valueMentalHealth, op1.valueAcademic, op1.energy);

                         conversations.Insert(dialogueIndex, op1.response);
                         progressDay();
                         eventIndex++;

                         currentDay.addChoice(1);
                    });

                    option1.GetComponent<ButtonScript>().setValue((int)op1.valueMoney, (int)op1.valueMentalHealth, op1.valueAcademic, op1.energy);
               }

               else
               {
                    option1.interactable = false;
               }
          }

          //when the button leads to another event (like Work)
          else
          {
               option1.onClick.AddListener(() =>
               {
                    schedule.Insert(scheduleIndex + 2, scheduleKey[op1.toEvent]);
                    conversations.Insert(dialogueIndex, op1.response);
                    progressDay();
                    eventIndex++;

                    currentDay.addChoice(1);
               });
          }

          //checks if button doesn't lead to an event
          if (op2.toEvent == 0)
          {
               if ((Mathf.Sign(op2.energy) == -1 && energyValue >= Mathf.Abs(op2.energy)) || Mathf.Sign(op2.energy) == 1)
               {
                    option2.onClick.AddListener(() =>
                    {
                         setValues(op2.valueMoney, op2.valueMentalHealth, op2.valueAcademic, op2.energy);

                         conversations.Insert(dialogueIndex, op2.response);
                         progressDay();
                         eventIndex++;

                         currentDay.addChoice(2);
                    });

                    option2.GetComponent<ButtonScript>().setValue((int)op2.valueMoney, (int)op2.valueMentalHealth, op2.valueAcademic, op2.energy);
               }

               else
               {
                    option2.interactable = false;
               }
          }

          //when the button leads to another event (like Work)
          else
          {
               option2.onClick.AddListener(() =>
               {
                    schedule.Insert(scheduleIndex + 2, scheduleKey[op2.toEvent]); //Gets and sets the event this button leads to 
                    conversations.Insert(dialogueIndex, op2.response); //inserst the response into the game
                    progressDay();
                    eventIndex++;

                    currentDay.addChoice(2);
               });
          }

          //checks if button doesn't lead to an event
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

                         currentDay.addChoice(3);
                    });

                    option3.GetComponent<ButtonScript>().setValue((int)op3.valueMoney, (int)op3.valueMentalHealth, op3.valueAcademic, op3.energy);
               }

               else
               {
                    option3.interactable = false;
               }
          }

          //when the button leads to another event (like Work)
          else
          {
               option3.onClick.AddListener(() =>
               {
                    schedule.Insert(scheduleIndex + 2, scheduleKey[op3.toEvent]);
                    conversations.Insert(dialogueIndex, op3.response);
                    progressDay();
                    eventIndex++;

                    currentDay.addChoice(3);
               });
          }

          option1.GetComponentInChildren<TextMeshProUGUI>().SetText(op1.optionText);
          option2.GetComponentInChildren<TextMeshProUGUI>().SetText(op2.optionText);
          option3.GetComponentInChildren<TextMeshProUGUI>().SetText(op3.optionText);
     }

     public void setWorkButtons(int hours)
     {
          if (energyValue >= 0.6f)
          {
               option1.onClick.AddListener(() =>
               {
                    setValues((int)Mathf.Round(hours * wage * 1.4f), -20, 0, -60);
                    progressDay();
               });

               option1.GetComponent<ButtonScript>().setValue((int)Mathf.Round(hours * wage * 1.4f), -20, 0, -60);
          }

          else
          {
               option1.interactable = false;
          }

          if (energyValue >= 0.25)
          {
               option2.onClick.AddListener(() =>
               {
                    setValues((int)Mathf.Round(hours * wage * 1.25f), -10, 0, -25);
                    progressDay();
               });

               option2.GetComponent<ButtonScript>().setValue((int)Mathf.Round(hours * wage * 1.25f), -10, 0, -25);
          }

          else
          {
               option2.interactable = false;
          }

          option3.onClick.AddListener(() =>
          {
               setValues((int)Mathf.Round(hours * wage), 0, 0, 0);
               progressDay();
          });

          option3.GetComponent<ButtonScript>().setValue((int)Mathf.Round(hours * wage), 0, 0, 0);


          option1.GetComponentInChildren<TextMeshProUGUI>().SetText("Hard Work");
          option2.GetComponentInChildren<TextMeshProUGUI>().SetText("Business as Usual");
          option3.GetComponentInChildren<TextMeshProUGUI>().SetText("Slack Off");
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
          academicsValue = Mathf.Clamp(academicsValue, 0, 100);
          energyValue = Mathf.Clamp(energyValue, 0, 100);
     }

     //resets buttons to blanks when clicked
     public void removeAllListners()
     {
          GameObject myEventSystem = GameObject.Find("EventSystem");
          myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

          option1.onClick.RemoveAllListeners();
          option2.onClick.RemoveAllListeners();
          option3.onClick.RemoveAllListeners();

          option1.interactable = true;
          option2.interactable = true;
          option3.interactable = true;

          option1.GetComponent<ButtonScript>().setValue(0, 0, 0, 0);
          option2.GetComponent<ButtonScript>().setValue(0, 0, 0, 0);
          option3.GetComponent<ButtonScript>().setValue(0, 0, 0, 0);

          buttonsSet = false;
     }

     public void setValues(int money, int mentalHealth, int academics, int energy)
     {
          moneyValue += money;
          mentalHealthValue += mentalHealth;
          academicsValue += academics;
          energyValue += energy;
     }

     public void setButtonVisibility(int options)
     {
          if (options == 1)
          {
               option1.gameObject.SetActive(true);
               option2.gameObject.SetActive(false);
               option3.gameObject.SetActive(false);
          }

          else if (options == 2)
          {
               option1.gameObject.SetActive(true);
               option2.gameObject.SetActive(true);
               option3.gameObject.SetActive(false);
          }

          else if (options == 3)
          {
               option1.gameObject.SetActive(true);
               option2.gameObject.SetActive(true);
               option3.gameObject.SetActive(true);
          }

          else
          {
               option1.gameObject.SetActive(false);
               option2.gameObject.SetActive(false);
               option3.gameObject.SetActive(false);
          }
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
