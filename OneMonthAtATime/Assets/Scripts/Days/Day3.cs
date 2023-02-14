using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3 : Day
{
    List<string[]> dialogue;
    List<Event> events;

    string[] schedule;
    int hours = 5;
    public Day3()
    {
        //THIS IS WHERE YOU AFFECT HOW THE DAY PLAYS OUT
        //Dialogue - Characters speaking
        //Events - Choices 
        dialogue = new List<string[]>();
        events = new List<Event>();

        schedule = new string[] { "Dialogue", "Freetime", "Dialogue", "Work", "Dialogue", "Dialogue", "End" };

        dialogue.Add(new string[] {
            "0 7 00 00 00 0 (Grrrrrahahhhhha. I am never drinking again. Seriously, nobody thought to cut me off at any point last night? I literally cannot remember how much I drank. We always have interesting nights whenever Chris is involved. Wait, where the hell is Olivia?)",
            "3 7 30 00 00 0 Blahghahsefenbif. Fucking hell. *flush*",
            "0 2 30 00 00 0 Hahaha, you’re in worse condition than me. How can you be such a lightweight when you’re like twice my size?",
            "3 2 30 00 00 0 Dunno, but I’m glad you’re enjoying my suffering. At least one of us is having a fun morning.",
            "3 2 30 00 00 0 I gotta get out of here though. I have some errands I gotta run today. What are you getting up to? ",
            "0 7 30 00 00 0 Apart from work later on I’m just gonna kill some time and nurse this fucking hangover. Don’t push yourself too hard today. ",
            "0 7 00 00 00 0 (I have some free time and I feel like I’m dying, so I can either get some schoolwork done or just take it easy and play some games before work.)"
        });

        events.Add(new Event(
             new Option("Study", -10, 0f, 0.05f, -0.15f, new string[] { 
                 "0 3 00 00 00 0 Hey Ashley, it’s good to see you." }),
             new Option("Game", 12, 0f, 0, 0f, new string[] { 
                 "0 3 00 00 00 0 Hey Ashley, it’s good to see you." })));

        dialogue.Add(new string[] {
            "1 3 11 00 00 3 Hohoho, looks like someone had a fun night. You look like shit and you smell of booze. Did you even shower?",
            "0 4 10 00 00 3 Jesus, still? For the record I did shower and I even took the liberty of bathing myself in perfume. My head is still screwed on straight so you don’t have to worry about me. ",
            "0 2 11 00 00 3 Enough about me, how has your week been? That pesky roommate of yours do something stupid again?",
            "1 4 12 00 00 3 This week of Ashley’s dumbass roommate includes leaving dishes in the sink long enough to create mold as well as not doing her allotted chores, which means I had to do it for her. She even had the balls to snap at me when I called her on it. What. An. Asshole. ",
            "1 4 12 00 00 3 I also had to deal with the rent, which she promptly “forgot” to show up for, meaning she had to pay me back later. What the hell is the point in that, just to stick it to me? So frustrating. To be fair, I did put myself in this position. ",
            "0 2 11 00 00 3 Yea, you told me you chose to move out of your parents place so you could get a fresh start. You had the cards stacked against you from the start, so the fact that you are able to have prospects in life and a plan to achieve said prospects is impressive in and of itself.",
            "1 2 11 00 00 3 Thanks V, that means a lot. Shit we have to get going, people are starting to flood in. Go get dressed and take as many tables as you can handle. We are probably going to be busy, so if you try your best you will probably get a good amount of tip money. ",
            "0 2 00 00 00 3 Sounds good. See you out there boss."
            });

        dialogue.Add(new string[] {
            "8 0 00 00 00 3 excuse me…….hello??? EXCUSE ME.",
            "0 2 00 00 00 3 Sorry sir, I was just helping another table. What can I help you with?",
            "8 0 00 00 00 3 I demand a complete refund! I asked for a medium steak and what I got tastes like a FUCKING campfire. I don’t even want a new one because you imbeciles will probably screw it up again! Give me my money back unless you want to lose a customer forever!",
            "0 8 00 00 00 3 But sir, you have eaten almost the entire st….",
            "8 0 00 00 00 3 Are you trying to mock me? What the hell do you know, you’re just a dumb waitress who is shit at her job. I demand to see your manager right now!",
            "0 0 00 00 00 3 (What a prick! He thinks getting Ashley will help him but she’s just gonna rip him a new one. Can’t wait to see that.)",
            "0 5 00 00 00 3 Right away sir.",
            "0 4 00 00 00 3 (These are the types of customers that get people questioning if they are in the wrong profession. I would much rather work a backend position so I wouldn’t have to deal with a douchebag like him but it doesn’t pay as well, and I need the money so I can make ends meet.)",
            "0 4 00 00 00 3 (Where the hell did Ashley go?)",
            "0 4 00 00 00 3 Ashley? Where are you? ",
            "1 4 11 00 00 3 Sorry I just had a huge chatterbox of a customer. Nice lady though. What’s the matter?",
            "0 4 11 00 00 3 This is gonna bring your mood down, but you’re gonna have to deal with a Class A miserable customer at table 7",
            "1 4 10 00 00 3 How bad? ",
            "0 0 10 00 00 3 Listening to him makes me want to cut my ears off with a rusty pair of scissors",
            "1 0 12 00 00 3 Well that’s just lovely. What’s the problem with him? ",
            "0 2 12 00 00 3 Oh, I don’t wanna spoil the fun. I just want to wait and see what happens. ",
            "0 2 11 00 00 3 What seems to be the problem sir? ",
            "8 0 11 00 00 3 This moron of a waitress didn’t give me a full refund when I asked for it. This steak is way too overcooked even though I only asked for medium rarity. It is repulsing and you will be losing a lifetime of my business if you do not refund this mockery of a steak.",
            "1 0 10 00 00 3 Oh is that all? Well let me tell you two things. First off, Victoria here is not the moron in the situation, you are. Secondly, do you really expect us to refund a steak when you have basically only left crumbs left? You are just trying to get a free meal and that isn’t happening.",
            "8 0 10 00 00 3 How appalling. You can’t treat a customer like that! Haven’t you heard that the customer is always right? Give me my money back NOW or else I am walking out and never coming back. ",
            "1 0 10 00 00 3 We have enough regulars where your input has no value at all. If you don’t want to eat here, don’t. But if you ever try to disrespect and demean our workers ever again I will have you TOSSED out of here. ",
            "1 0 10 00 00 3 Also, If I told you the workers at an establishment were always right, would you believe me? Unlikely. That is how pretty much any worker views that wild claim. ",
            "1 0 10 00 00 3 We don’t want your business, so get the hell out. If you don’t pay we could always track you by that beater car you have out in the lot. Please don’t come back.",
            "1 0 11 00 00 3 Victoria lets go, we have more work to do. ",
            "0 2 00 00 00 3 (Man, that was better than I thought it was going to be. Always fun to see Ashley get serious.) "
            });

        dialogue.Add(new string[] {
            "3 3 30 00 00 0 In late as usual. Managing a part time position that ends late as well as a university program is insane. If you need a shoulder to lean on, please let me know. ",
            "0 2 30 00 00 0 Thanks O and you better believe I’m eventually taking you up on that offer to be your snuggle buddy. ",
            "0 2 30 00 00 0 Sounds good. I’m going to get some rest, just wanted to make sure you got in safe. Make sure to be up in time for our team meeting tomorrow. We will just call Chris and do it online to make it easier. ",
            "0 2 00 00 00 0 Will do. Have a good night. ",
            "0 6 00 00 00 0 (Time to get some rest.)"
            });
        /*
         * 
         * dialogue.Add(new string[] {
            
            });
         * 
        //Dialogue 1
        dialogue.Add(new string[] { "0 0 00 00 00 Hola", "0 1 00 00 00 Soy Victoria", "0 3 00 00 00 Donde esta la bibliotecha?" });

        //Dialogue 2
        dialogue.Add(new string[] { "0 4 00 00 00 Just making sure this works", "0 5 00 00 00 Because it's good to double check code you know?", "1 6 10 00 00 Yea I feel you" });

        /*Work
        events.Add(new Event(
            new Option("Work as Usual", 200, -5, 0, -0.25f, new string[] { "0 2 00 00 00 Nothing out of the ordinary" }),
            new Option("Take it Easy", 120, 5, 0, 0, new string[] { "0 2 00 00 00 Easy day today" }),
            new Option("Bust Yo' ASS", 350, -15, 0, -0.6f, new string[] { "0 2 00 00 00 That was hard work!" })));
        

        //Dialogue 3
        dialogue.Add(new string[] { "0 4 00 00 00 What should I wish for?" });

        //Event 1
        events.Add(new Event(
             new Option("Mental", 10f, 0f, 0f, 0f, new string[] { "0 2 00 00 00 I feal healthier already!" }),
             new Option("Academic", 0f, 0f, 0.5f, 0f, new string[] { "0 2 00 00 00 I am very studious!" }),
             new Option("Money", 0f, 2000f, 0f, 0f, new string[] { "0 2 00 00 00 I'm riiiiiiiiich!" })));

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
             new Option("I'll pick up another shift", 2, new string[] { "0 3 00 00 00 That shift was exhausting..." }),
             new Option("Metroid Prime is 'Echoing' for me", 25, 0f, 0f, -0.25f, new string[] { "0 4 00 00 00 I love this franchise." })));

        //Dialogue 7
        dialogue.Add(new string[] { "0 8 00 00 00 Tough lesson", "0 9 00 00 00 Gonna go home now!" });

        //Dialogue 8
        dialogue.Add(new string[] { "9 0 00 00 00 I'm a one off to progress the characters story!", "0 0 00 00 00 Shut up! You're are irrelevant!", "0 5 00 00 00 Anyways, time for bed" });
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
