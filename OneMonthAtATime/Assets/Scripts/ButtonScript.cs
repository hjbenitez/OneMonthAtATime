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

     float flashTime = 0;

     Color colorEnergy;
     Color colorIcon;
     Color[] red;
     Color[] green;

     bool hovering;
     // Start is called before the first frame update
     void Start()
     {
          hovering = false;

          coreMechanic = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CoreMechanic>();

          //Setting colors
          colorEnergy = new Color(0.97f, 0.76f, 0.63f); //orangey colour
          colorIcon = Color.white;

          red = new Color[] {
               new Color(0.83f, 0.54f, 0.53f), //Light Red
               new Color(0.76f, 0.28f, 0.24f), //Medium Red
               new Color(0.65f, 0.04f, 0)}; //Bright Red

          green = new Color[] {
               new Color(0.61f, 0.8f, 0.5f),
               new Color(0.44f, 0.76f, 0.24f),
               new Color(0.26f, 0.61f, 0.05f)
          };
     }

     // Update is called once per frame
     void Update()
     {
          if (hovering)
          {
               flashTime += Time.deltaTime;

               //MONEY -------------------------------------------
               if (Mathf.Sign(moneySign) == 1)
               {
                    if (moneySign > 0 && moneySign < 90)
                    {
                         coreMechanic.money.color = Color.Lerp(colorIcon, green[0], Mathf.PingPong(flashTime, 1));
                    }

                    else if (moneySign >= 90 && moneySign < 105)
                    {
                         coreMechanic.money.color = Color.Lerp(colorIcon, green[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (moneySign >= 105)
                    {
                         coreMechanic.money.color = Color.Lerp(colorIcon, green[2], Mathf.PingPong(flashTime, 1));
                    }
               }

               if (moneySign == 0)
               {
                    coreMechanic.money.color = colorIcon;
               }

               //MENTAL ---------------------------------------------------------------------------------------------------------
               if (Mathf.Sign(mentalHealthSign) == 1)
               {
                    if (mentalHealthSign >= 15)
                    {
                         coreMechanic.healthIcon.color = Color.Lerp(colorIcon, green[2], Mathf.PingPong(flashTime, 1));
                    }

                    else if (mentalHealthSign >= 5)
                    {
                         coreMechanic.healthIcon.color = Color.Lerp(colorIcon, green[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (mentalHealthSign > 0)
                    {
                         coreMechanic.healthIcon.color = Color.Lerp(colorIcon, green[0], Mathf.PingPong(flashTime, 1));
                    }
               }

               else if (Mathf.Sign(mentalHealthSign) == -1)
               {
                    if (mentalHealthSign <= -15)
                    {
                         coreMechanic.healthIcon.color = Color.Lerp(colorIcon, red[2], Mathf.PingPong(flashTime, 1));
                    }

                    else if (mentalHealthSign <= -5)
                    {
                         coreMechanic.healthIcon.color = Color.Lerp(colorIcon, red[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (mentalHealthSign < 0)
                    {
                         coreMechanic.healthIcon.color = Color.Lerp(colorIcon, red[0], Mathf.PingPong(flashTime, 1));
                    }
               }

               else if (mentalHealthSign == 0)
               {
                    coreMechanic.healthIcon.color = colorIcon;
               }

               //ACADEMIC ---------------------------------------------------------------------------------------------------------
               if (Mathf.Sign(academicSign) == 1)
               {
                    if (academicSign >= 15)
                    {
                         coreMechanic.academicIcon.color = Color.Lerp(colorIcon, green[2], Mathf.PingPong(flashTime, 1));
                    }

                    else if (academicSign >= 5)
                    {
                         coreMechanic.academicIcon.color = Color.Lerp(colorIcon, green[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (academicSign > 0)
                    {
                         coreMechanic.academicIcon.color = Color.Lerp(colorIcon, green[0], Mathf.PingPong(flashTime, 1));
                    }
               }

               else if (Mathf.Sign(academicSign) == -1)
               {
                    if (academicSign <= -15)
                    {
                         coreMechanic.academicIcon.color = Color.Lerp(colorIcon, red[2], Mathf.PingPong(flashTime, 1));
                    }

                    else if (academicSign <= -5)
                    {
                         coreMechanic.academicIcon.color = Color.Lerp(colorIcon, red[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (academicSign < 0)
                    {
                         coreMechanic.academicIcon.color = Color.Lerp(colorIcon, red[0], Mathf.PingPong(flashTime, 1));
                    }
               }

               else if (academicSign == 0)
               {
                    coreMechanic.academicIcon.color = colorIcon;
               }

               //ENERGY ---------------------------------------------------------------------------------------------------------
               if (Mathf.Sign(energySign) == 1)
               {
                    if (energySign >= 40)
                    {
                         coreMechanic.energyBar.color = Color.Lerp(colorEnergy, green[2], Mathf.PingPong(flashTime, 1));
                    }

                    else if (energySign >= 20)
                    {
                         coreMechanic.energyBar.color = Color.Lerp(colorEnergy, green[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (academicSign > 0)
                    {
                         coreMechanic.energyBar.color = Color.Lerp(colorEnergy, green[0], Mathf.PingPong(flashTime, 1));
                    }
               }

               else if (Mathf.Sign(energySign) == -1)
               {
                    if (energySign <= -40)
                    {
                         coreMechanic.energyBar.color = Color.Lerp(colorEnergy, red[2], Mathf.PingPong(flashTime, 1));
                    }

                    else if (energySign <= -20)
                    {
                         coreMechanic.energyBar.color = Color.Lerp(colorEnergy, red[1], Mathf.PingPong(flashTime, 1));
                    }

                    else if (energySign < 0)
                    {
                         coreMechanic.energyBar.color = Color.Lerp(colorEnergy, red[0], Mathf.PingPong(flashTime, 1));
                    }
               }

               else if (energySign == 0)
               {
                    coreMechanic.energyBar.color = colorEnergy;
               }
          }
     }

     public void onHoverEnter()
     {
          hovering = true;


          if (Mathf.Sign(moneySign) == -1)
          {
               coreMechanic.money.color = Color.red;
          }

          if (moneySign == 0)
          {
               coreMechanic.money.color = colorIcon;
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
          if (coreMechanic != null)
          {
               coreMechanic.money.color = colorIcon;
               coreMechanic.academicIcon.color = colorIcon;
               coreMechanic.healthIcon.color = colorIcon;
               coreMechanic.energyBar.color = colorEnergy;
               hovering = false;

               flashTime = 0;
          }
     }

     public void setValue(int money, int health, float academic, float energy)
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
