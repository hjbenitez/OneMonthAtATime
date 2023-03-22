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

    private static int mentalHealthValue = 80;
    private static int academicValue = 80;
    private static int moneyValue = 500;
    private static int energyValue = 100;

    public int day = 1;

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
        if(daySelector != null)
        {
            daySelector.SetIntegerVariable("day", day);      
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(daySelector != null)
        {
            mentalHealthIcon.fillAmount = (float)mentalHealthValue / 100;
            academicIcon.fillAmount = (float)academicValue / 100;
            energyBar.fillAmount = (float)energyValue / 100;
            moneyText.text = moneyValue.ToString();
        }
    }

    //GETTERS --------------------------------------------
    public int GetMental() { return mentalHealthValue; }
    public int GetAcademic() { return academicValue; }
    public int GetMoney() { return moneyValue; }
    public int GetEnergy() { return energyValue;}
    public int GetDay() { return day; }
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
}
