using System.Collections.Generic;
//Structure for the events themselves
public struct Event
{
    public Option option1;
    public Option option2;
    public Option option3;

    //Constructor that stores the relevant stats of the event if it has choices
    public Event (Option option1, Option option2, Option option3)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
    }
}
//STRUCTURES -------------------------------------------------------------------
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
}



