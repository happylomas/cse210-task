using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Console.WriteLine("");

        string userChoice = "";
        while (userChoice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("====================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect a choice from the menu: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

            if (userChoice != "4")
            {
                Console.WriteLine("\nPress Enter to return to the main menu...");
                Console.ReadLine();
            }
        }
    }
}