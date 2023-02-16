using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
     //0 0 00 00 00 0
     //Speaker Victoria NPC1 NPC2 NPC3 Location
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

     /*Location INDEX
      * 0 = Home
      * 1 = Classroom 1
      * 2 = Classroom 2
      * 3 = Work
      */

     Dictionary<int, string> charactersNames;
     int[] npcSlots;

     string[] dialogue;
     int index;
     int locationIndex;

     public TextMeshProUGUI dialogueBox;
     public TextMeshProUGUI speakerName;

     public Image victoriaPic;
     public Image[] npcPics;

     public CoreMechanic coreMechanic;
     public Image dialoguePrompt;
     // Start is called before the first frame update
     void Start()
     {
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
          charactersNames.Add(7, "Mom");
          charactersNames.Add(8, "Customer");

          //Start dialogue
          dialogueBox.text = "Press Space to start!";
     }

     // Update is called once per frame
     void Update()
     {
          if (coreMechanic.getCurrentTime() != "Dialogue")
          {
               dialoguePrompt.gameObject.SetActive(false);
          }

          if ((Input.GetKeyDown(KeyCode.Space) || coreMechanic.playerChose) && coreMechanic.getCurrentTime() == "Dialogue" && coreMechanic.dialogueSet)
          {
               setDialogue(dialogue[index]);
               index++;
               dialoguePrompt.gameObject.SetActive(true);

               //when dialogue is done
               if (index == dialogue.Length)
               {
                    coreMechanic.progressDay();
                    coreMechanic.nextDialogue();
                    index = 0;
                    coreMechanic.dialogueSet = false;
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
               text = text.Remove(0, 15);
          }


          dialogueBox.text = text;
     }

     public void getDialogue(string[] chain)
     {
          dialogue = chain;
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

          locationIndex = int.Parse(dialogue.Substring(13, 1));

          //Set Victoria's sprite
          victoriaPic.sprite = coreMechanic.victoria[victoria];

          //Set the NPCs present in the scene
          for (int i = 0; i < npcs.Length; i++)
          {
               //No NPC is in this spot
               if (npcs[i].x == 0)
               {
                    npcSlots[i] = 0;
                    npcPics[i].gameObject.SetActive(false);
               }

               //Ashley is present here
               if (npcs[i].x == 1)
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
          if (speaker == 0)
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

               for (int i = 0; i < npcSlots.Length; i++)
               {
                    if (npcSlots[i] == speaker)
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

     public int getLocationIndex()
     {
          return locationIndex;
     }

     public void setLocationIndex(int locationIndex)
     {
          this.locationIndex = locationIndex;
     }
}