using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    public TextMeshProUGUI date;

    public TextMeshProUGUI importantInfo;

    Dictionary<int, string> importantDates;
    List<int> keyTracker;
    int infoIndex;
    bool lastBill;

    // Start is called before the first frame update
    void Start()
    {

        infoIndex = 0;
        lastBill = false;

        importantDates = new Dictionary<int, string>();
        importantDates.Add(7, "Groceries");
        importantDates.Add(14, "Groceries");
        importantDates.Add(21, "Groceries");
        importantDates.Add(28, "Groceries");
        importantDates.Add(30, "Rent");
        importantDates.Add(99999, "$&%(#(");

        keyTracker = new List<int>(importantDates.Keys);

    }

    // Update is called once per frame
    void Update()
    {
        //Update the date as the game progress
        date.SetText("Nov " + GameManager.instance.GetDay() + ", 2023");

        //Update important information
        getNextImportantDate();
    }

    //used to update the important information box
    void getNextImportantDate()
    {

        if (!lastBill)
        {
            int currentDay = GameManager.instance.GetDay();

            if (currentDay == keyTracker[infoIndex])
            {
                string bill = importantDates[currentDay];
                importantInfo.SetText("Today, " + bill + " is due.");
            }

            if (currentDay < keyTracker[infoIndex])
            {
                string bill = importantDates[keyTracker[infoIndex]];
                int nextBillDate = keyTracker[infoIndex] - currentDay;

                if (nextBillDate == 1)
                {
                    importantInfo.SetText(bill + " is due tomorrow.");
                }

                else
                {
                    importantInfo.SetText(bill + " is due in " + nextBillDate + " days.");
                }
            }

            if (currentDay > keyTracker[infoIndex])
            {
                infoIndex++;
            }

            if (currentDay == 30)
            {
                lastBill = true;
                importantInfo.SetText("Rent is due today...");
            }
        }
    }
}
