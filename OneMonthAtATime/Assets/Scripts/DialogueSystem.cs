using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
     //0 0 00 00 00 
     //Speaker Victoria NPC1 NPC2 NPC3
     //Character - Emotion

     /*Speaker Index
      * 0 = Victoria
      * 1 = Ashley
      * 2 = Jackson
      * 3 = Olivia
      * 4 = Chris
      * 5 = Harry
      */

     /*CHARACTER INDEX
      * 0 = No Character
      * 1 = Ashley
      * 2 = Jackson
      * 3 = Olivia
      * 4 = Chris
      * 5 = Harry
      */

     /*EMOTION INDEX
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
     Dictionary<int, string> charactersNames;
     int[] npcSlots;

     string[] dialogue;
     int index;

     public TextMeshProUGUI dialogueBox;
     public TextMeshProUGUI speakerName;

     public Image victoriaPic;
     public Image[] npcPics;

     public CoreMechanic coreMechanic;
     public Image dialoguePrompt;

     int pfpIndex;
     int charIndex;

     int lastNum;
     // Start is called before the first frame update
     void Start()
     {
          pfpIndex = 0;
          lastNum = 0;

          npcPics[0].gameObject.SetActive(false);
          npcPics[1].gameObject.SetActive(false);
          npcPics[2].gameObject.SetActive(false);

          npcSlots = new int[] { 0, 0, 0 };

          charactersNames = new Dictionary<int, string>();
          charactersNames.Add(0, "Victoria");
          charactersNames.Add(1, "Ashley");
          charactersNames.Add(2, "Jackson");
          charactersNames.Add(3, "Olivia");
          charactersNames.Add(4, "Chris");
          charactersNames.Add(5, "Harry");
          charactersNames.Add(9, "One Off");
     }

     // Update is called once per frame
     void Update()
     {
          //setSpeakingCharacter(charIndex, pfpIndex);

          /*find out when the NPC character leaves the conversation
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
          */


          if ((Input.GetKeyDown(KeyCode.Space) || coreMechanic.playerChose) && coreMechanic.getCurrentTime() == "Dialogue" && coreMechanic.dialogueSet)
          {
               /*remove NPC character after conversation
               if (index >=  lastNum)
               {
                    npcPics[0].gameObject.SetActive(false);
               }
               */

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
          setCharacters(text);

          if (text != null || text != "")
          {
               text = text.Remove(0, 12);
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
               npcPics[0].color = Color.gray;
          }

          else if (character == 1)
          {
               npcPics[0].sprite = coreMechanic.ashley[pfp];
               speakerName.SetText("Ashley");
               npcPics[0].gameObject.SetActive(true);

               victoriaPic.color = Color.gray;
               npcPics[0].color = Color.white;
          }

          else
          {
               speakerName.SetText("One Off");
               victoriaPic.color = Color.gray;
               npcPics[0].color = Color.gray;
          }
     }

     void getCharacter(string dialogue)
     {
          charIndex = int.Parse(dialogue.Substring(0, 1));
          pfpIndex = int.Parse(dialogue.Substring(1, 1));
     }

     void setCharacters(string dialogue)
     {
          int speaker = int.Parse(dialogue.Substring(0, 1)); //get the character that is speaking

          int victoria = int.Parse(dialogue.Substring(2, 1)); //set victoria's emotion/reaction

          //get the NPC's for the scene
          Vector2[] npcs = { 
               new Vector2(int.Parse(dialogue.Substring(4, 1)), int.Parse(dialogue.Substring(5, 1))),
               new Vector2(int.Parse(dialogue.Substring(7, 1)), int.Parse(dialogue.Substring(8, 1))),
               new Vector2(int.Parse(dialogue.Substring(10, 1)), int.Parse(dialogue.Substring(11, 1)))};    

          //Set Victoria's sprite
          victoriaPic.sprite = coreMechanic.victoria[victoria];

          //Set the NPCs present in the scene
          for(int i = 0; i < npcs.Length; i++)
          {
               //No NPC is in this spot
               if(npcs[i].x == 0)
               {
                    npcSlots[i] = 0;
                    npcPics[i].gameObject.SetActive(false);
               }

               //Ashley is present here
               if(npcs[i].x == 1)
               {
                    npcSlots[i] = 1;
                    npcPics[i].sprite = coreMechanic.ashley[(int)npcs[i].y];
                    npcPics[i].gameObject.SetActive(true);
               }

               //Jackson is present here
               if (npcs[i].x == 2)
               {
                    npcSlots[i] = 2;
                    npcPics[i].sprite = coreMechanic.jackson[(int)npcs[i].y];
                    npcPics[i].gameObject.SetActive(true);
               }

               //Olivia is present here
               if (npcs[i].x == 3)
               {
                    npcSlots[i] = 3;
                    npcPics[i].sprite = coreMechanic.olivia[(int)npcs[i].y];
                    npcPics[i].gameObject.SetActive(true);
               }

               //Chris is present here
               if (npcs[i].x == 4)
               {
                    npcSlots[i] = 4;
                    npcPics[i].sprite = coreMechanic.chris[(int)npcs[i].y];
                    npcPics[i].gameObject.SetActive(true);
               }

               //Harry is present here
               if (npcs[i].x == 5)
               {
                    npcSlots[i] = 5;
                    npcPics[i].sprite = coreMechanic.harry[(int)npcs[i].y];
                    npcPics[i].gameObject.SetActive(true);
               }
          }

          //Set the speaker in the scene
          if(speaker == 0)
          {
               speakerName.SetText("Victoria");

               victoriaPic.color = Color.white;
               npcPics[0].color = Color.gray;
               npcPics[1].color = Color.gray;
               npcPics[2].color = Color.gray;
          }

          else
          {
               speakerName.SetText(charactersNames[speaker]);

               victoriaPic.color = Color.gray;

               for(int i = 0; i < npcSlots.Length; i++)
               {
                    if(npcSlots[i] == speaker)
                    {
                         npcPics[i].color = Color.white;
                    }

                    else
                    {
                         npcPics[i].color = Color.gray;
                    }
               }
          }

     }
}