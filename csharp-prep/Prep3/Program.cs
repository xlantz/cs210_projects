using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magNum = randomGenerator.Next(1, 101);

        int guessNum = 0;

        while (guessNum != magNum)
        {
            
            Console.WriteLine("Guess a number from 1 to 100: ");
            string strGuessNum = Console.ReadLine();

            guessNum = int.Parse(strGuessNum);

            if (guessNum < magNum)
            {
                Console.WriteLine("Higher");
            }
            else if (guessNum > magNum)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNum == magNum)
            {
                Console.WriteLine("Congradulations, you guessed it!");
            }
        }
    }
}