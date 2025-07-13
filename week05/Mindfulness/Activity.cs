using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    //this sets up to be used in every activity to make activity name and discription desplaying quicker because I just input after base
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    //The starting message that will be displayed in every activity
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description + "\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner();
    }

    //the ending message will display at the end of every activity
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner();
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner();
    }

    //The display animations video in the mindfullness program decription made this easy because I pretty much just copied it (thank you!)
    public void ShowSpinner()
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(10);

        int i = 0;

        while (DateTime.Now < end)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }

    }

    //counting from seconds down to one in a loop until it is done
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
