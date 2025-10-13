using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random = new Random();

    public ReflectingActivity()
        : base("Reflecting", 
               "This activity helps you reflect on times when you have shown strength and resilience.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now, ponder on each of the following questions...");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"> {question}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }
}
