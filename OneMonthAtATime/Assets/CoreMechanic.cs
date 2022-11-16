using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreMechanic : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI mentalHealth;
    public TextMeshProUGUI academics;

    public Button moneyPlus;
    public Button moneyMinus;

    public Button mentalPlus;
    public Button mentalMinus;

    public Button academicPlus;
    public Button academicMinus;

    public float moneyValue;
    public float mentalHealthValue;
    public float academicsValue;

    // Start is called before the first frame update
    void Start()
    {
        moneyValue = float.Parse(money.text);
        mentalHealthValue = float.Parse(mentalHealth.text);
        academicsValue = float.Parse(academics.text);

        moneyPlus.onClick.AddListener(increaseMoney);
        moneyMinus.onClick.AddListener(decreaseMoney);

        mentalPlus.onClick.AddListener(increaseMental);
        mentalMinus.onClick.AddListener(decreaseMental);

        academicPlus.onClick.AddListener(increaseGPA);
        academicMinus.onClick.AddListener(decreaseGPA);
    }

    // Update is called once per frame
    void Update()
    {
        money.text = moneyValue.ToString();
        mentalHealth.text = mentalHealthValue.ToString();
        academics.text = academicsValue.ToString();
    }


    void increaseMoney()
    {
        moneyValue += 20;
    }

    void decreaseMoney()
    {
        moneyValue -= 20;
    }

    void increaseMental()
    {
        mentalHealthValue += 5;
    }

    void decreaseMental()
    {
        mentalHealthValue -= 5;
    }

    void increaseGPA()
    {
        academicsValue += 0.2f;
    }

    void decreaseGPA()
    {
        academicsValue -= 0.2f;
    }

}
