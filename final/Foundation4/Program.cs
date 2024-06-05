using System;

public class Activity{
    private DateTime date;
    public int minutes;

    public Activity(DateTime date, int minutes){
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance(){
        return 0;
    }

    public virtual double GetSpeed(){
        return 0;
    }

    public virtual double GetPace(){
        return 0;
    }

    public virtual string GetSummary(){
        return $"{date.ToShortDateString()} - {GetType().Name} ({minutes} min): Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Running : Activity{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes){
        this.distance = distance;
    }

    public override double GetDistance(){
        return distance;
    }

    public override double GetSpeed(){
        return (distance / base.minutes) * 60;
    }

    public override double GetPace(){
        return base.minutes / distance;
    }
}

public class Cycling : Activity{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes){
        this.speed = speed;
    }

    public override double GetSpeed(){
        return speed;
    }

    public override double GetDistance(){
        return speed * base.minutes / 60;
    }

    public override double GetPace(){
        return 60 / speed;
    }
}

public class Swimming : Activity{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes){
        this.laps = laps;
    }

    public override double GetDistance(){
        return laps * 50 / 1000 * 0.62;
    }

    public override double GetSpeed(){
        return (GetDistance() / base.minutes) * 60;
    }

    public override double GetPace(){
        return base.minutes / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2024, 06, 03), 30, 3.0));
        activities.Add(new Running(new DateTime(2024, 06, 03), 30, 4.8));
        activities.Add(new Cycling(new DateTime(2024, 06, 03), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2024, 06, 03), 60, 20));

        foreach (var activity in activities){
            Console.WriteLine(activity.GetSummary());
        }
    }
}