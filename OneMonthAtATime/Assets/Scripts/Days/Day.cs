using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Day
{
     public abstract List<string[]> getDialogue();
     public abstract string[] getSchedule();
     public abstract List<Event> getEvents();
     public abstract int getHours();
     public abstract List<string> getUniqueEvent(string[] updatedSchedule, int mental, int money, int academic, int energy);
     public abstract void addChoice(int choice);
}
