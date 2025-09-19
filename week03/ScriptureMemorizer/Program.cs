using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        // A small sample library — you may add more entries or load from a file.
        var scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
            ),
            new Scripture(
                new Reference("Psalm", 23, 1),
                "The Lord is my shepherd; I shall not want."
            )
        };

        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // If all words hidden, show final state and end
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Press ENTER to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress ENTER to hide words or type 'quit' and press ENTER to exit.");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Quitting program. Goodbye!");
                break;
            }

            // Hide a random small number of words (1–3)
            int wordsToHide = random.Next(1, 4); // 1, 2, or 3
            scripture.HideRandomWords(wordsToHide, hideOnlyVisible: true);
        }
    }
}
