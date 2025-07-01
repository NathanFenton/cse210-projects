using System;
using System.Collections.Generic;

class Program
{
    private static Random randm = new Random();

    static void Main(string[] args)
    {
        //Each scripture I add to the list calls a new reference constructor to format the reference -
        //it also calls a new Scripture constructor for the scripture
        //these are all added to the list and one will be randomly chosen later
        List<Scripture> scriptures = new List<Scripture>();
        scriptures.Add(new Scripture(new Reference("1 Nephi", 2, 15),"And my father dwelt in a tent."));
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6),"Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("Doctrine & Covenants", 58, 26, 27),"For behold, it is not meet that I should command in all things; for he that is compelled in all things, the same is a slothful and not a wise servant; wherefore he receiveth no reward. Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness;"));

        //I learned 'Next' in the last program that I did and reused it here
        //this just randomly picks a scripture from above and stores it in 'selected'
        int choice = randm.Next(0, scriptures.Count);
        Scripture selected = scriptures[choice];

        string input = "";

        while (input != "quit")
        {
            //Used to clear the console 
            Console.Clear();
            Console.WriteLine(selected.GetDisplayText());

            //learned that break can be used to get out of a loop
            //this just checks if all the words are hidden using the IsCompletelyHidden method -
            // then stopping the program if they all are
            if (selected.IsCompletelyHidden())
                break;

            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            //this is nice because it dosen't matter if you type a capital or add a space at the start or end -
            // you will still 'quit' out of the program either way
            //they had similar methods in python so I just looked up if the same thing existed in C#
            input = Console.ReadLine().Trim().ToLower();

            //Used break again here.
            //Before when I was typing 'quit' it was just ignoring it -
            // and when I pressed enter afterwards it just ran normally
            if (input == "quit")
            {
                break;
            }

            //this decides how many words will be hidden at a time calling on the HideRandomWords method
            //any amount numbers at a time can be hidden, but I chose to do three
            selected.HideRandomWords(3);
        }
    }
}