using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day5 : Day
{
     List<string[]> dialogue;
     List<Event> events;

     string[] schedule;
     int hours = 8;

     List<int> choices;
     int choiceOrder = 0;
     public Day5()
     {
          dialogue = new List<string[]>();
          events = new List<Event>();
          choices = new List<int>();
          schedule = new string[] { "Dialogue", "Freetime", "Dialogue", "End" };

          dialogue.Add(new string[] {
            "0 6 00 00 00 0 *BZZT BZZT BZZT BZZT*",
            "0 6 00 00 00 0 nggghhh *click*",
            "7 6 00 00 00 0 Wa…..ffles? This isn’t a restaurant calling you know. ",
            "0 3 00 00 00 0 Oh, good morning mom. Sorry, I just woke up.",
            "7 3 00 00 00 0 Just woke up? It’s noon dude! How have you been settling into your new place? Are you and Olivia still getting along? Are you eating well? Are you keeping up with school? Are you overworking yourself? Are you managing your money so you can pay for rent?",
            "0 5 00 00 00 0 Woah woah woah what’s with the bombardment of questions? It’s half past way too early for this. ",
            "7 5 00 00 00 0 Oh I’m sorry, am I not allowed to be concerned about my child who is living on their own far away from home?",
            "0 0 00 00 00 0 Fair point. Let’s see, I love this new place but I fucking hate the landlord. The guy is a stuck up prick who had nothing better to do but shit talk Olivia in the first 5 minutes of meeting her. ",
            "0 2 00 00 00 0 Olivia is my gal, and living with her again has been a lot of fun. Thanks to the care package you made for me I am eating well this week. Your homemade lasagna was so good even Olivia snagged a slice. ",
            "7 2 00 00 00 0 Looks like you are faring well so far, that's really great to hear. I’m really sorry I couldn’t send enough money for you to cover rent this month. Your younger brother’s baseball bill came in and it’s unreal. I mean seriously, how could throwing a ball around a couple times cost so damn much. ",
            "7 2 00 00 00 0 On top of that, our mortgage rate got hiked up again. Just keeping this house is taking everything we have. Just like you, we are taking it one month at a time. ",
            "7 2 00 00 00 0 Your brother is no idiot, and he is starting to catch on to the money issue. He is eating less food and insisting we get cheaper food alternatives. The amount of grief we have for not being able to provide enough for him and you is immeasurable. ",
            "0 4 00 00 00 0 You don’t have to worry about me Mom, and I’m pretty sure Wyatt feels the same way. Right now I should be making enough money at my part time job at the restaurant to pay for rent if I manage everything correctly. You just need to chill out and trust in us. ",
            "0 4 00 00 00 0 Even if I don’t have enough, I’m sure Olivia won’t mind picking another cheaper place with me next month. It will be a little jarring to do in the middle of a semester, but I will be fine. ",
            "0 4 00 00 00 0 The housing prices both here and back home are getting absurd. It is wild to think that the concept of just having a roof over our heads is something we constantly have to bust our ass in order to obtain. It should be a right to have regardless of how the economy is changing. ",
            "7 3 00 00 00 0 You know as well as I do, as long as greed remains a basic human trait we will never be able to obtain that ideal. ",
            "7 3 00 00 00 0 Sorry Vic, I gotta go. I picked up a shift today and I have to get ready. Have a good week and don’t work yourself too hard. ",
            "0 2 00 00 00 0 You too, mom. Love you. *click*",
            "0 4 00 00 00 0 (She really has to take her own advice. She is overworking herself, and I am concerned she is going to burn out. That being said, I guess we all have to do what we have to to make ends meet.)",
            "0 4 00 00 00 0 (Mom and dad have always tried their best to make sure we don’t get sucked into this messy problem, but we are all human at the end of the day. Nobody is perfect, and at the end of the day I can take it as motivation to keep moving forward.)",
            "0 1 00 00 00 0 (Ok, what should I do today? It is my day off, so I could just make it a rest day. That being said, with the talk I just had with Mom I could take Ashley up on that offer. Lastly, I could get a nice head start on schoolwork for this week.)"
            });

          events.Add(new Event(
                 new Option("Take a rest day", 20, 0, 0, 40, new string[] {
                   "0 2 00 00 00 0 I think I’ll use the day to check out more of the town. I still have to get my bearings around here. Oi Olivia, wanna join me?",
                   "3 2 30 00 00 0 Eh?",
                   "0 2 30 00 00 0 I’m gonna make a ruckus around town, you in?",
                   "3 2 30 00 00 0 Oh I’m in, as long as we don’t have to talk to too many peeps." }),
                 new Option("Pickup a shift at work", 3, new string[] {
                   "1 3 11 00 00 3 Nothing better to do, eh?",
                   "0 5 11 00 00 3 Nope, and I need the cash. I’ll be here till close. ",
                   "1 5 11 00 00 3 Awesome, we could use the extra hand. Dress yourself, woman." ,
                   "0 2 11 00 00 3 Sounds good, chief" }),
                 new Option("Jumpstart on homework", 10, 0, 5, 0, new string[] {
                   "0 5 00 00 00 0 Time to bury myself in some books. This is going to be bo-ring. Hey O, you here for the day?",
                   "3 5 30 00 00 0 Yea, why what’s up?",
                   "0 3 30 00 00 0 Gonna be doing some studying today. You wanna join?",
                   "3 3 30 00 00 0 Was planning to do some myself anyway, so that works for me." })));

          dialogue.Add(new string[] {
            "0 3 30 00 00 0 Olivia, we actually survived the first week in this place. Let’s crack open some of those beers you bought to celebrate. I’ll pay you back. ",
            "3 3 30 00 00 0 No need, that lasagna was fucking delicious. Call it even. "
        });
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

     public override List<string> getUniqueEvent(string[] updatedSchedule, int mental, int money, int academic, int energy)
     {
          throw new System.NotImplementedException();
     }

     public override void addChoice(int choice)
     {
          choices.Add(choice);
     }
}
