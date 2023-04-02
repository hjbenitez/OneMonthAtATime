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

    public GameObject menu;

    private CameraManager cameraManager;
    private NarrativeLog log;

    public ButtonScript option1;
    public ButtonScript option2;
    public ButtonScript option3;

    Color colorEnergy = new Color(0.97f, 0.76f, 0.63f); //orangey colour
    Color colorIcon = Color.white;

    private static int mentalHealthValue = 75;
    private static int academicValue = 75;
    private static int moneyValue = 200;
    private static int energyValue = 100;

    public float guiFade = 0;

    private static int endIndex = 0;

    public static int day = 1;

    public Image mentalHealthIcon;
    public Image academicIcon;
    public Image energyBar;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);

        instance = this;
        if (daySelector != null)
        {
            mentalHealthIcon.fillAmount = (float)mentalHealthValue / 100;
            academicIcon.fillAmount = (float)academicValue / 100;
            energyBar.fillAmount = (float)energyValue / 100;
            moneyText.text = moneyValue.ToString();
        }
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
        log = FindObjectOfType<NarrativeLog>();
        cameraManager = FindObjectOfType<CameraManager>();
        //Clamp values
        moneyValue = (int)Mathf.Clamp(moneyValue, -500, 999999);
        mentalHealthValue = (int)Mathf.Clamp(mentalHealthValue, 0, 100);
        academicValue = (int)Mathf.Clamp(academicValue, 0, 100);
        energyValue = (int)Mathf.Clamp(energyValue, 0, 100);

        //Continually sets the screen fade alpha 
        if (cameraManager != null)
        {
            guiFade = cameraManager.fadeAlpha;
        }

        //Main game screen loop
        if (daySelector != null)
        {
            daySelector.SetIntegerVariable("energy", energyValue);

            if (guiFade > 0.99f)
            {
                mentalHealthIcon.fillAmount = (float)mentalHealthValue / 100;
                academicIcon.fillAmount = (float)academicValue / 100;
                energyBar.fillAmount = (float)energyValue / 100;
                moneyText.text = moneyValue.ToString();
            }

            if (!(option1.GetHovering() || option2.GetHovering() || option3.GetHovering()))
            {
                moneyText.color = colorIcon;
                academicIcon.color = colorIcon;
                mentalHealthIcon.color = colorIcon;
                energyBar.color = colorEnergy;
            }
        }


        DimVictoria();
    }

    //GETTERS --------------------------------------------
    public ButtonScript GetOption1() { return option1; }
    public ButtonScript GetOption2() { return option2; }
    public ButtonScript GetOption3() { return option3; }
    public int GetMental() { return mentalHealthValue; }
    public int GetAcademic() { return academicValue; }
    public int GetMoney() { return moneyValue; }
    public int GetEnergy() { return energyValue; }
    public int GetDay() { return day; }
    public int GetEndIndex() { return endIndex; }
    //----------------------------------------------------
    public void NextDay() { day++; daySelector.SetIntegerVariable("day", day); }
    public void SkipToDay5() { day += 5; daySelector.SetIntegerVariable("day", day); }
    public void SetValues(int money, int mentalHealh, int academics, int energy)
    {
        mentalHealthValue += mentalHealh;
        academicValue += academics;
        moneyValue += money;
        energyValue += energy;
    }

    public void RemoveListeners()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        option1.GetComponent<Button>().onClick.RemoveAllListeners();
        option2.GetComponent<Button>().onClick.RemoveAllListeners();
        option3.GetComponent<Button>().onClick.RemoveAllListeners();

        option1.ResetValues();
        option2.ResetValues();
        option3.ResetValues();
    }

    public void WorkPay(int hours, float multiplier)
    {
        moneyValue += (int)Mathf.Round(multiplier * 15.5f * hours);
    }

    public void SetEndIndex(int index)
    {
        endIndex = index;
    }

    public void SetGUIFade(float fade)
    {
        guiFade = fade;
    }

    public void DimVictoria()
    {
        GameObject speaker = GameObject.Find("UniversalNameText");
        GameObject victoria = GameObject.Find("Victoria holder");

        GameObject emotion = null;
        if (speaker != null)
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

    private void OnDisable()
    {
        log.Clear();
    }
}
