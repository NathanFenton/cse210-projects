using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            string num = Console.ReadLine();
            number = int.Parse(num);

            if (number != 0)
            {
                numbers.Add(number);
            }
            
        }

        int sum = 0;

        foreach (int i in numbers)
        {
            sum += i;
        }

        int numOfNumbers = numbers.Count;

        float average = sum / numOfNumbers;

        int largestNum = numbers.Max();
        //I looked up a built in method to find the largest number and found the .Max()

        Console.WriteLine($"The sum is: {sum}");

        Console.WriteLine($"The average is: {average}");

        Console.WriteLine($"The largest number is: {largestNum}");

    }
}