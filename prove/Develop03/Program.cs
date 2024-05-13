using System;
using System.IO;
using System.Net;
using System.Text;

//get scripture class
//from txt files
public class GetScripture{
    public List<string> scriptureLines {get; set;}
    public string reference {get; set;}
    // Check if the file for the scripture reference exists
    public GetScripture(){
        scriptureLines = new List<string>();
    }
    public void ScriptureLoad(string file_Path){
        if (File.Exists(file_Path))
        {
            // Open the file
            var fileIn = File.ReadAllLines(file_Path);
            int Count = fileIn.Length;
            reference = fileIn[0];

            for (int i = 1; i < fileIn.Length; i++){
                scriptureLines.Add(fileIn[i]);
            }
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }
    }
}

//process scripture class
    //multi-dementinal array
public class ScriptureProcess{
    public List<string[]> Lines {get; set;}
    public ScriptureProcess(){
        Lines = new List<string[]>();
    }

    public void ProcessScripture(List<string> scripturelines) {
        foreach (string scriptureline in scripturelines){
            string[] words = scriptureline.Split(' ');
            Lines.Add(words);
        }
        return;
    }

    
}

//remove word and replace with underscores class

public class ReplaceWordUnderscore{
    private Random random;

    public ReplaceWordUnderscore(){
        random = new Random();
    }

    public string[] DoUnderscores(string[] words){
        // replace word with underscore
        int wordIndex = random.Next(words.Length);
        string replaceWord = words[wordIndex];
        string underscores = new string('_', replaceWord.Length);
        words[wordIndex] = underscores;

        return words;

    }

}

class Program
{
    static void Main(string[] args)
    {

        // get user file
        Console.WriteLine("Enter a file name: ");
        string fileName = Console.ReadLine();

        //load file
        GetScripture gs = new();
        gs.ScriptureLoad(fileName);

        /*Console.WriteLine(gs.reference);
        foreach (string scripture in gs.scriptureLines){
            Console.WriteLine(scripture);
        }*/

        //process file
        ScriptureProcess sp = new();
        sp.ProcessScripture(gs.scriptureLines);
        
        //create instance of ReplaceUnderscores
        ReplaceWordUnderscore ru = new();
        string sentence = "";
        var allWordsFlag = false;
        while (!allWordsFlag)
        {   
            Console.WriteLine(gs.reference);

            //copy of list
            List<string[]> mylines = new List<string[]>(sp.Lines);

            foreach (string[] line in mylines){
                string[] newline = ru.DoUnderscores(line);
                int index = sp.Lines.IndexOf(line);
                if (index != -1){
                    sp.Lines[index] = newline;
                }

                //update
                sentence = string.Join(" ", newline);
                Console.WriteLine(sentence);

                // check if ALL words have been replaced
                if (sentence.Replace(" ", "") == new string('_', sentence.Replace(" ", "").Length))
                {
                    allWordsFlag = true;
                    
                }
                else{

                    allWordsFlag = false;
                }
            }



            // user either continues or quits
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit from the program.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
                break;
        } 
        
    }
}