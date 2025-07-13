using System;
using System.Threading;

class Program
{
    //This is a list for how many times each activity is used
    //after the Run() with each activity it will add one to the list -
    //then it will be shown in the ShowLog method after the program is finished
    private static List<int> _activityCounts = new List<int> { 0, 0, 0 };

    static void Main(string[] args)
    {
        string choice = "";

        //basic while loop looking for an input
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breath = new BreathingActivity();
                breath.Run();
                _activityCounts[0]++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflect = new ReflectingActivity();
                reflect.Run();
                _activityCounts[1]++;
            }
            else if (choice == "3")
            {
                ListingActivity list = new ListingActivity();
                list.Run();
                _activityCounts[2]++;
            }
            else if (choice != "4")
            {
                Console.WriteLine("Invalid selection. Press Enter to try again.");
                Console.ReadLine();
            }
        }

        ShowLog();
    }

    //The ShowLog method shows how many times each activity has been used
    private static void ShowLog()
    {
        Console.WriteLine("\nActivity Log:\n");
        Console.WriteLine($"Breathing Activity: {_activityCounts[0]} times");
        Console.WriteLine($"Reflection Activity: {_activityCounts[1]} times");
        Console.WriteLine($"Listing Activity: {_activityCounts[2]} times");
    }
}