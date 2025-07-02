using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random rand = new Random();
        int random = rand.Next(1, 11);
        
        int guess = -1;

        while (guess != random)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > random)
            {
                Console.WriteLine("Lower");
            }

            else if (guess < random)
            {
                Console.WriteLine("Higher");
            }
            
            else
            {
                Console.WriteLine("You got it");
            }
        }
        
    }
}