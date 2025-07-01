using System;
using System.Collections.Generic;
public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public void Show()
    {
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetDisplayText()
    {
        if (!_hidden)
        {
            return _text;
        }

        string blanks = "";
        //This loop puts an underscore for every letter in a word that is being hidden.
        //I hide three words in this program every time enter is pressed (as long as quit is not typed in), -
        // so the GetDisplayText here will be used 3 times per press
        for (int i = 0; i < _text.Length; i++)
        {
            blanks += "_";
        }
        return blanks;
    }
}