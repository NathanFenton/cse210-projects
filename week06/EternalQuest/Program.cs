using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

//I kept the Goal and Goal subclasses to the design, but I changed the GoalManager from the design