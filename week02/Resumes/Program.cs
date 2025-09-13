using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        
        Job job1 = new Job();
        job1._jobTitle = "Data Entry Clerk";
        job1._company = "Happy Lomas";
        job1._startYear = 2018;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "ICT Manager";
        job2._company = "Happy Lomas";
        job2._startYear = 2022;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Prince";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}