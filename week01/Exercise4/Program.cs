using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        Console.Write("Enter a list of numbers, type 0 when finished");

        List<int> nums = new List<int>();

        int input;
        do
        {
            Console.WriteLine("Enter a numbers.");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                nums.Add(input);
            }
        } while (input != 0);
        {
            int sum = nums.Sum();

            double average = nums.Count > 0 ? nums.Average() : 0;

            int max = nums.Count > 0 ? nums.Max() : 0;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Avergae: " + average);
            Console.WriteLine("Maximum: " + max);
        }
    }
}