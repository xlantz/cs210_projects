using System;
using System.IO.Enumeration;
using System.Text.Json;
public class GoalEntry
{
    //entry
        public string Entry {get; set;}
}
class GoalManager{
    public List <GoalEntry> goalEntries {get; set;}

    public void SaveEntries(string filename)
    {
        try {
                string jsonEntries = JsonSerializer.Serialize(goalEntries);
                File.WriteAllText (filename, jsonEntries);
            } 

        catch (FileNotFoundException e) {
                Console.WriteLine(e.ToString());
            }


    }
    public void LoadEntries(string filename)
    {
        try {
            var jsonIn = File.ReadAllText(filename);
            goalEntries = JsonSerializer.Deserialize<List<GoalEntry>>(jsonIn);
        } 
        
        catch (FileNotFoundException e) {
            Console.WriteLine(e.ToString());
        }
    }
    public void PrintAllEntries()
    {
        if (goalEntries.Count > 0)
            foreach (GoalEntry ge in goalEntries)
            {
                Console.WriteLine($"Goals: {ge.Entry}\n");
            }
        else
            Console.WriteLine ("There are no Goal Entries to print.");
    }

    public void RecordEvent(){

    }
}

class Goal{
    public void chooseGoal(){
        Console.WriteLine("The types of goals are:\n");
        Console.WriteLine("1.Simple Goal\n2.Eternal Goal\n3.Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        Console.Read();
        Console.Write("What is the name of your goal? ");
        Console.Read();
        Console.Write("what is a short description of it? ");
        Console.Read();
        Console.Write("What is the amount of points associated with this goal? ");
        Console.Read();
    }
}
class SimpleGoal : Goal{
    public void simpleGoal(){
        chooseGoal();

    }
}
class EternalGoal : Goal{
    public void eternalGoal(){
        chooseGoal();

    }
}
class ChecklistGoal : Goal{
    public void checklistGoal(){
        chooseGoal();
        Console.Write("How many times does this goal need to be accomplished? ");
        Console.Write("What is the bonus for completing this goal? ");

    }
}
class Program
{
    Goals myGoal = new()
    {
        goalEntries = new List<GoalEntry>()
    };
    static void Main(string[] args)
    {
        string userEntry = "";
        while(userEntry != "6"){
            //you have {n amount} points

            //menu options
            Console.WriteLine("Menu options\n1.Create New Goal\n2.List Goals\n3.Save Goals\n4.Load Goals\n5.Record Event\n6.Quit\n");
            Console.Write("Please select an option from the menu: ");
            userEntry = Console.ReadLine();
            GoalEntry ge;

            //create new goal
            if(userEntry == "1"){
                myGoal.listEntries.Add(ge);
            }
            //list goals
            else if(userEntry == "2"){
                myGoal.PrintAllEntries();
            }
            //save goals
            else if(userEntry == "3"){
                Console.WriteLine("What would you like to name the file? ");
                string filename = Console.ReadLine();

                myGoal.SaveEntries(filename);
            }
            //load goals
            else if(userEntry == "4"){
                Console.WriteLine("What file would you like to load? ");
                string filename = Console.ReadLine();

                myGoal.LoadEntries(filename);
            }
            //record event
            else if(userEntry == "5"){

            }
            
        }
    }
}