using System;
using System.IO.Enumeration;
using System.Text.Json;


public class JournalEntry
{
    //date and time
        public DateTimeOffset Date {get; set;}

    //prompt
        public string Prompt {get; set;}

    //entry
        public string Entry {get; set;}
}

class Journal
{
    public List <JournalEntry> listEntries {get; set;}

    public void SaveEntries(string filename)
    {
        try {
                string jsonEntries = JsonSerializer.Serialize(listEntries);
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
            listEntries = JsonSerializer.Deserialize<List<JournalEntry>>(jsonIn);
        } 
        
        catch (FileNotFoundException e) {
            Console.WriteLine(e.ToString());
        }
    }
    public void PrintAllEntries()
    {
        if (listEntries.Count > 0)
            foreach (JournalEntry je in listEntries)
            {
                Console.WriteLine($"Date: {je.Date}");
                Console.WriteLine($"\tPrompt: {je.Prompt}");
                Console.WriteLine($"\tEntry: {je.Entry}\n");
            }
        else
            Console.WriteLine ("There are no Journal Entries to print");
    }
}

class Prompt
{
    List<string> prompts = new List<string>
    {
    "Who was the most interesting person I interacted with today?",
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "If I had one thing I could do over today, what would it be?",
    "What is your relationship with Hershey's chocolate?",
    "If I were a tree what tree would I be?",
    "What is your quest?",
    "What is your favourite colour"
    };

    static Random rnd = new Random();
    public string GetPrompt()
    {
        int r = rnd.Next(prompts.Count);
        return prompts[r];
    }
}

class Program
{
    static public JournalEntry GetJournalEntry()
    {
        Prompt prompt = new();
        string promptStr = prompt.GetPrompt();
        Console.WriteLine($"Prompt: {promptStr}");
        string entryStr = Console.ReadLine();
        JournalEntry journalEntry = new()
        {
            Date = DateTime.Now,
            Prompt = promptStr,
            Entry = entryStr
        };
        return journalEntry;
    }
    static void Main(string[] args)
    {
        Journal myJournal = new()
        {
            listEntries = new List<JournalEntry>()
        };

        string userMenuEntry = "";
        while (userMenuEntry != "Quit")
        {
            
            //1. write
            Console.WriteLine("Write");
            //2. load
            Console.WriteLine("Load");
                //ask for file
            //3. save
            Console.WriteLine("Save");
                //ask for file
            //4. read
            Console.WriteLine("Read");
                //ask for file
            //5. Quit
            Console.WriteLine("Quit");

            Console.WriteLine("What would you like to do? ");
            userMenuEntry = Console.ReadLine();
            JournalEntry je;

            if (userMenuEntry == "Write")
            {
                je = GetJournalEntry();
                myJournal.listEntries.Add(je);
                
            } 

            else if (userMenuEntry == "Load")
            {
                Console.WriteLine("What file would you like to load? ");
                string filename = Console.ReadLine();

                myJournal.LoadEntries(filename);
            }
            
            else if (userMenuEntry == "Save")
            {
                Console.WriteLine("What would you like to name the file? ");
                string filename = Console.ReadLine();

                myJournal.SaveEntries(filename);
            }
            
            else if (userMenuEntry == "Read")
            {
                myJournal.PrintAllEntries();
            }
        }

    }
}