using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2 : Day
{
     List<string[]> dialogue;
     List<Event> events;
     int hours = 5;

     string[] schedule;

     public Day2()
     {
          dialogue = new List<string[]>();
          events = new List<Event>();
          schedule = new string[] { "Dialogue", "Dialogue", "School", "Dialogue", "School", "Dialogue", "End" };

          //Day 2 Intro with Olivia
          dialogue.Add(new string[] {
               "3 6 30 00 00 0 Rise and shine V.",
               "0 6 30 00 00 0 nghhhh……five more minutes…..",
               "3 6 30 00 00 0 *CLAP CLAP CLAP*",
               "0 8 30 00 00 0 GAAAAAAAHHHHH I’M AWAKE I’M AWAKE",
               "0 6 30 00 00 0 Was that really necessary?",
               "3 6 30 00 00 0 I’m not your alarm clock. Hurry up or we will be late. ",
               "3 6 30 00 00 0 We have another busy day ahead of us. Please don’t tell me you forgot about the presentation we have today with Chris. I’m gonna need you two to do all the talking, you know presenting is not my strong suit",
               "0 3 30 00 00 0 Yea I didn’t forget. You know once we are out of school we will have to do this all the time, right? You need to shake the irrational anxiety you get when presenting or else it will screw you. ",
               "3 3 30 00 00 0 Wish it was that easy.",
               "0 3 30 00 00 0 (Glad I got some rest last night, I’m really gonna need it today. Can’t run out of steam by the second class because of the long ass presentation we have to give. Time to put the pedal to the medal!)"
            });

          //Setting up School event
          dialogue.Add(new string[] {
               "0 1 30 00 00 1 (Looks like I’m in for another long day. I could apply myself in this class, but my main concern is the class after this, having the presentation and all. I won’t really be missing anything important if I slack off this time.)"
          });

          //School Event 
          events.Add(new Event(
               new Option("Take Notes", -20, 0, 0.1f, -0.5f, new string[] { 
                   "4 3 40 00 00 1 Oi Veronica what’s cookin? " }),
               new Option("Pay Attention", -5, 0, 0.1f, -0.1f, new string[] {
                   "4 3 40 00 00 1 Oi Veronica what’s cookin?" }),
               new Option("Slack Off", 10, 0, -0.05f, 0f, new string[] { 
                   "4 3 40 00 00 1 Oi Veronica what’s cookin? " })));

          //Enter Chris
          dialogue.Add(new string[] {
               "0 0 40 00 00 1 We have known each other for over a year Chris, you know damn well it’s Victoria.",
               "4 0 40 00 00 1 Same difference. Just came over here to check if you were ready for the presentation next class. We have an hour to kill, and I was thinking we could all go over the material and prepare.",
               "4 0 40 00 00 1 Blah I hate presentations, they are just too boring. Hard to joke around when a mark is up for grabs. The teacher is pretty chill, but whenever someone is presenting it's like they have a rod up their ass or something. ",
               "4 0 40 00 00 1 Oh good, Olivia is here. We were just talking about how we should spend the time between classes to rehearse our presentation. You good for that?",
               "3 3 00 40 30 1 Y-yeah sounds good to me...",
               "4 3 00 40 30 1 Man, you’re still anxious around me? I’m eventually gonna take that personally you know. ",
               "0 5 00 40 30 1 Maybe it’s because you have an overwhelming personality, Chris. Almost like you’re overcompensating for something…",
               "4 5 00 40 30 1 Ok MOM, you know I was just messing with her. Let's hit up the library before we get to class. ",
               "3 5 00 40 30 1 It’s all going to be ok. We practiced for this. We are prepared for this. Nobody will judge us even if we mess up. We have done all the research we need for this. I will get a good mark. I won’t mess up. I won’t mess up. ",
               "4 5 00 40 30 1 Veronica, I think Olivia’s broken. Reboot her or something. ",
               "0 2 00 40 30 1 You know, Victoria really isn’t a hard name to remember. Olivia, chill out we will do just fine. You have done all you can to prepare yourself so there really isn’t any need to freak yourself out when all the hard work is out of the way.  ",
               "0 5 00 40 30 1 Regardless, everyone is just going through the motions in these presentations. Nobody is really going to be paying much attention because realistically they don’t care.",
               "3 5 00 40 30 1 I’ll do m-my best. ",
               "0 5 00 40 30 1 (This will either turn out to be an absolute trainwreck or a smooth and well delivered presentation. It all depends on how much I choose to apply myself and the hope that the others do their part.)"
            });

           //School Event
          events.Add(new Event(
               new Option("Take Notes", -20, 0, 0.1f, -0.5f, new string[] { 
                   "3 3 00 40 30 2 Guess that went well enough…", 
                   "4 3 00 40 30 2 See? I knew you had it in you!", 
                   "0 0 00 40 30 2 I believe I remember a certain jackass describing her as “broken”. ", 
                   "4 0 00 40 30 2 I believe that “jackass” was the only saving grace we had in that presentation. Anyways I know we all have nothing else on the agenda today, so why don’t we grab some drinks at the shitty bar across the street? Even though it’s overpriced as hell, I think we could all use it after today. ", 
                   "4 0 00 40 30 2 And Veronica before you even think about picking up another shift or going home to be a loner, you’re coming with. If you don’t do fun things with people and watch your mental state, it will eat at you and eventually sap your energy bank. ",
                   "4 0 00 40 30 2 Let’s go get merry and force Olivia to sing some karaoke. ", 
                   "3 5 30 00 00 2 Why am I getting caught in the crossfire…" }),
               new Option("Pay Attention", -5, 0, 0.1f, -0.1f, new string[] { 
                   "3 3 00 40 30 2 Guess that went well enough…", 
                   "4 3 00 40 30 2 See? I knew you had it in you!", 
                   "0 0 00 40 30 2 I believe I remember a certain jackass describing her as “broken”. ", 
                   "4 0 00 40 30 2 I believe that “jackass” was the only saving grace we had in that presentation. Anyways I know we all have nothing else on the agenda today, so why don’t we grab some drinks at the shitty bar across the street? Even though it’s overpriced as hell, I think we could all use it after today. ", 
                   "4 0 00 40 30 2 And Veronica before you even think about picking up another shift or going home to be a loner, you’re coming with. If you don’t do fun things with people and watch your mental state, it will eat at you and eventually sap your energy bank. ", 
                   "4 0 00 40 30 2 Let’s go get merry and force Olivia to sing some karaoke. ", 
                   "3 5 30 00 00 2 Why am I getting caught in the crossfire…" }),
               new Option("Slack Off", 10, 0, -0.05f, 0f, new string[] { 
                   "0 5 00 00 00 2 ..." })));

          dialogue.Add(new string[] {
               "0 6 30 00 00 0 It’s punny how you become a completely different person when you have a couple drinksh. They were shanting your name.",
               "3 6 30 00 00 0 I can’t believe I actually shang. I’m so embarrassed. It’s shleepy time, so goodnight Veronica",
               "0 1 00 00 00 0 (Is she slowly turning into Chris? Guesh he really rubs off on people)",
               "0 5 00 00 00 0 (Thankfully we don’t have class tomorrow, I drank way too much. I get to shleep in and make some money back tomorrow. Time to hit the hay.)"
          });
          
          /*
          //Dialogue 1
          dialogue.Add(new string[] {
            "0 6 00 00 00 Dude, another 10am lecture? I really shouldn’t have spent those extra hours binging that show I love. It’s so hard to turn off when you really get into it though, so I can’t blame myself. ",
            "0 6 00 00 00 Pretty sure this class is going to be a boring one, but I can’t wait for the one I have later today. A 6pm class really throws my sense of time off."});

          //School
          events.Add(new Event(
                 new Option("Pay Attention", -5, 0, 0.1f, -0.1f, new string[] { "0 1 00 00 00 Dark patterns huh?" }),
                 new Option("Take Notes", -20, 0, 0.1f, -0.5f, new string[] { "0 2 00 00 00 Always good to get a head start on the assignment!" }),
                 new Option("Slack Off", 10, 0, -0.05f, 0f, new string[] { "0 4 00 00 00 Man I hope this Nintendo Direct shows Metriod Prime 4" })));

          //Dialogue 2
          dialogue.Add(new string[] {
             "9 3 00 00 00 …Ok does everyone understand the exercise? Great. I’ll be in class for another half hour if anyone needs help.",
             "0 5 00 00 00 *Yawns*",
             "0 2 00 00 00 Glad the exercise is something I already know, I can get it done in 5 minutes and leave class early. It would be nice to get a longer lunch break for once-",
             "9 5 00 00 00 Um, excuse me?",
             "0 1 00 00 00 Huh? Sorry, whats up?",
             "9 1 00 00 00 I’m a little confused by the exercise, could you help me out quickly?" });

          //Event - Student asks for help
          events.Add(new Event(
              new Option("Help them", 5, 0, 0.02f, -0.1f, new string[] { "0 5 00 00 00 Well, glad they figured it out, and I feel good about helping. Unfortunately, I also lost all the extra time I had. Guess I’m eating lunch in a hurry again or I’ll be late for the meeting for my group project." }),
              new Option("Tell them to ask the prof", 10, 0, 0f, 0.1f, new string[] { "0 3 00 00 00 I don’t want to be rude but I’m way too tired, the prof is literally right there to help and will probably give better advice than I could. I just really need some time to myself to collect my thoughts." }),
              new Option("Say you're busy", 5, 0, 0.02f, -0.1f, new string[] { "0 4 00 00 00 Funny how that works, by pretending to work on something for half an hour I was actually pretty productive. I do feel kinda bad though… just a little." })));

          //Dialogue 3 - Freetime lead up
          dialogue.Add(new string[] {
          "0 3 00 00 00 Looks like I have a bunch of free time today, as rare as that is. What should I do? I could probably pick up a half shift - I know I could use the money and the tips would probably be decent if I tried.",
          "0 3 00 00 00 I could also study for the upcoming test - my skill for programming is non-existent. I could probably ask Olivia for help, she’s basically a genius at anything she applies herself in.",
          "0 2 00 00 00 There is a new game out that I have been meaning to play - I could go home then come back for my last class."});

          //Event Freetime
          events.Add(new Event(
                 new Option("Pickup a shift", 2, new string[] { ""}),
                 new Option("Study with Olivia", 0, -6, 0.1f, -0.5f, new string[] { "" }),
                 new Option("Play that new game", 0, 4, -0.05f, 0f, new string[] { "" })));

          //School Event
          events.Add(new Event(
                 new Option("Pay Attention", 0, -2, 0.1f, -0.1f, new string[] { "0 1 00 00 00 Dark patterns huh?" }),
                 new Option("Take Notes", 0, -6, 0.1f, -0.5f, new string[] { "0 2 00 00 00 Always good to get a head start on the assignment!" }),
                 new Option("Slack Off", 0, 4, -0.05f, 0f, new string[] { "0 4 00 00 00 Man I hope this Nintendo Direct shows Metriod Prime 4" })));

          //Dialogue 4 - ending playtest
          dialogue.Add(new string[] { "0 2 00 00 00 That’s all we have so far for this playtest folks. Hope you enjoyed playing and please let us know what we could potentially be doing better. This has been One Month at a Time, signing off." });
          */
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

     public override int getHours()
     {
          return hours;
     }
}
