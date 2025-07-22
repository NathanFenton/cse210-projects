using System;
using System.Collections.Generic;

//there is not much new things that I learned while making this program
//I just used knowledge that I already had, and was able to build the program
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(DateTime.Now, 30, 3.0));
        activities.Add(new Cycling(DateTime.Now, 45, 15.0));
        activities.Add(new Swimming(DateTime.Now, 60, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}