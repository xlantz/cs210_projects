using System;

class Activity {
    string _name; // The thing
    string _description; // What it is
    int _duration; // Seconds

    public Activity() {
        return;
    }

    public void DisplayStartingMessage() {
        return;
    }

    public void DisplayEndingMessage() {
        return;
    }

    public void ShowSpinner(int seconds) {
        List <string> animationStrings = new List <string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowCountDown () {
        Console.WriteLine("Starting in...");

        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    
}

class BreathingActivity : Activity {
    public BreathingActivity () {
    }


    public void Run(double userTime) {

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(userTime);

        while (DateTime.Now < endTime){
            Console.WriteLine("\nBreathe in...");

            for (int i = 4; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }

            Console.WriteLine("\nBreathe out...");

            for (int i = 4; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        Console.WriteLine("That's the end of the breathing activity.");

    }
}

class ListingActivity : Activity {
    Random _random;
    public ListingActivity () {
        _random = new Random();
    }

    public void Run(double userTime) {

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(userTime);

        while (DateTime.Now < endTime){

        }

        Console.WriteLine("That's the end of the listing activity.");
    }
    public void GetRandomPrompt() {
        return;
    }

    public List<string> GetListFromUser() {
        List<string> userlist = new List<string>{
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        return userlist;
    }
}

class ReflectingActivity : Activity {
    Random _random;
    List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public ReflectingActivity () {
        _random = new Random();
    }

    public void Run() {
        return;
    }

    string GetRandomPrompt() {
        return _prompts[_random.Next(_prompts.Count)];
    }
}


class Program
{
    static void Main(string[] args)
    {
        string user_menu_input = "";

        while(user_menu_input != "4")
        {
            Console.WriteLine("Menu Options: \n 1. Start breathing activity \n 2. Start reflecting sctivity \n 3. Start listing activity \n 4. Quit\n");
            Console.WriteLine("Select an option from the menu: ");
            user_menu_input = Console.ReadLine();

            if(user_menu_input == "1"){
                Console.WriteLine("You selected option 1\n");
            }
            else if(user_menu_input == "2"){
                Console.WriteLine("You selected option 2\n");
            }
            else if(user_menu_input == "3"){
                Console.WriteLine("You selected option 3\n");
            }
        }
    }
}