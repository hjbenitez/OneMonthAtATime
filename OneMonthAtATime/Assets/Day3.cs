using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3
{
     

     List<string[]> dialogue;
     List<Event> events;

     Event freetime;
     string[] schedule;
     
     public Day3()
     {
          //THIS IS WHERE YOU AFFECT HOW THE DAY PLAYS OUT
          dialogue = new List<string[]>();
          events = new List<Event>();

          schedule = new string[] { "Dialogue", "Dialogue", "Work", "Event", "School", "Event", "newFreetime", "Dialogue", "End" };

          dialogue.Add(new string[] { "00Hola", "01Soy Victoria", "03Donde esta la bibliotecha?" });

          dialogue.Add(new string[] { "04Just making sure this works", "05Because it's good to double check code you know?", "10Yea I feel you" });

          dialogue.Add(new string[] { "06Long shift, bye Ashley :)", "11Take care Vic VaporRub", "07Time to go to school!" });

          dialogue.Add(new string[] { "08Tough lesson", "09Gonna go home now!" });

          dialogue.Add(new string[] { "90I'm a one off to progress the characters story!", "00Shut up! You're are irrelevant!", "05Anyways, time for bed" });

          events.Add(new Event(
               new Option ("Mental", 10f, 0f, 0f, 0f, new string[] { "02I feal healthier already!" }),
               new Option ("Academic", 0f, 0f, 0.5f, 0f, new string[] { "02I am very studious!" }),
               new Option ("Money", 0f, 2000f, 0f, 0f, new string[] { "02I'm riiiiiiiiich!" }), 
               new string[] { "04What should I wish for?" }));

          events.Add(new Event(
               new Option("It's fine", 10f, 0f, 0f, -0.25f, new string[] { "02Yea you're right", "05IT IS FINE1" }),
               new Option("It's fine...", 0f, 0f, 0f, -.4f, new string[] { "02Yea you're right", "05IT IS FINE2" }),
               new Option("ITS FINE", 0f, 100, 0f, 0.5f, new string[] { "02Yea you're right", "05IT IS FINE3" }),
               new string[] { "04Uh oh", "08Two events?", "06Let's see how this turns out" }));

          freetime = new Event(
               new Option("I should study", -10f, 0.25f, 0f, -0.25f, new string[] { "04Man i'm tired." }),
               new Option("I'll pick up another shift", -20f, -0f, 200f, -0.25f, new string[] { "03That shift was exhausting..." }),
               new Option("Metroid Prime is 'Echoing' for me", 25, 0f, 0f, -0.25f, new string[] {  "04I love this franchise." }),
               new string[] { "02I got some time to kill", "01I got a test coming up soon, I should study...", "01Or I can pickup a shift and make some more money to put towards my bills...", 
               "01Ooooooor I can play a childhood game from a series I loved as a kid...", "01What should I do..."});


     }

     public List<string[]> getDialogue()
     {
          return dialogue;
     }

     public string[] getSchedule()
     {
          return schedule;
     }

     public List<Event> getEvents()
     {
          return events;
     }

     public Event getFreetime()
     {
          return freetime;
     }
}
