using System;

public class BreathingActivity : Activity
{
    //The name and discription for the breathing activity
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            Console.Write("Now breathe out... ");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}

