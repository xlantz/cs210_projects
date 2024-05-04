using System;

public class Job
{
    public string _jobTitle;
    public string _placeEmployment;
    public int _yearBegin;
    public int _yearEnd;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_placeEmployment}) {_yearBegin} to {_yearEnd}\n");
    }
}