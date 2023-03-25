using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Flowchart daySelector;

    private static int mentalHealthValue = 75;
    private static int academicValue = 75;
    private static int moneyValue = 200;
    private static int energyValue = 100;
    private static int endIndex = 0;

    public int day = 1;
    int dim = 0;

    public Image mentalHealthIcon;
    public Image academicIcon;
    public Image energyBar;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
    }

    private void OnEnable()
    {
        if (daySelector != null)
        {
            daySelector.SetIntegerVariable("day", day);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //dim = daySelector.GetIntegerVariable("dim");
        DimVictoria();

        if (daySelector != null)
        {
            mentalHealthIcon.fillAmount = (float)mentalHealthValue / 100;
            academicIcon.fillAmount = (float)academicValue / 100;
            energyBar.fillAmount = (float)energyValue / 100;
            moneyText.text = moneyValue.ToString();

            daySelector.SetIntegerVariable("energy", energyValue);
        }
    }

    //GETTERS --------------------------------------------
    public int GetMental() { return mentalHealthValue; }
    public int GetAcademic() { return academicValue; }
    public int GetMoney() { return moneyValue; }
    public int GetEnergy() { return energyValue; }
    public int GetDay() { return day; }
    public int GetEndIndex() { return endIndex; }
    //----------------------------------------------------
    public void NextDay() { day++; daySelector.SetIntegerVariable("day", day); }
    public void SetValues(int mentalHealh, int academics, int money, int energy)
    {
        mentalHealthValue += mentalHealh;
        academicValue += academics;
        moneyValue += money;
        energyValue += energy;
    }

    public void WorkPay(int hours, float multiplier)
    {
        moneyValue += (int)Mathf.Round(multiplier * 15.5f * hours);
    }

    public void SetEndIndex(int index)
    {
        endIndex = index;
    }

    public void DimVictoria()
    {
        GameObject speaker = GameObject.Find("UniversalNameText");
        GameObject victoria = GameObject.Find("Victoria holder");

        GameObject emotion = null;
        if(speaker != null)
        {
            Text name = speaker.GetComponent<Text>();

            if (victoria != null)
            {
                for (int i = 0; i < victoria.transform.childCount; i++)
                {
                    if (victoria.transform.GetChild(i).gameObject.activeSelf)
                    {
                        emotion = victoria.transform.GetChild(i).gameObject;
                    }
                }
            
                if (name.text == "Victoria")
                {
                    emotion.GetComponent<Image>().color = Color.white;
                }

                else
                {
                    emotion.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
                }
            }
        }
    }
}
