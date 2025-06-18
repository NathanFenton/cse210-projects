using System;
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Google";
        job1._jobTitle = "Lead IT";
        job1._startYear = 2000;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._company = "Space X";
        job2._jobTitle = "Janator";
        job2._startYear = 1999;
        job2._endYear = 2019;

        Resume resume1 = new Resume();
        resume1._name = "Random Person";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.DisplayResumeDetails();

    }
}