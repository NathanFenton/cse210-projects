using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    
    //declairing _random as Random
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        //making new instance of the 'Random' object
        _random = new Random();


        //splits the scriptures(by the spaces) into seperate words
        string[] parts = text.Split(" ");

        //this goes through each word and puts it into a 'Word' object
        //it does this for all the words individually(which is why we needed to split it up above)
        for (int i = 0; i < parts.Length; i++)
        {
            Word word = new Word(parts[i]);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int count)
    {
        //this is the list of positions of still visible words
        List<int> visibleList = new List<int>();

        //this loops through all the word's positions and if the words are visible(not hidden) -
        // it will add them to the list above
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleList.Add(i);
            }
        }

        //This part is important because not all of the verses are perfect multiple of 3 -
        //(the number of words that I dicided to make dissapear at a time), so -
        // this counts the maximum amount of words actually left and -
        // can later be used to help make that amount dissapear instead
        //Here is an example:
        //If there are only 2 words left then the code trys to make 3 dissapear that dosen't work, -
        //so if there is only 2 left it makes 2 dissapear instead
        //maxHide is used in the condition of the loop below to acomplish that
        int maxHide = Math.Min(count, visibleList.Count);

        //This loops once per word that you are able to hide
        //in the loop it picks one (not hidden) word at random
        //then afterwards removes it from the list so it isn't picked again
        //Online I was able to find an easy way to remove from a list using the 'RemoveAt' method
        for (int i = 0; i < maxHide; i++)
        {
            int rand = _random.Next(visibleList.Count);
            int words = visibleList[rand];
            _words[words].Hide();
            visibleList.RemoveAt(rand);
        }
    }

    //This is the method that actually displays the scripture to the console
    //it starts by displaying the reference then after it loops through all the words in the scripture -
    // and displays either the underscores(for removed words) or the actual word(for non removed words)
    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + " ";

        for (int i = 0; i < _words.Count; i++)
        {
            display += _words[i].GetDisplayText();
            display += " ";
        }

        return display;
    }

    //This is the method that determines when the program has displayed everything
    //it will keep looping as long as there is a word that is not hidden(returning false)
    //eventually, once all the words are hidden, it will return true and when used in the main program the program will end
    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}