using System;

public class Job
{
    public string _jobTit;
    public string _comp;
    public int _sYear;
    public int _eYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTit} ({_comp}) {_sYear}-{_eYear}");
    }
}