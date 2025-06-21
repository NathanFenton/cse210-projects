using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach(Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        Console.WriteLine("What is the file name as a CSV?");
        string savePath = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(savePath))
        {
            foreach (Entry entry in _entries)
            {
                string date = csv(entry._date);
                string prompt = csv(entry._promptText);
                string text = csv(entry._entryText);
                writer.WriteLine($"\"{date}\",\"{text}\",\"{prompt}\"");
            }
        }
    }

    //I was trying to figure out how to make it can be saved as a csv file and I learned a few new things
    //one of those things is .Replace which simply just replaces the first part with the second
    //This is important because if someone includes a comma in the text that they are saving to the csv it will be cut off in excel
    //this just puts quotations around the user commas so that it isn't an issue
    private string csv(string replacement)
    {
        return replacement.Replace("\"", "\"\"");
    }

    public void LoadFromFile(string file)
    {
        Console.WriteLine("What is the file name?");
        string loadPath = Console.ReadLine();

        //The Parser makes it so It displays properly and dosn't show split at the commas
        //at first I was completly confused on how to even go about this
        //I had to look up how to set one up then made one for my spicific program
        using (TextFieldParser parser = new TextFieldParser(loadPath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            while (!parser.EndOfData)
            {
                string[] parts = parser.ReadFields();

                Entry entry2 = new Entry();

                entry2._date = parts[0];
                entry2._entryText = parts[1];
                entry2._promptText = parts[2];

                _entries.Add(entry2);
            }
        }
    }
}