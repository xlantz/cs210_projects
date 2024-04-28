using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();
        string mainUserName = PromptUserName();
        int mainUserNum = PromptUserNumber();
        
        int mainSqrNum = SquareNumber(mainUserNum);

        DisplayResult(mainUserName, mainSqrNum);

    }
    //welcome message
    static void DisplayWelcomeMessage(){
        Console.WriteLine("Welcome to my Program!");
    }
    //user's name
    static string PromptUserName(){
        Console.WriteLine("What is your name? ");
        string userName = Console.ReadLine();
        return userName;
    }
    //favorite number (int only)
    static int PromptUserNumber(){
        Console.WriteLine("What is your favorite whole number? ");
        string strUserNum = Console.ReadLine();
        int userNum = int.Parse(strUserNum);
        return userNum;
    }
    //square num
    static int SquareNumber(int userNum) {
        int sqrUserNum = userNum*userNum;
        return sqrUserNum;
    }
    //user name plus fav num squared
    static void DisplayResult(string userName, int userSqrNum){
        Console.WriteLine($"Your name is {userName}, and your favorite number squared is {userSqrNum}.");
    }
        
}