using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor accepts the raw word (including attached punctuation, if any)
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Getter for original text (if needed)
    public string GetText() => _text;

    // Returns whether this word is hidden
    public bool IsHidden() => _isHidden;

    // Hide this word
    public void Hide()
    {
        _isHidden = true;
    }

    // Reveal the word (not required by spec but helpful for testing)
    public void Show()
    {
        _isHidden = false;
    }

    // Returns the display text: original text if visible,
    // otherwise letters replaced by '_' but punctuation left intact.
    public string GetDisplayText()
    {
        if (!_isHidden) return _text;

        var sb = new StringBuilder();
        foreach (char c in _text)
        {
            // Replace letters with underscores, keep punctuation (and numbers) intact
            sb.Append(char.IsLetter(c) ? '_' : c);
        }

        return sb.ToString();
    }
}
