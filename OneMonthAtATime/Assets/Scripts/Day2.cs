using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2 : Day
{
    List<string[]> dialogue;
    List<Event> events;

    Event freetime;
    string[] schedule;

    public Day2()
    {
        dialogue = new List<string[]>();
        events = new List<Event>();
        schedule = new string[] { "Dialogue", "School", "Dialogue", "Event", "Dialogue", "Freetime", "School", "Dialogue", "End" };

        //Dialogue 1
        dialogue.Add(new string[] {"06Dude, another 10am lecture? I really shouldn’t have spent those extra hours binging that show I love. It’s so hard to turn off when you really get into it though, so I can’t blame myself. ",
            "06Pretty sure this class is going to be a boring one, but I can’t wait for the one I have later today. A 6pm class really throws my sense of time off."});

        //School
        events.Add(new Event(
               new Option("Pay Attention", 0, -2, 0.1f, -0.1f, new string[] { "01Dark patterns huh?" }),
               new Option("Take Notes", 0, -6, 0.1f, -0.5f, new string[] { "02Always good to get a head start on the assignment!" }),
               new Option("Slack Off", 0, 4, -0.05f, 0f, new string[] { "04Man I hope this Nintendo Direct shows Metriod Prime 4" })));

        //Dialogue 2
        dialogue.Add(new string[] { "90…Ok does everyone understand the exercise? Great. I’ll be in class for another half hour if anyone needs help.", "05*Yawns*", "02Glad the exercise is something I already know, I can get it done in 5 minutes and leave class early. It would be nice to get a longer lunch break for once-",
            "90Um, excuse me?", "01Huh? Sorry, whats up?", "90I’m a little confused by the exercise, could you help me out quickly?" });

        //Event - Student asks for help
        events.Add(new Event(
            new Option("Help them", 0, 5f, 0.02f, -0.1f, new string[] { "05Well, glad they figured it out, and I feel good about helping. Unfortunately, I also lost all the extra time I had. Guess I’m eating lunch in a hurry again or I’ll be late for the meeting for my group project." }),
            new Option("Sorry, I don't have time, ask the prof", 0f, 0f, 0f, 0.1f, new string[] { "03I don’t want to be rude but I’m way too tired, the prof is literally right there to help and will probably give better advice than I could. I just really need some time to myself to collect my thoughts." }),
            new Option("Open something...anything...then say you're busy", 0, 5f, 0.02f, -0.1f, new string[] { "04Funny how that works, by pretending to work on something for half an hour I was actually pretty productive. I do feel kinda bad though… just a little." })));

        //Dialogue 3 - Freetime lead up
        dialogue.Add(new string[] { "03Looks like I have a bunch of free time today, as rare as that is. What should I do? I could probably pick up a half shift - I know I could use the money and the tips would probably be decent if I tried.",
        "03I could also study for the upcoming test - my skill for programming is non-existent. I could probably ask Olivia for help, she’s basically a genius at anything she applies herself in.",
        "02There is a new game out that I have been meaning to play - I could go home then come back for my last class."});

        //Event Freetime
        events.Add(new Event(
               new Option("Pickup a shift", 0, -2, 0.1f, -0.1f, new string[] { "03I’ve only got half a shift so I doubt I will run into any issues.", "02Shift went by pretty quick and I made some decent money. I call that a pretty productive day. I am getting a little tired though.", "02This class should be pretty entertaining. Afterwards it is straight home and I am hitting the hay." }),
               new Option("Study with Olivia", 0, -6, 0.1f, -0.5f, new string[] { "05God I hate studying for that class. Always such a snoozefest. I should be in pretty good shape for the next test, though.", "02This class should be pretty entertaining. Afterwards it is straight home and I am hitting the hay." }),
               new Option("Play that new game", 0, 4, -0.05f, 0f, new string[] { "02Man, that game's narrative is enthralling. It is pretty tough at first but once you get the hang of it, it gets pretty simple. Almost lost track of time and showed up late.", "02This class should be pretty entertaining. Afterwards it is straight home and I am hitting the hay."})));

        //School Event
        events.Add(new Event(
               new Option("Pay Attention", 0, -2, 0.1f, -0.1f, new string[] { "01Dark patterns huh?" }),
               new Option("Take Notes", 0, -6, 0.1f, -0.5f, new string[] { "02Always good to get a head start on the assignment!" }),
               new Option("Slack Off", 0, 4, -0.05f, 0f, new string[] { "04Man I hope this Nintendo Direct shows Metriod Prime 4" })));

        //Dialogue 4 - ending playtest
        dialogue.Add(new string[] { "02That’s all we have so far for this playtest folks. Hope you enjoyed playing and please let us know what we could potentially be doing better. This has been One Month at a Time, signing off." });
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

    public override Event getFreetime()
    {
        return freetime;
    }
}
