using System;
public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();
    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job jobInfo in _jobs)
        {
            jobInfo.DisplayJobDetails();
        }
    }

}