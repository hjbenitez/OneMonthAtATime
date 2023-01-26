using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2
{
    List<string[]> dialogue;
    List<string[]> workDialogue;
    List<string[]> gameDialogue;
    List<string[]> studyDialogue;

    public Day2()
    {
        dialogue = new List<string[]>();
        workDialogue = new List<string[]>();
        gameDialogue = new List<string[]>();
        studyDialogue = new List<string[]>();

        dialogue.Add(new string[] {"06Dude, another 10am lecture? I really shouldn’t have spent those extra hours binging that show I love. It’s so hard to turn off when you really get into it though, so I can’t blame myself. ",
            "06Pretty sure this class is going to be a boring one, but I can’t wait for the one I have later today. A 6pm class really throws my sense of time off."});

        dialogue.Add(new string[] { "03Looks like I have a bunch of free time today, as rare as that is. What should I do? I could probably pick up a half shift - I know I could use the money and the tips would probably be decent if I tried.",
        "03I could also study for the upcoming test - my skill for programming is non-existent. I could probably ask Olivia for help, she’s basically a genius at anything she applies herself in.",
        "02There is a new game out that I have been meaning to play - I could go home then come back for my last class."});

        dialogue.Add(new string[] { "02That’s all we have so far for this playtest folks. Hope you enjoyed playing and please let us know what we could potentially be doing better. This has been One Month at a Time, signing off."});

        workDialogue.Add(new string[] { "03I’ve only got half a shift so I doubt I will run into any issues."});
        workDialogue.Add(new string[] { "02Shift went by pretty quick and I made some decent money. I call that a pretty productive day. I am getting a little tired though." });
        workDialogue.Add(new string[] { "02This class should be pretty entertaining. Afterwards it is straight home and I am hitting the hay." });

        gameDialogue.Add(new string[] {"02Man, that game's narrative is enthralling. It is pretty tough at first but once you get the hang of it, it gets pretty simple. Almost lost track of time and showed up late.", "02This class should be pretty entertaining. Afterwards it is straight home and I am hitting the hay."});

        studyDialogue.Add(new string[] { "05God I hate studying for that class. Always such a snoozefest. I should be in pretty good shape for the next test, though.", "02This class should be pretty entertaining. Afterwards it is straight home and I am hitting the hay." });
    }

    public List<string[]> getDialogue()
    {
        return dialogue;
    }

    public string[] getWorkDialogue(int index)
    {
        return workDialogue[index];
    }

    public string[] getGameDialogue(int index)
    {
        return gameDialogue[index];
    }

    public string[] getStudyDialogue(int index)
    {
        return studyDialogue[index];
    }
}
