using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4 : Day
{
    List<string[]> dialogue;
    List<Event> events;

    string[] schedule;
    int hours = 5;

    public Day4()
    {
        dialogue = new List<string[]>();
        events = new List<Event>();
        schedule = new string[] { "Dialogue", "Freetime", "Dialogue", "Work", "Dialogue", "End" };

        dialogue.Add(new string[] {
            "0 6 00 00 00 0 Another day another dolla…..",
            "0 8 00 00 00 0 WHAHAHA Chris what the hell are you doing at my place this early? ",
            "4 8 40 00 00 0 You don’t remember our beautiful night? The amorous activities we got up to are etched into my memories forever. The least you could do is cook me breakfast!",
            "0 0 40 00 00 0 If you were the last man on earth, I would kill you even if that meant the end of humanity. ",
            "4 0 40 00 00 0 So cold! ",
            "3 3 00 40 30 0 When I told him we would do the meeting online h-he said he was on his way o-over.",
            "0 3 00 40 30 0 Figured as much. Let’s just get right to work.",
            "4 3 00 40 30 0 Alright ladies good meeting! Am I getting the boot or should we all chill out for a bit? ",
            "0 0 00 40 30 0 Considering the ridiculous stunt you pulled earlier I should give you the boot, but…"
            });

        events.Add(new Event(
               new Option("Hangout with the gang", 15, 0, 0, -10, new string[] { 
                   "3 3 00 40 30 0 I would like t-to hang out while everyone’s here.",
                   "4 3 00 40 30 0 Olivia to the rescue! Guess she is warming up to me after all. Time to show my gaming prowess! I’m not a nice enough guy to hold off against you guys, so be prepared to be demolished. ", 
                   "0 7 00 40 30 0 Chris not being a gentleman? Who would have thought.", 
                   "4 7 00 40 30 0 Simmer down there Veronica." }),
               new Option("Continue working on the assignment", 0, 0, 15, -50, new string[] { 
                   "0 3 00 40 30 0 We should probably crunch down on some more work since we are all here. Hanging out would probably be the fun thing to do, but getting ahead is more important.", 
                   "3 3 00 40 30 0 I-I would have to agree.", 
                   "4 3 00 40 30 0 Aye-aye captain!" }),
               new Option("Give Chris the boot", -10, 0, 0, 0, new string[] { 
                   "0 0 00 40 30 0 Nah, I’m still pissed from earlier. You’re getting the boot.", 
                   "4 0 00 40 30 0 If it’s from you I will be happy to oblige.", 
                   "0 0 00 40 30 0 Get the hell out." })));

        dialogue.Add(new string[] {
            "1 3 11 00 00 3 Look what the cat dragged in.",
            "0 1 11 00 00 3 You tease me like an elementary kid with a crush in the schoolyard. Is there something you want to get off your chest? I don’t do too bad with the cougars? ",
            "1 1 10 00 00 3 Cougar? I’m only 23 and you would be LUCKY to land me. Sadly I don’t swing that way. ",
            "1 1 12 00 00 3 Time to get to work honey. Go suit up.",
            "0 1 00 00 00 3 Who am I, Iron man? "
            });

        dialogue.Add(new string[] {
            "3 2 30 00 00 0 Look what the cat dragged in.",
            "0 6 30 00 00 0 Yea yea I know it’s late.",
            "0 6 00 00 00 0 (Tomorrow is my first day off in this new place. If I’m bored I might take Ashley up on her offer. I could always use the money.)",
            "0 6 00 00 00 0 (As draining as work can be, it pays well and I really need the money so I can keep up with the rent due at the end of the month. I also don’t want to be living off of instant ramen for the foreseeable future.)"
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
}
