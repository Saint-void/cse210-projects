using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        Job job1 = new Job();
        job1._jobTit = "Software Engineer";
        job1._comp = "Microsoft";
        job1._sYear = 2019;
        job1._eYear = 2022;

        Job job2 = new Job();
        job2._jobTit = "Manager";
        job2._comp = "Apple";
        job2._sYear = 2022;
        job2._eYear = 2023;

        Resume resume = new Resume();
        resume._name = "Allison Rose";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}