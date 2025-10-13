using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    private Random _random = new Random();

    public ListingActivity()
        : base("Listing", 
               "This activity helps you reflect on the good things in your life by having you list as many things as you can in a given area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---\n");
        Console.Write("You may begin in: ");
        ShowCountDown(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        List<string> responses = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                responses.Add(input);
                _count++;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
