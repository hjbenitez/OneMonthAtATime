using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateUI : MonoBehaviour
{

          public CoreMechanic coreMechanic;

          public TextMeshProUGUI date;

          public TextMeshProUGUI importantInfo;
          Dictionary<int, Dictionary<int, string>> importantDates;

          // Start is called before the first frame update
          void Start()
          {
                    importantDates = new Dictionary<int, Dictionary<int, string>>();
                    importantDates.Add(0, new Dictionary<int, string> { { 7, "Grcoery" } });
                    importantDates.Add(0, new Dictionary<int, string> { { 14, "Grcoery" } });
                    importantDates.Add(0, new Dictionary<int, string> { { 21, "Grcoery" } });
                    importantDates.Add(0, new Dictionary<int, string> { { 28, "Grcoery" } });
          }

          // Update is called once per frame
          void Update()
          {
                    //Update the date as the game progress
                    date.SetText("Nov " + coreMechanic.getDay() + ", 2023");
          }

          void getNextImportantDate()
          {
                    int day = coreMechanic.getDay();
                    string bill = null;

                    importantInfo.SetText(bill + " is due in " + " days");
          }
}
