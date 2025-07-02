using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("This is the Exercisel project..");

        Console.Write("What is your first name? ");
        String fn = Console.ReadLine();

        Console.Write("What is your secord name? ");
        String ln = Console.ReadLine();

        Console.WriteLine($"Your name is {ln}, {fn} {ln}.");
    }
}