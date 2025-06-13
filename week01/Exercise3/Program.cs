using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        int guess = 0;

        do
        {
            Console.Write("What is your guess? ");
            string wdyt = Console.ReadLine();
            guess = int.Parse(wdyt);

            if (guess < number)
            {
                Console.WriteLine("Higher");
            }

            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }

        } while (guess != number);

        Console.WriteLine("You guessed it!");

    }
}