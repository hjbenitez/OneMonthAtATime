using System.Collections.Generic;
//STRUCTURES -------------------------------------------------------------------
//Structure for the events themselves
public struct Event
{
    public Option option1;
    public Option option2;
    public Option option3;
    public int options;

     //Constructor that stores the relevant stats of the event if it has choices
     public Event(Option option1, Option option2, Option option3)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
        options = 3;
    }

    public Event(Option option1, Option option2)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option2;
        options = 2;
    }

    public Event(Option option1)
    {
        this.option1 = option1;
        this.option2 = option1;
        this.option3 = option1;
        options = 1;
    }
}
//Constructor used for when there is work

//Structure for the options in the events
public struct Option
{
    public string optionText;
    public float valueMentalHealth;
    public float valueMoney;
    public float valueAcademic;
    public float energy;
    public string[] response;
    public int toEvent;

    //Constructor for the options that stores all the relevant stats
    public Option(string optionText, float valueMentalHealth, float valueMoney, float valueAcademic, float energy, string[] response)
    {
        this.optionText = optionText;
        this.valueAcademic = valueAcademic;
        this.valueMentalHealth = valueMentalHealth;
        this.valueMoney = valueMoney;
        this.energy = energy;
        this.response = response;
        this.toEvent = 0;
    }

    public Option(string optionText, int toEvent, string[] response)
    {
        this.optionText = optionText;
        this.valueAcademic = 0;
        this.valueMentalHealth = 0;
        this.valueMoney = 0;
        this.energy = 0;
        this.response = response;
        this.toEvent = toEvent;
    }
}



