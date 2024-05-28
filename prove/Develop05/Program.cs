using System;
using System.Text.Json;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Goal), typeDiscriminator:"goal")]
[JsonDerivedType(typeof(SimpleGoal), typeDiscriminator:"simpleGoal")]
[JsonDerivedType(typeof(EternalGoal), typeDiscriminator:"eternalGoal")]
[JsonDerivedType(typeof(ChecklistGoal), typeDiscriminator:"checklistGoal")]

class Goal {
    public string _shortName {get; set;}
    public string _description {get; set;}
    public int _points{get; set;}

    public Goal(){
    }

    public Goal(string name, string description, int points) {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // get();
    public string ShortName() {
        return _shortName;
    }
    public virtual int RecordEvent() {
        return _points;
    }

    public virtual bool IsComplete() {
        return false;
    }

    public virtual void GetDetails() {
        Console.Write("What is the name of your goal? ");
        _shortName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? " );
        _points = Convert.ToInt32(Console.ReadLine());
    }

    public virtual string GetStringRepresentation() {
        string rtnString = "";
        if (IsComplete()){
            rtnString = "[X] ";
        }
        else {
            rtnString = "[ ] ";
        }

        rtnString += $"{_shortName} ({_description})";
        return rtnString;
    }
}

class SimpleGoal: Goal{
    public bool _isComplete{get; set;}
    public SimpleGoal(){
        bool _isComplete = false;
    }
    public SimpleGoal(string name, string description, int points) {
        _isComplete = false;
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override int RecordEvent() {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() {
        return _isComplete;
    }

}

class EternalGoal: Goal {
    public EternalGoal(){}
    public EternalGoal(string name, string description, int points) {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override bool IsComplete() {
        return false;
    }

}

class ChecklistGoal: Goal {

    public int _amountCompleted{get; set;}
    public int _target{get; set;}
    public int _bonus{get; set;}

    public ChecklistGoal(){}
    public ChecklistGoal(string name, string description, int points, int target, int bonus) {
        _shortName = name;
        _description = description;
        _points = points;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent() {
        // TODO: Must check completeness... 
        _amountCompleted += 1;
        if (_amountCompleted < _target) {
            return _points;
        }
        else {
            return _points + _bonus;
        }
    }

    public override bool IsComplete() {
        if (_amountCompleted < _target) {
            return false;
        }
        else   {
            return true;
        }
    }

    public override string GetStringRepresentation () {
        string rtnString = "";
        rtnString = base.GetStringRepresentation();
        rtnString += $" -- Currently completed: {_amountCompleted}/{_target}";
        return rtnString;
    }

    public override void GetDetails() {
        base.GetDetails();
        Console.Write ("How many times would you like to complete this goal? " );
        _target = Convert.ToInt32(Console.ReadLine());
        Console.Write ("What is the bonus for completing this goal? ");
        _bonus = Convert.ToInt32(Console.ReadLine());
    }
}

class GoalManager {
    public List<Goal> _goals{get; set;}
    public int _score{get; set;}

    public GoalManager() {
        _goals = new List<Goal>();
    }

    public int Score() {
        return _score;
    }

    public void ListGoals() {
        int count = 1;
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals) {
            Console.WriteLine($"{count}. {goal.GetStringRepresentation()}");
            count+=1;
        }
    }

    public void CreateGoal() {
        string userEntry;
        Console.WriteLine("The types of goals are:");
        Console.WriteLine ("1. Simple Goal");
        Console.WriteLine ("2. Eternal Goal");
        Console.WriteLine ("3. Checklist Goal");
        userEntry = Console.ReadLine();
        if (userEntry == "1") {
            SimpleGoal sg = new SimpleGoal();
            sg.GetDetails();
            _goals.Add(sg);
        }
        else if (userEntry == "2") {
            EternalGoal eg = new EternalGoal();
            eg.GetDetails();
            _goals.Add(eg);
        }
        else if (userEntry == "3") {
            ChecklistGoal cg = new ChecklistGoal();
            cg.GetDetails();
            _goals.Add(cg);
        }
    }

    public void RecordGoal() {
        Console.WriteLine("The goals are: ");
        int count = 1;
        foreach (Goal goal in _goals) {
            Console.WriteLine($"{count}. {goal.ShortName()}");
            count += 1;
        }
        Console.Write("Which goal did you accomplish? ");
        // zero based...
        int goalId = Convert.ToInt32(Console.ReadLine()) - 1;
        Goal g = _goals[goalId];
        _score += g.RecordEvent();

    }

    public void SaveGoals(string filename) {
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true
        };
        string jsonEntries = "";
        try {
            File.WriteAllText(filename, $"{_score}\n");
            jsonEntries += JsonSerializer.Serialize(_goals, options);
            File.WriteAllText (filename, jsonEntries);
        } 

        catch (FileNotFoundException e) {
            Console.WriteLine(e.ToString());
        }
    }

    public void LoadGoals(string filename) {
        try {
            var jsonIn = File.ReadAllText(filename);
            string[] jsonsplit = jsonIn.Split("[");
            string jsonStr = "[" + jsonsplit[1];
            _score = Convert.ToInt32(jsonsplit[0]);
            _goals = JsonSerializer.Deserialize<List<Goal>>(jsonStr);
        } 
        
        catch (FileNotFoundException e) {
            Console.WriteLine(e.ToString());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string userEntry = "";
        GoalManager gm = new GoalManager();

        while(userEntry != "6"){
            //you have {n amount} points
            Console.WriteLine($"\nYou have {gm.Score()} points.\n");

            //menu options
            Console.WriteLine("Menu options\n1.Create New Goal\n2.List Goals\n3.Save Goals\n4.Load Goals\n5.Record Event\n6.Quit\n");
            Console.Write("Please select an option from the menu: ");
            userEntry = Console.ReadLine();

            //create new goal
            if(userEntry == "1"){
                gm.CreateGoal();
            }
            //list goals
            else if(userEntry == "2"){
                gm.ListGoals();
            }
            //save goals
            else if(userEntry == "3"){
                Console.WriteLine("What would you like to name the file? ");
                string filename = Console.ReadLine();
                gm.SaveGoals(filename);
            }
            //load goals
            else if(userEntry == "4"){
                Console.WriteLine("What file would you like to load? ");
                string filename = Console.ReadLine();
                gm.LoadGoals(filename);
            }
            //record event
            else if(userEntry == "5"){
                gm.RecordGoal();
            }

        }
    }
}