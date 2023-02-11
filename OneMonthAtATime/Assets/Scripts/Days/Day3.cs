using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3 : Day
{
     List<string[]> dialogue;
     List<Event> events;

     string[] schedule;
     
     public Day3()
     {
          //THIS IS WHERE YOU AFFECT HOW THE DAY PLAYS OUT
          //Dialogue - Characters speaking
          //Events - Choices 
          dialogue = new List<string[]>();
          events = new List<Event>();

          schedule = new string[] { "0Dialogue", "2Dialogue", "2Work", "1Dialogue", "1Event", "1Dialogue", "1School", "3Dialogue", "3Event", "4Dialogue", "0Freetime", "0Dialogue", "0Dialogue", "0End" };

          //Dialogue 1
          dialogue.Add(new string[] { "0 0 00 00 00 Hola", "0 1 00 00 00 Soy Victoria", "0 3 00 00 00 Donde esta la bibliotecha?" });

          //Dialogue 2
          dialogue.Add(new string[] { "0 4 00 00 00 Just making sure this works", "0 5 00 00 00 Because it's good to double check code you know?", "1 6 10 00 00 Yea I feel you" });

          //Work
          events.Add(new Event(
              new Option("Work as Usual", 200, -5, 0, -0.25f, new string[] { "0 2 00 00 00 Nothing out of the ordinary" }),
              new Option("Take it Easy", 120, 5, 0, 0, new string[] { "0 2 00 00 00 Easy day today" }),
              new Option("Bust Yo' ASS", 350, -15, 0, -0.6f, new string[] { "0 2 00 00 00 That was hard work!" })));

          //Dialogue 3
          dialogue.Add(new string[] { "0 4 00 00 00 What should I wish for?" });

          //Event 1
          events.Add(new Event(
               new Option ("Mental", 10f, 0f, 0f, 0f, new string[] { "0 2 00 00 00 I feal healthier already!" }),
               new Option ("Academic", 0f, 0f, 0.5f, 0f, new string[] { "0 2 00 00 00 I am very studious!" }),
               new Option ("Money", 0f, 2000f, 0f, 0f, new string[] { "0 2 00 00 00 I'm riiiiiiiiich!" })));

          //Dialogue 4
          dialogue.Add(new string[] { "0 6 00 00 00 Long shift, bye Ashley :)", "1 4 00 11 00 Take care Vic VaporRub", "0 7 00 00 00 Time to go to school!" });

          //School
          events.Add(new Event(
               new Option("Pay Attention", 0, -2, 0.1f, -0.1f, new string[] { "0 2 00 00 00 Interesting content today." }),
               new Option("Take Notes", 0, -6, 0.1f, -0.5f, new string[] { "0 2 00 00 00 Ready for the next assignment!" }),
               new Option("Slack Off", 0, 4, -0.05f, 0f, new string[] { "0 4 00 00 00 Why can't I put Jumino huts on Ginger Island" })));

          //Dialogue 5
          dialogue.Add(new string[] { "0 4 00 00 00 Uh oh", "0 8 00 00 00 Two events?", "0 6 00 00 00 Let's see how this turns out" });

          //Event 2
          events.Add(new Event(
               new Option("It's fine", 10f, 0f, 0f, -0.25f, new string[] { "0 2 00 00 00 Yea you're right", "0 5 00 00 00 IT IS FINE1" }),
               new Option("It's fine...", 0f, 0f, 0f, -.4f, new string[] { "0 2 00 00 00 Yea you're right", "0 5 00 00 00 IT IS FINE2" }),
               new Option("ITS FINE", 0f, 100, 0f, 0.5f, new string[] { "0 2 00 00 00 Yea you're right", "0 5 00 00 00 IT IS FINE3" })));

          //Dialogue 6
          dialogue.Add(new string[] { "0 2 00 00 00 I got some time to kill", "0 1 00 00 00 I got a test coming up soon, I should study...", "0 1 00 00 00 Or I can pickup a shift and make some more money to put towards my bills...",
               "0 1 00 00 00 Ooooooor I can play a childhood game from a series I loved as a kid...", "0 1 00 00 00 What should I do..."});

          //Freetime
          events.Add(new Event(
               new Option("I should study", -10f, 0.25f, 0f, -0.25f, new string[] { "0 4 00 00 00 Man i'm tired." }),
               new Option("I'll pick up another shift", -20f, -0f, 200f, -0.25f, new string[] { "0 3 00 00 00 That shift was exhausting..." }),
               new Option("Metroid Prime is 'Echoing' for me", 25, 0f, 0f, -0.25f, new string[] { "0 4 00 00 00 I love this franchise." })));

          //Dialogue 7
          dialogue.Add(new string[] { "0 8 00 00 00 Tough lesson", "0 9 00 00 00 Gonna go home now!" });

          //Dialogue 8
          dialogue.Add(new string[] { "9 0 00 00 00 I'm a one off to progress the characters story!", "0 0 00 00 00 Shut up! You're are irrelevant!", "0 5 00 00 00 Anyways, time for bed" });

     }

     public override List<string[]> getDialogue()
     {
          return dialogue;
     }

     public override string[] getSchedule()
     {
          return schedule;
     }

     public override List<Event> getEvents()
     {
          return events;
     }
}
