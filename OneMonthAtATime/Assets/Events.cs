struct Event
{
    public string name;
    public int id;
    public int valueMentalHealth;
    public int valueMoney;
    public float valueAcademic;

    public Event (string name, int id, int valueMentalHealth, int valueMoney, int valueAcademic)
    {
        this.name = name;
        this.id = id;
        this.valueMentalHealth = valueMentalHealth;
        this.valueMoney = valueMoney;
        this.valueAcademic = valueAcademic;
    }
}
