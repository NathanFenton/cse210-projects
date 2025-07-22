using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    protected Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public  string GetSummary()
    {
        //formats the date into a string of day/month/year
        string dateString = GetDate().ToString("dd MMM yyyy");
        //the GetType.Name finds the name of the class
        //it's usefull because I don't need to harcode in the names
        string className = GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        int length = GetLength();

        //the instructions showed some of the things like this 'Pace: ...' and some didn't have the semicolon
        //there was also one of the lines in the instructions that used a semicolon after the length in minutes and the other showed a dash
        //I just decided to format it with the semicolon after the length and no more semicolon's for the rest of it
        return $"{dateString} {className} ({length} min): Distance {distance:F2} miles, Speed {speed:F2} mph, Pace {pace:F2} min per mile";
    }
}