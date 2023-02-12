using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Day
{
     public abstract List<string[]> getDialogue();
     public abstract string[] getSchedule();
     public abstract List<Event> getEvents();
     public abstract int getHours();
}
