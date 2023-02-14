using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    CoreMechanic coreMechanic;

    public int moneySign = 1;
    public float academicSign = 1f;
    public int mentalHealthSign = 1;
    public float energySign = 1f;

    // Start is called before the first frame update
    void Start()
    {
        coreMechanic = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CoreMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moneySign != 0)
        {
            moneySign = (int) Mathf.Sign(moneySign);
        }

        if(academicSign != 0)
        {
            academicSign = (int)Mathf.Sign(academicSign);
        }

        if (mentalHealthSign != 0)
        {
            mentalHealthSign = (int)Mathf.Sign(mentalHealthSign);
        }

        if(energySign != 0)
        {
            energySign = (int)Mathf.Sign(energySign);
        }
    }

    public void onHoverEnter()
    {
        Debug.Log(gameObject.name + " : " + moneySign + " " + academicSign + " " + mentalHealthSign + " " + energySign);

        //MONEY -------------------------------------------
        if (moneySign == 1)
        {
            coreMechanic.money.color = Color.green;
        }

        if(moneySign == -1)
        {
            coreMechanic.money.color = Color.red;
        }

        if (moneySign == 0)
        {
            coreMechanic.money.color = Color.white;
        }

        //ACADEMIC -------------------------------------------
        if (academicSign == 1)
        {
            coreMechanic.academicIcon.color = Color.green;
        }

        if (academicSign == -1)
        {
            coreMechanic.academicIcon.color = Color.red;
        }

        if (academicSign == 0)
        {
            coreMechanic.academicIcon.color = Color.white;
        }

        //MENTAL HEALTH ---------------------------------------
        if (mentalHealthSign == 1)
        {
            coreMechanic.healthIcon.color = Color.green;
        }

        if (mentalHealthSign == -1)
        {
            coreMechanic.healthIcon.color = Color.red;
        }

        if (mentalHealthSign == 0)
        {
            coreMechanic.healthIcon.color = Color.white;
        }

        //ENERGY -------------------------------------------
        if (energySign == 1)
        {
            coreMechanic.energyBar.color = Color.green;
        }

        if (energySign == -1)
        {
            coreMechanic.energyBar.color = Color.red;
        }

        if (energySign == 0)
        {
            coreMechanic.energyBar.color = Color.white;
        }
    }

    public void onHoverExit()
    {
        coreMechanic.money.color = Color.white;
        coreMechanic.academicIcon.color = Color.white;
        coreMechanic.healthIcon.color = Color.white;
        coreMechanic.energyBar.color = Color.white;
    }

    public void setValue(int money,  int health, float academic, float energy)
    {
        moneySign = money;
        academicSign = academic;
        mentalHealthSign = health;
        energySign = energy;
    }
    private void OnDisable()
    {
        onHoverExit();
    }
}
