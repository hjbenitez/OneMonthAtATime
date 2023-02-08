using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Day 
{
    protected  List<string[]> dialogue;
     protected string[] schedule;
     protected List<Event> events;
     protected Event freetime;

     public abstract List<string> getDialogue();
     public abstract string[] getSchedule();
     public abstract List<Event> getEvents();
     public abstract Event getFreetime();
}
