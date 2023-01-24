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
            new Option("Help them", 0, 5f, 0.02f, -0.1f, "05Well, glad they figured it out, and I feel good about helping. Unfortunately, I also lost all the extra time I had. Guess I知 eating lunch in a hurry again or I値l be late for the meeting for my group project."), 
            new Option("Sorry, I don't have tme, ask the prof", 0f, 0f, 0f, 0.1f, "03I don稚 want to be rude but I知 way too tired, the prof is literally right there to help and will probably give better advice than I could. I just really need some time to myself to collect my thoughts."), 
            new Option("Open something...anything...then say you're busy", 0, 5f, 0.02f, -0.1f, "04Funny how that works, by pretending to work on something for half an hour I was actually pretty productive. I do feel kinda bad though� just a little."),
            new string[6] { "90�Ok does everyone understand the exercise? Great. I値l be in class for another half hour if anyone needs help.", "05*Yawns*", "02Glad the exercise is something I already know, I can get it done in 5 minutes and leave class early. It would be nice to get a longer lunch break for once-",
            "90Um, excuse me?", "01Huh? Sorry, whats up?", "90I知 a little confused by the exercise, could you help me out quickly?"}));
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
    public string response;

    //Constructor for the options that stores all the relevant stats
    public Option(string optionText, float valueMentalHealth, float valueMoney, float valueAcademic, float energy, string response)
    {
        this.optionText = optionText;
        this.valueAcademic = valueAcademic;
        this.valueMentalHealth = valueMentalHealth;
        this.valueMoney = valueMoney;
        this.energy = energy;
        this.response = response;
    }
}

//Structure for the events themselves
public struct Event
{
    public Option option1;
    public Option option2;
    public Option option3;
    public string[] dialogue;

    //Constructor that stores the relevant stats of the event if it has choices
    public Event (Option option1, Option option2, Option option3, string[] dialogue)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
        this.dialogue = dialogue;
    }
}


