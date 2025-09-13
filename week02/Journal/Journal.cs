public class Journal
{
    public List<AddEntry> _entries = new List<AddEntry>();
    public PromptGenerator pgen = new PromptGenerator();
    public void AddEntry()
    {
       
        // entry.Write()
        // add entry to the entries list
        string promptText = pgen.GetPrompt();
        Console.WriteLine(promptText);
        string entryText = Console.ReadLine();
        AddEntry entry = new AddEntry(promptText, entryText);
        _entries.Add(entry);
        // string _promptText = pgen.GetPrompt();
        // Console.WriteLine(promptText);
        // string entryText = Console.ReadLine();
        // Entry entry = new Entry(promptText, entryText);
        // entries.Add(entry);
    }
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Your Journal Entries:");
        foreach (AddEntry entry in _entries)
        {
            entry.Display();
        }
    }
    public void Save()
    {
        Console.Write("Enter the filename to save: ");
        string filename = Console.ReadLine();
        using(StreamWriter writer = new(filename, true))
        {
            foreach(AddEntry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                writer.WriteLine(entry.GetEntry());
            }
        }

    }
    public void Load()
    {
         Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found!\n");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    _entries.Add(new AddEntry(parts[1], parts[2]) { _date = parts[0] });
                }
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }
            catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}\n");
        }   

    }

}