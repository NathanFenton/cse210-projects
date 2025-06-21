using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        int select = 0;
        Journal journal1 = new Journal();

        while (select != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string selectAnswer = Console.ReadLine();
            select = int.Parse(selectAnswer);


            if (select == 1)
            {
                PromptGenerator prompt = new PromptGenerator();
                string thePrompt = prompt.GetRandomPrompt();
                Console.WriteLine(thePrompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry1 = new Entry();
                entry1._date = DateTime.Now.ToShortDateString();
                entry1._promptText = thePrompt;
                entry1._entryText = response;

                journal1.AddEntry(entry1);
            }

            else if (select == 2)
            {
                journal1.DisplayAll();
            }

            else if (select == 3)
            {
                journal1.LoadFromFile("");
            }

            else if (select == 4)
            {
                journal1.SaveToFile("");
            }

            else
            {
                continue;
            }

        }
    }
}