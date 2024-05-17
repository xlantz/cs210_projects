class Program
{
    static void Main(string[] args)
    {
        Assignment assignment_1 = new Assignment("Steve Kaufmann", "Socioeconomic History of Derogatory Terms in the Post-modernist Era");
        Console.WriteLine(assignment_1.GetSummary());
        MathAssignment assignment_2 = new MathAssignment("Sammy Samson", "Taylor Series", "12.5", "210-275");
        Console.WriteLine(assignment_2.GetSummary());
        Console.WriteLine(assignment_2.GetHomeworkList());
        WritingAssignment assignment_3 = new WritingAssignment("Dutch Bassidy", "Creative Non-fiction", "Do I prefer hard-shell or soft-shell tacos? What does that say about me?");
        Console.WriteLine(assignment_3.GetSummary());
        Console.WriteLine(assignment_3.GetWritingInformation());
    }
}