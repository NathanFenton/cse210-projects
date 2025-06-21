using System;
using System.Collections.Generic;

public class PromptGenerator
{
    //List of prompts
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Did I serve someone today?",
        "Did I learn something today?"
    };

    public string GetRandomPrompt()
    {
        //I was having a hard time trying to figure out the random class, so I learned the following:
        //I then learned that I need Next because it chooses a number between 0 and the number of items in the list
        //I used .count in python, so I learned how it works in C#
        //Then finally I put the int num (which would just be a random number 0 through 6)-
        //in the square brackets to pick it from the the corosponding spot in the list of prompts
        Random rnd = new Random();
        int num = rnd.Next(_prompts.Count);
        return _prompts[num];
    }
}