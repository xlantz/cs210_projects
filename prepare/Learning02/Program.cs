using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "CEO";
        job1._placeEmployment = "Janitorial Enterprises";

        job1._yearBegin = 2080;
        job1._yearEnd = 2100;

        Job job2 = new Job();

        job2._jobTitle = "Senior Executive";
        job2._placeEmployment = "Johnson & Kowalski Law";

        job2._yearBegin = 2056;
        job2._yearEnd = 2078;

        Resume resume = new Resume();

        resume._name = "Steve Kaufman";

        resume._jobs.Add(job1);

        resume._jobs.Add(job2);

        resume.Display();
    }
}