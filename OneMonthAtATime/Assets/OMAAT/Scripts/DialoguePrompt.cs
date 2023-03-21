using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePrompt : MonoBehaviour
{
     RectTransform rectTransform;
     Vector2 startingPosition;
     float timer;
     // Start is called before the first frame update
     void Start()
     {
          timer = 0;

          rectTransform = GetComponent<RectTransform>();
          startingPosition = rectTransform.position;
     }

     // Update is called once per frame
     void Update()
     {
          timer += Time.deltaTime;

          rectTransform.position = Vector2.Lerp(startingPosition, startingPosition + new Vector2(0, 15), Mathf.PingPong(timer, 1)); ;
     }

     private void OnDisable()
     {
          timer = 0;
          rectTransform.position = startingPosition;
     }
}
