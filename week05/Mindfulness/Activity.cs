using System;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }

        public void StartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} Activity");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            Duration = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }

        public void EndMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good job! You have completed the activity.");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}