using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EndingSelector : MonoBehaviour
{
    public Flowchart endingChart;

    int moneyFinal;
    int mentalFinal;
    int academicFinal;

    // Start is called before the first frame update
    void Start()
    {
        moneyFinal = GameManager.instance.GetMoney();
        mentalFinal = GameManager.instance.GetMental();
        academicFinal = GameManager.instance.GetAcademic();
    }

    // Update is called once per frame
    void Update()
    {
        endingChart.SetIntegerVariable("money", moneyFinal);
        endingChart.SetIntegerVariable("mental", mentalFinal);
        endingChart.SetIntegerVariable("academic", academicFinal);
    }
}
