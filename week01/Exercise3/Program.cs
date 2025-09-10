using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.WriteLine("This is the Random Number Game, You keep choosing a number until you guess the correct number.");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int urGuess = 0;
        int guessCount = 0;

        while (urGuess != magicNumber)
        {
            Console.Write("what is the magic number? ");
            urGuess = int.Parse(Console.ReadLine());
            // string mnumber = Console.ReadLine();
            // int guess = int.Parse(mnumber);

            if (magicNumber > urGuess)
            {
                Console.WriteLine("Guess Higer");
            }
            else if (magicNumber < urGuess)
            {
                Console.WriteLine("Guess Lower");
            }
            else
            {
                Console.WriteLine("Your Guess is Correct!");
            }

            guessCount++;
        }

        Console.WriteLine($"Your total guess was {guessCount}");
    }
}