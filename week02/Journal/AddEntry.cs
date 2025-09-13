
public class AddEntry
{
    public string _date = "";
    public string _promptText ="";
    public string _entryText = "";
    

    public AddEntry(){}
    public AddEntry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToShortDateString(); 
        _promptText = promptText;
        _entryText = entryText;
    }
    
    // public void Write()
    // {
        // _date = DateTime.Now.ToShortDateString(); 
        // prompt = pgen.GetPrompt()
        // _prompt =
        // PUT prompt
        // response = GET
    // }


    public void Display()
    {
      Console.WriteLine($"{_date} | {_promptText} | {_entryText}");
    }
    public string GetEntry() 
    {
        return $"{_date} | {_promptText} | {_entryText}";
    }

}