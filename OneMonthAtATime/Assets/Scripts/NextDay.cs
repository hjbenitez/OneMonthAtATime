using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
     bool transitioningStart;
     bool transitioningEnd;
     float transitionTime;
     public Image transitionScreen;

     // Start is called before the first frame update
     void Start()
     {
          transitioningEnd = false;
          transitioningStart = true;
          transitionTime = 0;
          transitionScreen.color = new Color(0, 0, 0, 1);
          transitionScreen.gameObject.SetActive(true);
     }

     // Update is called once per frame
     void Update()
     {
          if (transitioningStart)
          {
               transitionTime += Time.deltaTime;
               transitionScreen.color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), Mathf.PingPong(transitionTime / 2, 1));

               if (transitionTime >= 2)
               {
                    transitionScreen.gameObject.SetActive(false);
                    transitioningStart = false;
               }
          }

          if (transitioningEnd)
          {
               transitionTime += Time.deltaTime;
               transitionScreen.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), Mathf.PingPong(transitionTime/2, 1));

               if(transitionTime >= 2)
               {
                    SceneManager.LoadScene("Game");
               }
          }
     }

     public void loadNextDay()
     {
          transitionScreen.gameObject.SetActive(true); 
          transitioningEnd = true;
          transitionTime = 0;
     }
}
