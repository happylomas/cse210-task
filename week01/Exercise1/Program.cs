using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        // Ask the user for their name using c#
        
        Console.Write("What is your last name?") ;
        string lastname = Console.ReadLine();

        Console.Write("What is your frist name?") ;
        string firstname = Console.ReadLine();

        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");
    }
}