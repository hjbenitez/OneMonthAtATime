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
    public GameObject dialogue;

    private CameraManager cameraManager;
    private NarrativeLog log;

    public ButtonScript option1;
    public ButtonScript option2;
    public ButtonScript option3;

    Color colorEnergy;
    Color colorMentalHealth;
    Color colorAcademic;
    Color colorMoney;

    float revertTimer = 0;

    //Options
    public static int textCrawlSpeed = 35;
    public static int fontSize = 33;
    public static int volume = 10;

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
        instance = this;

        if (daySelector != null)
        {
            //setting options
            
            dialogue.GetComponentInChildren<Text>().fontSize = fontSize; ;
            dialogue.GetComponent<WriterAudio>().volume = volume;
            dialogue.GetComponent<Writer>().writingSpeed = textCrawlSpeed;
            
            //sets colors 
            colorEnergy = energyBar.color;
            colorMentalHealth = mentalHealthIcon.color;
            colorAcademic = academicIcon.color;
            colorMoney = moneyText.color;

            menu.SetActive(true);

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

        //Main game screen loop
        if (daySelector != null)
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
                revertTimer += Time.deltaTime / 10;

                moneyText.color = Color.Lerp(moneyText.color, colorMoney, revertTimer); ;
                academicIcon.color = Color.Lerp(academicIcon.color, colorAcademic, revertTimer); ;
                mentalHealthIcon.color = Color.Lerp(mentalHealthIcon.color, colorMentalHealth, revertTimer);
                energyBar.color = Color.Lerp(energyBar.color, colorEnergy, revertTimer); ;
            }

            else
            {
                revertTimer = 0;
            }

        }


        DimVictoria();
    }

    //GETTERS --------------------------------------------
    public ButtonScript GetOption1() { return option1; }
    public ButtonScript GetOption2() { return option2; }
    public ButtonScript GetOption3() { return option3; }
    public Color GetMoneyColor() { return moneyText.color; }
    public Color GetMentalHealthColor() { return mentalHealthIcon.color; }
    public Color GetAcademicColor() { return academicIcon.color; }
    public Color GetEnergyColor() { return energyBar.color; }
    public int GetMental() { return mentalHealthValue; }
    public int GetAcademic() { return academicValue; }
    public int GetMoney() { return moneyValue; }
    public int GetEnergy() { return energyValue; }
    public int GetDay() { return day; }
    public int GetEndIndex() { return endIndex; }
    public int GetFontSize() { return fontSize; }
    public int GetWritingSpeed() { return textCrawlSpeed; }
    public int GetVolume() { return volume; }
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

    public void SetOptions(int textSize, int textSpeed, int textVolume)
    {
        fontSize = textSize;
        textCrawlSpeed = textSpeed;
        volume = textVolume;
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
        if (daySelector != null)
        {
            log.Clear();
        }
    }
}
