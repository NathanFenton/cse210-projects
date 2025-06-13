using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int favNum = PromptUserNumber();
        int squ = SquareNumber(favNum);
        DisplayResult(username, squ);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string fav = Console.ReadLine();
            int number = int.Parse(fav);
            return number;
        }

        static int SquareNumber(int number)
        {
            int square = (number * number);
            return square;
        }

        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"{name}, the square of your number is {square}");
        }
        
    }
}