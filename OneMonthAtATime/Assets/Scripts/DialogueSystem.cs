using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
     /*PROFILE PIC INDEX MEANINGS
     *0 = angry
     *1 = confused
     *2 = happy
     *3 = neutral
     *4 = sad
     *5 = sighing
     *6 = tired
     *7 = fear
     *8 = disgust
     *9 = surpirse
     */
     string[] dialogue;
     int index;

     public TextMeshProUGUI dialogueBox;
     public TextMeshProUGUI speakerName;

     public Image victoriaPic;
     public Image npcPic;

     public CoreMechanic coreMechanic;
     public Image dialoguePrompt;

     int pfpIndex;
     int charIndex;

     int lastNum;
     // Start is called before the first frame update
     void Start()
     {
          pfpIndex = 0;
          npcPic.gameObject.SetActive(false);

          lastNum = 0;
     }

     // Update is called once per frame
     void Update()
     {
          setSpeakingCharacter(charIndex, pfpIndex);

          //find out when the NPC character leaves the conversation
          if(dialogue != null)
          {
               for(int i = 0; i < dialogue.Length; i++)
               {
                    int found = int.Parse(dialogue[i].Substring(0, 1));

                    if (found == 1 && i > lastNum)
                    {
                         lastNum = i;
                    }
               }
          }

          Debug.Log(lastNum + " ---- " + index);
          
          if ((Input.GetKeyDown(KeyCode.Space) || coreMechanic.playerChose) && coreMechanic.getCurrentTime() == "Dialogue" && coreMechanic.dialogueSet)
          {
               //remove NPC character after conversation
               if (index >=  lastNum)
               {
                    npcPic.gameObject.SetActive(false);
               }

               setDialogue(dialogue[index]);
               index++;
               dialoguePrompt.gameObject.SetActive(true);

               //when dialogue is done
               if (index == dialogue.Length)
               {
                    coreMechanic.progressDay();
                    coreMechanic.nextDialogue();
                    index = 0;
                    lastNum = 0;
                    coreMechanic.dialogueSet = false;
                    dialoguePrompt.gameObject.SetActive(false);
               }

               if (coreMechanic.playerChose)
               {
                    coreMechanic.playerChose = false;
               }
          }
     }

     void setDialogue(string text)
     {
          getCharacter(text);

          if (text != null || text != "")
          {
               text = text.Remove(0, 2);
          }
          dialogueBox.text = text;
     }

     public void getDialogue(string[] chain)
     {
          dialogue = chain;
     }

     void setSpeakingCharacter(int character, int pfp)
     {
          if (character == 0)
          {
               victoriaPic.sprite = coreMechanic.victoria[pfp];               
               speakerName.SetText("Victoria");

               victoriaPic.color = Color.white;
               npcPic.color = Color.gray;
          }

          else if (character == 1)
          {
               npcPic.sprite = coreMechanic.ashley[pfp];
               speakerName.SetText("Ashley");
               npcPic.gameObject.SetActive(true);

               victoriaPic.color = Color.gray;
               npcPic.color = Color.white;
          }

          else
          {
               speakerName.SetText("One Off");
               victoriaPic.color = Color.gray;
               npcPic.color = Color.gray;
          }
     }

     void getCharacter(string dialogue)
     {
          charIndex = int.Parse(dialogue.Substring(0, 1));
          pfpIndex = int.Parse(dialogue.Substring(1, 1));
     }
}