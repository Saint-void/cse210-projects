using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("Enter your grade score! ");
        int score = int.Parse(Console.ReadLine());

        String letter = "";

        if (score >= 90)
        {
            letter = "A";
        }

        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");


        if (score >= 70)
        {
            Console.WriteLine("Congratulation you passed the exam");
        }
        else
        {
            Console.WriteLine("Sorry try again next time...");
        }
    }
}