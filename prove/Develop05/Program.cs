using System;

class Goal(){
    protected string _shortName = "";
    protected string _description = "";
    protected int _points;

    public Goal(string name, string description, int points){
        this._shortName = name;
        this._points = points;
        this._description = description;
    }

    public virtual void RecordEvent(){
        
    }

    public virtual bool IsComplete(){
        return false;
    }

    public virtual string GetDetailsString(){
        return "Goal Details";
    }

    public virtual string GetStringRepresentation(){
        return "Goal";
    }
}

class SimpleGoal : Goal{
    bool _isComplete;

    public SimpleGoal(string name, string description, int points){
        _isComplete = false;
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent(){
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete(){
        return _isComplete;
    }

    public override string GetStringRepresentation(){
        return $"Simple Goal: {_shortName}";
    }
}

class EternalGoal : Goal{
    EternalGoal(string name, string description, int points){

    }
    public override void RecordEvent(){
        return _points;
    }

    public override bool IsComplete(){
        return false;
    }

    public override string GetStringRepresentation(){
        return $"Eternal Goal: {_shortName}";
    }
}

class ChecklistGoal : Goal{
    int _amountCompleted;
    int _target;
    int _bonus;

    ChecklistGoal(string name, string description, int points, int target, int bonus){

    }

    public void RecordEvent(){
        if (_amountCompleted < _target){
            return _points;
        }
        else{
            return _points + _bonus;
        }
    }

    public override bool IsComplete(){
        if (_amountCompleted < _target){
            return false;
        }
        else{
            return true;
        }
    }
    public override string getDetailsString(){
        return "Checklist Goal Details";
    }
    public override string GetStringRepresentation(){
        return "Checklist Goal";
    }
}

class GoalManager : Goal{
    private List<string> _goals = new List<string>{};
    private int _score;

    public GoalManager(){
        _goals = new List<Goal>;
        _goals.Add = new SimpleGoal();

    }

    public void Start(){

    }

    public void DisplayPlayerInfo(){

    }

    public void ListGoalNames(){

    }

    public void ListGoalDetails(){

    }

    public void CreateGoal(){

    }

    public void RecordEvent(){

    }

    public void SaveGoals(){

    }

    public void LoadGoals(){

    }
}
class Program{ 
    static void Main(string[] args)
    {
        string userEntry = "";
        while(userEntry != "6"){
            //you have {n amount} points

            //menu options
            Console.WriteLine("Menu options\n1.Create New Goal\n2.List Goals\n3.Save Goals\n4.Load Goals\n5.Record Event\n6.Quit\n");
            Console.Write("Please select an option from the menu: ");
            userEntry = Console.ReadLine();
            

            //create new goal
            if(userEntry == "1"){
                
            }
            //list goals
            else if(userEntry == "2"){
                
            }
            //save goals
            else if(userEntry == "3"){
                Console.WriteLine("What would you like to name the file? ");
                string filename = Console.ReadLine();
                
            }
            //load goals
            else if(userEntry == "4"){
                Console.WriteLine("What file would you like to load? ");
                string filename = Console.ReadLine();

            }
            //record event
            else if(userEntry == "5"){

            }

        }   
    }
        
}