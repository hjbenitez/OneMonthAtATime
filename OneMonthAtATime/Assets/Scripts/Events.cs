using System.Collections.Generic;

public class Events
{
    List<Event> events;

    public Events()
    {
        events = new List<Event>();

        //Add new events under here

        //School Event - Classmate asks for help
        events.Add(new Event(
            new Option("Help them", 0, 5f, 0.02f, -0.1f, new string[1] { "05Well, glad they figured it out, and I feel good about helping. Unfortunately, I also lost all the extra time I had. Guess I’m eating lunch in a hurry again or I’ll be late for the meeting for my group project." }),
            new Option("Sorry, I don't have time, ask the prof", 0f, 0f, 0f, 0.1f, new string[1] { "03I don’t want to be rude but I’m way too tired, the prof is literally right there to help and will probably give better advice than I could. I just really need some time to myself to collect my thoughts." }),
            new Option("Open something...anything...then say you're busy", 0, 5f, 0.02f, -0.1f, new string[1] { "04Funny how that works, by pretending to work on something for half an hour I was actually pretty productive. I do feel kinda bad though… just a little." }),
            new string[6] { "90…Ok does everyone understand the exercise? Great. I’ll be in class for another half hour if anyone needs help.", "05*Yawns*", "02Glad the exercise is something I already know, I can get it done in 5 minutes and leave class early. It would be nice to get a longer lunch break for once-",
            "90Um, excuse me?", "01Huh? Sorry, whats up?", "90I’m a little confused by the exercise, could you help me out quickly?"}));

        //Work Event - Mean Customer
        events.Add(new Event(
            new string[] {"90excuse me…….hello??? EXCUSE ME.", "02Sorry sir, I was just helping another table. What can I help you with?", "90I demand a complete refund! I asked for a medium steak and what I got tastes like a FUCKING campfire. I don’t even want a new one because you imbeciles will probably screw it up again! Give me my money back unless you want to lose a customer forever!",
            "01But sir, you have eaten almost the entire st….", "90Are you trying to mock me? What the hell do you know, you’re just a dumb waitress who is shit at her job. I demand to see your manager right now!", "00What a prick! He thinks getting Ashley will help him but she’s just gonna rip him a new one. Can’t wait to see that.",
            "03Right away sir.", "06These are the types of customers that get people questioning if they are in the wrong profession. I would much rather work a backend position so I wouldn’t have to deal with a douchebag like him but it doesn’t pay as well, and I need the money so I can make ends meet.", "06Where the hell did Ashley go?",
            "03Ashley? Where are you?", "13Sorry I just had a huge chatterbox of a customer. Nice lady though. What’s the matter?", "03This is gonna bring your mood down, but you’re gonna have to deal with a Class A miserable customer at table 7", "13How bad?", "00Listening to him makes me want to cut my ears off with a rusty pair of scissors",
            "13Well that’s just lovely. What’s the problem with him?", "02Oh, I don’t wanna spoil the fun. I just want to wait and see what happens.", "12What seems to be the problem sir?", "90This moron of a waitress didn’t give me a full refund when I asked for it. This steak is way too overcooked even though I only asked for medium rarity. It is repulsing and you will be losing a lifetime of my business if you do not refund this mockery of a steak.",
            "10Oh is that all? Well let me tell you two things. First off, Victoria here is not the moron in the situation, you are. Secondly, do you really expect us to refund a steak when you have basically only left crumbs left? You are just trying to get a free meal and that isn’t happening.", "00How appalling. You can’t treat a customer like that! Haven’t you heard that the customer is always right? Give me my money back NOW or else I am walking out and never coming back.",
            "10We have enough regulars where your input has no value at all. If you don’t want to eat here, don’t. But if you ever try to disrespect and demean our workers ever again I will have you TOSSED out of here.", "10Also, If I told you the workers at an establishment were always right, would you believe me? Unlikely. That is how pretty much any worker views that wild claim.", "10We don’t want your business, so get the hell out. If you don’t pay we could always track you by that beater car you have out in the lot. Please don’t come back.",
            "12Victoria lets go, we have more work to do.", "02Man, that was better than I thought it was going to be. Always fun to see you get serious."}));
    }

    public Event getEvent(int i)
    {
        return events[i];
    }
}


//Structure for the options in the events
public struct Option
{
    public string optionText;
    public float valueMentalHealth;
    public float valueMoney;
    public float valueAcademic;
    public float energy;
    public string[] response;

    //Constructor for the options that stores all the relevant stats
    public Option(string optionText, float valueMentalHealth, float valueMoney, float valueAcademic, float energy, string[] response)
    {
        this.optionText = optionText;
        this.valueAcademic = valueAcademic;
        this.valueMentalHealth = valueMentalHealth;
        this.valueMoney = valueMoney;
        this.energy = energy;
        this.response = response;
    }

    //constructor when there are no options
    public Option(int value)
    {
        value = 0;
        this.optionText = null;
        this.valueAcademic = value;
        this.valueMentalHealth = value;
        this.valueMoney = value;
        this.energy = value;
        this.response = null;
    }
}

//Structure for the events themselves
public struct Event
{
    public Option option1;
    public Option option2;
    public Option option3;
    public bool options;
    public string[] dialogue;

    //Constructor that stores the relevant stats of the event if it has choices
    public Event (Option option1, Option option2, Option option3, string[] dialogue)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
        this.dialogue = dialogue;
        this.options = true;
    }

    public Event (string[] dialogue)
    {
        this.option1 = new Option(0);
        this.option2 = new Option(0);
        this.option3 = new Option(0);
        this.dialogue = dialogue;
        this.options = false;
    }
}


