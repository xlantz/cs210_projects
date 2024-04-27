using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("What is your grade percentage? ");
        string strGrade = Console.ReadLine();

        int numGrade = int.Parse(strGrade);

        string gradeLetter = "";

        if (numGrade >= 90)
        {
            gradeLetter = "A";
        }
        else if (numGrade >= 80)
        {
            gradeLetter = "B";
        }
        else if (numGrade >= 70)
        {
            gradeLetter = "C";
        }
        else if (numGrade >= 60)
        {
            gradeLetter = "D";
        }
        else if (numGrade < 60)
        {
            gradeLetter = "F";
        }

        Console.WriteLine(gradeLetter);

        if (numGrade > 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You failed. Try agin next time.");
        }
    }
}