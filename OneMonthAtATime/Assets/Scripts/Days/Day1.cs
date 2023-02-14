using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : Day
{
     List<string[]> dialogue;
     List<Event> events;

     Event work;
     int hours = 5;
     string[] schedule;

     public Day1()
     {
          dialogue = new List<string[]>();
          events = new List<Event>();
          schedule = new string[] { "0Dialogue", "1Dialogue", "1School", "1Dialogue", "1Freetime", "2Dialogue", "2School", "0Dialogue", "0End"  };

          //Intro - Meeting Harry and Olivia
          dialogue.Add(new string[] {
               "5 3 50 00 00 Welcome to your new place. I’m gonna get straight to the point. I’m your landlord, Harry and I have a few ground rules you ladies need to follow while you stay here.",
               "5 3 50 00 00 I am well aware that you are college students, so if I hear a rave or party of any kind I will not be happy. Be aware that you are living in an APARTMENT, not a frat house. ",
               "5 3 50 00 00 I am letting you live here for a reasonable amount, and because of this I am responsible for your actions. I will not accept you tarnishing my great reputation by being arrogant and careless college brats. ",
               "5 3 50 00 00 I am not your friend, and as long as you don’t cause problems our relationship will work. I don’t want to hear complaining about rent costs or how the building is managed. Rent will be paid at the end of the month, and NO later. If you don’t pay up by the last day of every month, I will kick you to the curb without hesitation. Have I made myself clear? ",
               "0 5 50 00 00 Crystal.",
               "3 3 00 50 30 ye….yes sir. ",
               "5 3 00 50 30 Tell your friend to speak up, she sounds like a stuttering buffoon.",
               "0 0 30 00 00 What a lovely fellow. If anyone’s a buffoon it's the one drenched in that cheap ass cologne. You ok, Olivia?",
               "3 3 30 00 00 They are but they are always so cheery and outgoing, the complete opposite of me. They do their best to accommodate my shy personality, but I can see how it just drains them. I don’t want to be a burden to them, so now I'm your problem.",
               "3 3 30 00 00 I know your financial situation is…..complicated. How are you managing?",
               "0 3 30 00 00 My parents live about 3 hours away, and busing that distance for a regular commute would literally be impossible. My parents couldn’t afford to get me a place out here so I am working hard at the restaurant down the street to make ends meet one month at a time. ",
               "0 4 30 00 00 Thankfully, I qualify for student loans so I can actually attend our program. I know I will be pretty much screwed once I get into the real world, though. ",
               "0 9 30 00 00 9 Shit, look at the time! We gotta haul ass to get to campus on time for class. Let’s settle into the place later."
          });

          //At School with Olivia
          dialogue.Add(new string[] {
               "3 3 30 00 00 Made it……just in……time. Good lord am I out of shape.",
               "0 6 30 00 00 You and me both! We would have had more time if poppa smurf didn’t lecture us about basic living standards.",
               "0 3 30 00 00 Let’s see what we are going to learn today. I’m not too tired so I could try my best, but that takes effort, and who likes that. I have a long day today, so I could slack off but I’ll probably miss a bunch of important stuff. Hmmm."
          });

          //School Choice 
          events.Add(new Event(
               new Option("Pay Attention", -5, 0, 0.1f, -0.1f, new string[] { "0 2 30 00 00 One class down, one to go. Hey Olivia, what are you getting up to? ?" }),
               new Option("Take Notes", -20, 0, 0.1f, -0.5f, new string[] { "0 2 30 00 00 One class down, one to go. Hey Olivia, what are you getting up to? " }),
               new Option("Slack Off", 10, 0, -0.05f, 0f, new string[] { "0 2 30 00 00 One class down, one to go. Hey Olivia, what are you getting up to? " })));

          //Post Class with Olivia
          dialogue.Add(new string[] {
               "3 3 30 00 00 I have to catch up on some menial work for tomorrow’s class, so I'll probably hang back here at the school.",
               "0 5 30 00 00 Figures, you friggin studyholic.  ",
               "0 1 00 00 00 (Olivia is really smart, and I could use her help with some schoolwork. I also really need to start making some money so I can afford rent this month. I’m sure Ashley wouldn’t mind having an extra hand for some of the dinner rush.)",
               "0 1 00 00 00 (Then again, I totally need to catch up with that new show. I’m a couple weeks behind and if I see any spoilers I'm gonna be pissed.)",
               "0 3 00 00 00 Let’s see…"
          });

          //Freetime
          events.Add(new Event(
                 new Option("Grab a shift at the restaurant ", 3, new string[] { "0 3 00 00 00 I’m gonna get some extra hours at the restaurant to get a jump start on this month. See you in a bit." }),
                 new Option("Study with Olivia", 0, 0, 0.5f, -0.5f, new string[] { "0 3 00 00 00 Hey O, mind if I tag along? I’ve been putting off that exercise for too damn long and I could use some help understanding what to do.", "3 3 30 00 00 Yea, that one was pretty annoying. Working together will make time fly. " }),
                 new Option("Go home and bing", 0, 10, 0f, -0.2f, new string[] { "0 2 30 00 00 I’m gonna head back to our place to grab some grub and catch up on that show we have been watching. I’m a little behind.", "3 3 30 00 00 Oh yea the newest episode is awesome! Your favorite character gets….", "0 0 30 00 00 Not another word." })));

          //After Freetiime, going to school
          dialogue.Add(new string[] {
               "0 6 00 00 00 (One more class till I can go home and relax. MAAAAN it’s been a long day. Let’s see if I have enough energy left in the tank to really pay attention.)"
          });

          //School Event
          events.Add(new Event(
               new Option("Pay Attention", -5, 0, 0.1f, -0.1f, new string[] { "0 5 00 00 00 ..." }),
               new Option("Take Notes", -20, 0, 0.1f, -0.5f, new string[] { "0 5 00 00 00 ..." }),
               new Option("Slack Off", 10, 0, -0.05f, 0f, new string[] { "0 5 00 00 00 ..." })));

          dialogue.Add(new string[] {
               "3 3 30 00 00 Being at school all day really takes it out of me. I am completely worn out. Time to hit the sack and prepare for tomorrow. See you in the morning.",
               "0 6 00 00 00 ‘Night Olivia.",
               "0 6 00 00 00  (Alright that is enough work for one day. I should get some rest considering we have two classes again tomorrow. The grind begins.)"
          });

          /*
          //Opening Dialogue about the playtest
          dialogue.Add(new string[] { "0 2 00 00 00 Welcome fellow playtesters to One Month at a Time, a game where you get to play as me who is a struggling student trying to make ends meet one month at a time.",
               "0 2 00 00 00 Throughout this game you will have to manage 3 main resources, these being Money, Academic Standing, and Mental Health, with Money being the most important resource of all.",
               "0 2 00 00 00 If I don’t accrue enough money by the end of the month I will be homeless, and I really don’t want to be booted to the streets! This small sample of the game will consist of two random days in the middle of the game, so let’s see how I do!",
               "0 6 00 00 00 Maaaaaan, they seriously expect us to get up, get to school, and be awake and competent for class at 10am? They do know we are all gamers, right? 5 hours of sleep is not enough!",
               "0 6 00 00 00 Not only that, but I have work after this. What. A. Drag. How does our government expect college students to spend a crazy amount of money for tuition, a place to live, and on top of that inflated grocery prices! It just isn’t fair.",
               "0 5 00 00 00 There will be the people who say “well that’s life, and life isn’t fair” but does it really have to be that way? That’s just a bullshit cop out answer people give because they refuse to look further into the issue.",
               "0 5 00 00 00 How will this crazy economy continue into the future if the cost of living continues to rise at exponential rates but earnings stay the same?",
               "0 5 00 00 00 Whatever. This dirty and destructive cycle of burning the wick at both ends will never stop as long as humans remain greedy creatures. I gotta focus on class right now, the daily existential crisis can wait till later."});

          //Event - School
          events.Add(new Event(
               new Option("Pay Attention", -5, 0, 0.1f, -0.1f, new string[] { "0 1 00 00 00 Dark patterns huh?" }),
               new Option("Take Notes", -20, 0, 0.1f, -0.5f, new string[] { "0 2 00 00 00 Always good to get a head start on the assignment!" }),
               new Option("Slack Off", 10, 0, -0.05f, 0f, new string[] { "0 4 00 00 00 Man I hope this Nintendo Direct shows Metriod Prime 4" })));

          //Dialogue with Ashley before Victoria's shift
          dialogue.Add(new string[] { "0 2 00 00 00 Hey Ashley, sorry I'm late. I had to deal with my impatient landlord. You having a good week?",
               "1 2 12 00 00 Eh, it's been alright. I’ve been getting as many hours as I can but I’m getting pretty tired already. Dealing with people everyday gives you great social skills, but man does it ever drain your battery.",
               "0 3 12 00 00 Ever consider getting another position that is less taxing? Knowing you, adapting to pretty much anything will be a breeze.",
               "0 4 12 00 00 Really wish I could, but I have done the calculations and the hours I get here plus the amount of money in tips I am making really makes a difference compared to other jobs around here.",
               "1 4 13 00 00 I also have to stay close. Bussing from my place to here and back is already costly enough, and I live close!",
               "1 4 13 00 00 Anyways, you know I’m just here until I can save up enough for a 2 year program. As soon as I reach that magic number, I’m getting the hell outta this place!",
               "1 4 13 00 00 We gotta prep for the dinner rush. Let’s talk more later.",
               "0 1 00 00 00 I should probably start working as well."});

          /*Work
          work = new Event(
              new Option("Work as Usual", -5, 5 * 15.5f * 1.25f, 0, -0.25f, new string[] { "0 2 00 00 00 That table is always nice" }),
              new Option("Take it Easy", 5, 5 * 15.5f, 0, 0, new string[] { "0 2 00 00 00 hmhm hmhm hm hm hmmmmmmm hmhm hmhm hm hm hmmmmmmm" }),
              new Option("Bust Yo' ASS", -15, 5 * 15.5f * 1.4f, 0, -0.6f, new string[] { "0 2 00 00 00 Made a lot of tips so far!" }));
          
          //Event - Rude Customer with Ashley 
          dialogue.Add(
            new string[] {
               "9 2 00 00 00 excuse me…….hello??? EXCUSE ME.",
               "0 2 00 00 00 Sorry sir, I was just helping another table. What can I help you with?",
               "9 1 00 00 00 I demand a complete refund! I asked for a medium steak and what I got tastes like a FUCKING campfire. I don’t even want a new one because you imbeciles will probably screw it up again! Give me my money back unless you want to lose a customer forever!",
               "0 1 00 00 00 But sir, you have eaten almost the entire st….",
               "9 1 00 00 00 Are you trying to mock me? What the hell do you know, you’re just a dumb waitress who is shit at her job. I demand to see your manager right now!",
               "0 0 00 00 00 What a prick! He thinks getting Ashley will help him but she’s just gonna rip him a new one. Can’t wait to see that.",
               "0 3 00 00 00 Right away sir.",
               "0 6 00 00 00 These are the types of customers that get people questioning if they are in the wrong profession.",
               "0 6 00 00 00 I would much rather work a backend position so I wouldn’t have to deal with a douchebag like him but it doesn’t pay as well, and I need the money so I can make ends meet.",
               "0 6 00 00 00 Where the hell did Ashley go?",
               "0 3 00 00 00 Ashley? Where are you?",
               "1 3 13 00 00 Sorry I just had a huge chatterbox of a customer. Nice lady though. What’s the matter?",
               "0 3 13 00 00 This is gonna bring your mood down, but you’re gonna have to deal with a Class A miserable customer at table 7",
               "1 3 13 00 00 How bad?",
               "0 0 13 00 00 Listening to him makes me want to cut my ears off with a rusty pair of scissors",
               "1 0 13 00 00 Well that’s just lovely. What’s the problem with him?",
               "0 2 13 00 00 Oh, I don’t wanna spoil the fun. I just want to wait and see what happens.",
               "1 2 12 00 00 What seems to be the problem sir?",
               "9 3 12 00 00 This moron of a waitress didn’t give me a full refund when I asked for it. This steak is way too overcooked even though I only asked for medium rarity. It is repulsing and you will be losing a lifetime of my business if you do not refund this mockery of a steak.",
               "1 3 10 00 00 Oh is that all? Well let me tell you two things. First off, Victoria here is not the moron in the situation, you are. Secondly, do you really expect us to refund a steak when you have basically only left crumbs left?",
               "1 3 10 00 00 You are just trying to get a free meal and that isn’t happening.",
               "9 3 10 00 00 How appalling. You can’t treat a customer like that! Haven’t you heard that the customer is always right? Give me my money back NOW or else I am walking out and never coming back.",
               "1 3 10 00 00 We have enough regulars where your input has no value at all. If you don’t want to eat here, don’t. But if you ever try to disrespect and demean our workers ever again I will have you TOSSED out of here.",
               "1 3 10 00 00 Also, If I told you the workers at an establishment were always right, would you believe me? Unlikely. That is how pretty much any worker views that wild claim.",
               "1 3 10 00 00 We don’t want your business, so get the hell out. If you don’t pay we could always track you by that beater car you have out in the lot. Please don’t come back.",
               "1 3 12 00 00 Victoria lets go, we have more work to do.",
               "0 2 00 00 00 Man, that was better than I thought it was going to be. Always fun to see you get serious."});

          //Dialgoue before Victoria goes to bed
          dialogue.Add(new string[] { "0 6 00 00 00 All in all, a pretty tame day minus the ridiculous customer that came in. Tomorrow I have some free time, so I guess I’ll choose what to do based on how the day goes. " });
          */
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