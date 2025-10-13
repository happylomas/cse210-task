using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", 
               "This activity will help you relax by guiding you to breathe in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            Console.Write("Now breathe out... ");
            ShowCountDown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
