using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

         Console.WriteLine("I added creativity by adding a note when you look for a file that do not exist it prints 'file not found' ");

        int reply = 0;

        Journal journal = new Journal();

        while (reply != 5)
        {
            Console.WriteLine("Welcome to Happy Journal");
            Console.WriteLine("");
            Console.WriteLine("1. Write on your Journal");
            Console.WriteLine("2. Display your Journal");
            Console.WriteLine("3. Load your Journal");
            Console.WriteLine("4. Save your Journal");
            Console.WriteLine("5. Quite");

            Console.Write("Choose an option: ");

            string answer = Console.ReadLine();
            reply = int.Parse(answer);

            if (reply > 5 || reply < 1)
            {
                Console.WriteLine($"Option {reply} is not avaiable! pick from 1-5\n");
            }

            else if (reply == 1)
            {
                journal.AddEntry();
            }

            else if (reply == 2)
            {
                journal.DisplayEntries();
            }

            else if (reply ==3)
            {
                Console.WriteLine("Loading.....");
                journal.Load();
            }

            else if (reply == 4)
            {
                Console.WriteLine("You are going to save a content");
                journal.Save();
            }

            else
            {
                Console.WriteLine("You Quit, thank you");
            }
        }
        
    }
}