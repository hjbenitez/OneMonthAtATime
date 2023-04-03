using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    GameManager gameManager;

    public int moneySign = 0;
    public int academicSign = 0;
    public int mentalHealthSign = 0;
    public int energySign = 0;

    float flashTime = 0;

    int maxEnergy = 30;
    int maxResource = 20;
    int maxMoney = 200;

    Color lastColorMH;
    private bool hovering;
    // Start is called before the first frame update
    void Start()
    {
        hovering = false;
        gameManager = GameManager.instance;

        lastColorMH = gameManager.GetMentalHealthColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (hovering)
        {
            flashTime += Time.deltaTime/4;

            float energyHoverColor = Mathf.Abs((float)energySign / (float)maxEnergy);
            float moneyHoverColor = Mathf.Abs((float)moneySign / (float)maxMoney);
            float healthHoverColor = Mathf.Abs((float)mentalHealthSign / (float)maxResource);
            float academicHoverColor = Mathf.Abs((float)academicSign / (float)maxResource);

            //ENERGY -------------------------------------------------
            if (energySign != 0)
            {
                if (Mathf.Sign(energySign) == -1)
                {
                    Color energyRedFlash = new Color(1f, 1f - energyHoverColor, 1f - energyHoverColor);
                    gameManager.energyBar.color = Color.Lerp(gameManager.GetEnergyColor(), energyRedFlash, flashTime);
                }

                else if (Mathf.Sign(energySign) == 1)
                {
                    Color energyGreenFlash = new Color(1f - energyHoverColor, 1f, 1f - energyHoverColor);
                    gameManager.energyBar.color = Color.Lerp(gameManager.GetEnergyColor(), energyGreenFlash, flashTime);
                }
            }

            //MONEY ---------------------------------------------------
            if (moneySign != 0)
            {
                if (Mathf.Sign(moneySign) == -1)
                {
                    Color moneyRedFlash = new Color(1f, 1f - moneyHoverColor, 1f - moneyHoverColor);
                    gameManager.moneyText.color = Color.Lerp(gameManager.GetMoneyColor(), moneyRedFlash, flashTime);
                }

                else if (Mathf.Sign(moneySign) == 1)
                {
                    Color moneyGreenFlash = new Color(1f - moneyHoverColor, 1f, 1f - moneyHoverColor);
                    gameManager.moneyText.color = Color.Lerp(gameManager.GetMoneyColor(), moneyGreenFlash, flashTime);
                }
            }

            //MENTAL HEALTH ---------------------------------------------------
            if (mentalHealthSign != 0)
            {
                if (Mathf.Sign(mentalHealthSign) == -1)
                {
                    Color healthRedFlash = new Color(1f, 1f - healthHoverColor, 1f - healthHoverColor);
                    gameManager.mentalHealthIcon.color = Color.Lerp(gameManager.GetMentalHealthColor(), healthRedFlash, flashTime);
                }

                else if (Mathf.Sign(mentalHealthSign) == 1)
                {
                    Color healthGreenFlash = new Color(1f - healthHoverColor, 1f, 1f - healthHoverColor);
                    gameManager.mentalHealthIcon.color = Color.Lerp(gameManager.GetMentalHealthColor(), healthGreenFlash, flashTime);
                }

                //lastColorMH = gameManager.GetMentalHealthColor();
            }

            //ACADEMIC ---------------------------------------------------
            if (academicSign != 0)
            {
                if (Mathf.Sign(academicSign) == -1)
                {
                    Color academicRedFlash = new Color(1f, 1f - academicHoverColor, 1f - academicHoverColor);
                    gameManager.academicIcon.color = Color.Lerp(gameManager.GetAcademicColor(), academicRedFlash, flashTime);
                }

                else if (Mathf.Sign(academicSign) == 1)
                {
                    Color academicGreenFlash = new Color(1f - academicHoverColor, 1f, 1f - academicHoverColor);
                    gameManager.academicIcon.color = Color.Lerp(gameManager.GetAcademicColor(), academicGreenFlash, flashTime);
                }
            }
        }
    }

    public void OnHoverEnter()
    {
        hovering = true;
    }
    public void OnHoverExit()
    {
        /*
        GameManager.instance.moneyText.color = gameManager.GetMoneyColor();
        GameManager.instance.academicIcon.color = gameManager.GetAcademicColor();
        GameManager.instance.mentalHealthIcon.color = gameManager.GetMentalHealthColor();
        GameManager.instance.energyBar.color = gameManager.GetEnergyColor();
        */
        hovering = false;

        flashTime = 0;
    }

    public void setValue(int money, int health, int academic, int energy)
    {
        moneySign = money;
        academicSign = academic;
        mentalHealthSign = health;
        energySign = energy;
    }

    public void ResetValues()
    {
        moneySign = 0;
        energySign = 0;
        mentalHealthSign = 0;
        academicSign = 0;
    }

    public bool GetHovering()
    {
        return hovering;
    }

    public void OnDisable()
    {
        hovering = false;
    }
}
