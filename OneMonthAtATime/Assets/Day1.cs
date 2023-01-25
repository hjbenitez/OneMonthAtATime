using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1
{
    List<string[]> dialogue;

    public Day1()
    {
        dialogue = new List<string[]>();

        dialogue.Add(new string[] { "02Welcome fellow playtesters to One Month at a Time, a game where you get to play as me who is a struggling student trying to make ends meet one month at a time.",
        "02Throughout this game you will have to manage 3 main resources, these being Money, Academic Standing, and Mental Health, with Money being the most important resource of all. If I don’t accrue enough money by the end of the month I will be homeless, and I really don’t want to be booted to the streets! This small sample of the game will consist of two random days in the middle of the game, so let’s see how I do!", 
        "06Maaaaaan, they seriously expect us to get up, get to school, and be awake and competent for class at 10am? They do know we are all gamers, right? 5 hours of sleep is not enough!",
        "06Not only that, but I have work after this. What. A. Drag. How does our government expect college students to spend a crazy amount of money for tuition, a place to live, and on top of that inflated grocery prices! It just isn’t fair.",
        "05There will be the people who say “well that’s life, and life isn’t fair” but does it really have to be that way? That’s just a bullshit cop out answer people give because they refuse to look further into the issue. How will this crazy economy continue into the future if the cost of living continues to rise at exponential rates but earnings stay the same?",
        "05Whatever. This dirty and destructive cycle of burning the wick at both ends will never stop as long as humans remain greedy creatures. I gotta focus on class right now, the daily existential crisis can wait till later."});

        dialogue.Add(new string[] { "02Hey Ashley, sorry I'm late. I had to deal with my impatient landlord. You having a good week?", "12Eh, it's been alright. I’ve been getting as many hours as I can but I’m getting pretty tired already. Dealing with people everyday gives you great social skills, but man does it ever drain your battery.",
        "03Ever consider getting another position that is less taxing? Knowing you, adapting to pretty much anything will be a breeze.", "14Really wish I could, but I have done the calculations and the hours I get here plus the amount of money in tips I am making really makes a difference compared to other jobs around here.",
        "13I also have to stay close. Bussing from my place to here and back is already costly enough, and I live close!", "13Anyways, you know I’m just here until I can save up enough for a 2 year program. As soon as I reach that magic number, I’m getting the hell outta this place!",
        "13We gotta prep for the dinner rush. Let’s talk more later."});

        dialogue.Add(new string[] { "06All in all, a pretty tame day minus the ridiculous customer that came in. Tomorrow I have some free time, so I guess I’ll choose what to do based on how the day goes. " });
    }

    public List<string[]> getDialogue()
    {
        return dialogue;
    }
}
