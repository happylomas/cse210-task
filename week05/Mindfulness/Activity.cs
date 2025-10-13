using System;
using System.Threading;
using System.Collections.Generic;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Ask for duration and show the standard starting message
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("Enter the duration of your session in seconds: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    // Standard ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Simple spinner animation
    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b"); // erase spinner
            i = (i + 1) % spinner.Length;
        }
    }

    // Countdown animation
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
