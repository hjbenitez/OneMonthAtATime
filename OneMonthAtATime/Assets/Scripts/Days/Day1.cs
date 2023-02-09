using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : Day
{
     List<string[]> dialogue;
     List<Event> events;

     string[] schedule;

     public Day1()
     {
          dialogue = new List<string[]>();
          events = new List<Event>();
          schedule = new string[] { "Dialogue", "School", "Dialogue", "Work", "Dialogue", "Dialogue", "End" };

          //Opening Dialogue about the playtest
          dialogue.Add(new string[] { "0 2 00 00 00 Welcome fellow playtesters to One Month at a Time, a game where you get to play as me who is a struggling student trying to make ends meet one month at a time.",
               "0 2 00 00 00 Throughout this game you will have to manage 3 main resources, these being Money, Academic Standing, and Mental Health, with Money being the most important resource of all.",
               "0 2 00 00 00 If I don’t accrue enough money by the end of the month I will be homeless, and I really don’t want to be booted to the streets! This small sample of the game will consist of two random days in the middle of the game, so let’s see how I do!",
               "0 6 00 00 00 Maaaaaan, they seriously expect us to get up, get to school, and be awake and competent for class at 10am? They do know we are all gamers, right? 5 hours of sleep is not enough!",
               "0 6 00 00 00 Not only that, but I have work after this. What. A. Drag. How does our government expect college students to spend a crazy amount of money for tuition, a place to live, and on top of that inflated grocery prices! It just isn’t fair.",
               "0 5 00 00 00 There will be the people who say “well that’s life, and life isn’t fair” but does it really have to be that way? That’s just a bullshit cop out answer people give because they refuse to look further into the issue.",
               "0 5 00 00 00 How will this crazy economy continue into the future if the cost of living continues to rise at exponential rates but earnings stay the same?",
               "0 5 00 00 00 Whatever. This dirty and destructive cycle of burning the wick at both ends will never stop as long as humans remain greedy creatures. I gotta focus on class right now, the daily existential crisis can wait till later."});

          //Event - School
          events.Add(new Event(
               new Option("Pay Attention", 0, -2, 0.1f, -0.1f, new string[] { "0 1 00 00 00 Dark patterns huh?" }),
               new Option("Take Notes", 0, -6, 0.1f, -0.5f, new string[] { "0 2 00 00 00 Always good to get a head start on the assignment!" }),
               new Option("Slack Off", 0, 4, -0.05f, 0f, new string[] { "0 4 00 00 00 Man I hope this Nintendo Direct shows Metriod Prime 4" })));

          //Dialogue with Ashley before Victoria's shift
          dialogue.Add(new string[] { "0 2 00 00 00 Hey Ashley, sorry I'm late. I had to deal with my impatient landlord. You having a good week?",
               "1 2 12 00 00 Eh, it's been alright. I’ve been getting as many hours as I can but I’m getting pretty tired already. Dealing with people everyday gives you great social skills, but man does it ever drain your battery.",
               "0 3 12 00 00 Ever consider getting another position that is less taxing? Knowing you, adapting to pretty much anything will be a breeze.",
               "0 4 12 00 00 Really wish I could, but I have done the calculations and the hours I get here plus the amount of money in tips I am making really makes a difference compared to other jobs around here.",
               "1 4 13 00 00 I also have to stay close. Bussing from my place to here and back is already costly enough, and I live close!",
               "1 4 13 00 00 Anyways, you know I’m just here until I can save up enough for a 2 year program. As soon as I reach that magic number, I’m getting the hell outta this place!",
               "1 4 13 00 00 We gotta prep for the dinner rush. Let’s talk more later.",
               "0 1 00 00 00 I should probably start working as well."});

          //Event - Work
          events.Add(new Event(
              new Option("Work as Usual", 200, -5, 0, -0.25f, new string[] { "0 2 00 00 00 That table is always nice" }),
              new Option("Take it Easy", 120, 5, 0, 0, new string[] { "0 2 00 00 00 hmhm hmhm hm hm hmmmmmmm hmhm hmhm hm hm hmmmmmmm" }),
              new Option("Bust Yo' ASS", 350, -15, 0, -0.6f, new string[] { "0 2 00 00 00 Made a lot of tips so far!" })));

          //Event - Rude Customer with Ashley 
          dialogue.Add(
            new string[] {
               "9 2 00 00 00 excuse me…….hello??? EXCUSE ME.",
               "0 2 00 00 00 Sorry sir, I was just helping another table. What can I help you with?",
               "9 1 00 00 00 I demand a complete refund! I asked for a medium steak and what I got tastes like a FUCKING campfire. I don’t even want a new one because you imbeciles will probably screw it up again! Give me my money back unless you want to lose a customer forever!",
               "0 1 00 00 00 But sir, you have eaten almost the entire st….",
               "9 1 00 00 00 Are you trying to mock me? What the hell do you know, you’re just a dumb waitress who is shit at her job. I demand to see your manager right now!",
               "0 0 00 00 00 What a prick! He thinks getting Ashley will help him but she’s just gonna rip him a new one. Can’t wait to see that.",
               "0 3 00 00 00 Right away sir.",
               "0 6 00 00 00 These are the types of customers that get people questioning if they are in the wrong profession.",
               "0 6 00 00 00 I would much rather work a backend position so I wouldn’t have to deal with a douchebag like him but it doesn’t pay as well, and I need the money so I can make ends meet.",
               "0 6 00 00 00 Where the hell did Ashley go?",
               "0 3 00 00 00 Ashley? Where are you?",
               "1 3 13 00 00 Sorry I just had a huge chatterbox of a customer. Nice lady though. What’s the matter?",
               "0 3 13 00 00 This is gonna bring your mood down, but you’re gonna have to deal with a Class A miserable customer at table 7",
               "1 3 13 00 00 How bad?",
               "0 0 13 00 00 Listening to him makes me want to cut my ears off with a rusty pair of scissors",
               "1 0 13 00 00 Well that’s just lovely. What’s the problem with him?",
               "0 2 13 00 00 Oh, I don’t wanna spoil the fun. I just want to wait and see what happens.",
               "1 2 12 00 00 What seems to be the problem sir?",
               "9 3 12 00 00 This moron of a waitress didn’t give me a full refund when I asked for it. This steak is way too overcooked even though I only asked for medium rarity. It is repulsing and you will be losing a lifetime of my business if you do not refund this mockery of a steak.",
               "1 3 10 00 00 Oh is that all? Well let me tell you two things. First off, Victoria here is not the moron in the situation, you are. Secondly, do you really expect us to refund a steak when you have basically only left crumbs left?",
               "1 3 10 00 00 You are just trying to get a free meal and that isn’t happening.",
               "9 3 10 00 00 How appalling. You can’t treat a customer like that! Haven’t you heard that the customer is always right? Give me my money back NOW or else I am walking out and never coming back.",
               "1 3 10 00 00 We have enough regulars where your input has no value at all. If you don’t want to eat here, don’t. But if you ever try to disrespect and demean our workers ever again I will have you TOSSED out of here.",
               "1 3 10 00 00 Also, If I told you the workers at an establishment were always right, would you believe me? Unlikely. That is how pretty much any worker views that wild claim.",
               "1 3 10 00 00 We don’t want your business, so get the hell out. If you don’t pay we could always track you by that beater car you have out in the lot. Please don’t come back.",
               "1 3 12 00 00 Victoria lets go, we have more work to do.",
               "0 2 00 00 00 Man, that was better than I thought it was going to be. Always fun to see you get serious."});

          //Dialgoue before Victoria goes to bed
          dialogue.Add(new string[] { "0 6 00 00 00 All in all, a pretty tame day minus the ridiculous customer that came in. Tomorrow I have some free time, so I guess I’ll choose what to do based on how the day goes. " });
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
