public class PromptGenerator
{
    public List<string> _prompt = new List<string>()
    {
        "What are you grateful about today?",
        "What was the best part of your day?",
        "What did you gain today and what will you like to remember about today?"
    };
    public Random rnd = new Random();

    public string GetPrompt()
    {
        int index = rnd.Next(_prompt.Count);
        return _prompt[index];
        // RETURN prompts[index]
    }
}   