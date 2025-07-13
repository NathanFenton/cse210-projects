using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private int _count = 0;
    private Random _rand = new Random();

    //The name and discription for the listing activity
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---\n");

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int prompt = _rand.Next(_prompts.Count);
        return _prompts[prompt];
    }
}

