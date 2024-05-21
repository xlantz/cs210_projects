using System;

class Activity {
    protected string _name; // The thing
    protected string _description; // What it is
    protected int _duration; // Seconds

    public void SetDuration(){
        Console.Write("How long would you like this activity to last (in seconds)? ");
        _duration = Convert.ToInt32(Console.ReadLine());
    }

    public Activity() {
        return;
    }

    public void DisplayStartingMessage() {
        Console.WriteLine($"Welcome to the {_name}.");
        return;
    }

    public void DisplayEndingMessage() {
        Console.WriteLine($"Well done!\n\nYou have completed another {_duration} seconds of the {_name}.");
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
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        
    }


    public void Run() {

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime){
            Console.Write("\nBreathe in...");

            ShowCountDown();

            Console.Write("\nBreathe out...");

            ShowCountDown();
        }

    }
}

class ListingActivity : Activity {
    Random _random;
    public List<string> GetListFromUser() {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        List<string> userList = new List<string>();
        Console.Write("You may begin in: ");
        ShowCountDown();
        Console.WriteLine("");
        while (DateTime.Now < endTime){
            Console.Write("> ");
            string instr = Console.ReadLine();
            userList.Add(instr);
        }
        return userList;
    }
    List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity () {
        _random = new Random();
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }
    public string GetRandomPrompt() {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public void DisplayPrompt(){
    Console.WriteLine("List as many responses as you can to the following prompt: \n");
    Console.WriteLine(GetRandomPrompt());
    }

    public void Run() {
        ShowCountDown();
        DisplayPrompt();
        List<string> theList = GetListFromUser();
        int _count = theList.Count;
        Console.WriteLine($"You Listed {_count} items!\n");
        ShowSpinner(5);
        return;
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
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    
    }

    public void DisplayQuestions(){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime){
            Console.WriteLine(_questions[_random.Next(_questions.Count)]);
            ShowSpinner(5);
        }
    }

    public void DisplayPrompt(){
        Console.WriteLine("Consider the following prompt: \n");
        Console.WriteLine(GetRandomPrompt());
    }

    public void Run() {
        
        DisplayPrompt();
        Console.WriteLine("When you have something in mind press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("You may now ponder on each of the questions as they relate to the prompt.");
        ShowCountDown();
        DisplayQuestions();
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
            Console.WriteLine("Menu Options: \n 1. Start breathing activity \n 2. Start reflecting activity \n 3. Start listing activity \n 4. Quit\n");
            Console.Write("Select an option from the menu: ");
            user_menu_input = Console.ReadLine();

            if(user_menu_input == "1"){
                BreathingActivity ba = new BreathingActivity();
                ba.DisplayStartingMessage();
                ba.ShowSpinner(5);
                ba.SetDuration();
                ba.ShowCountDown();
                ba.Run();
                ba.DisplayEndingMessage();

            }
            else if(user_menu_input == "2"){
                ReflectingActivity ra = new ReflectingActivity();
                ra.DisplayStartingMessage();
                ra.ShowSpinner(5);
                ra.SetDuration();
                Console.Write("Starting in...");
                ra.ShowCountDown();
                ra.Run();
                ra.DisplayEndingMessage();
            }
            else if(user_menu_input == "3"){
                ListingActivity la = new ListingActivity();
                la.DisplayStartingMessage();
                la.ShowSpinner(5);
                la.SetDuration();
                Console.Write("Starting in...");
                la.ShowCountDown();
                la.Run();
                la.DisplayEndingMessage();
            }
        }
    }
}