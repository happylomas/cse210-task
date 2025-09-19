using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    // Constructor accepts a Reference and the full scripture text (string).
    // It is the Scripture's responsibility to split the text into Word objects.
    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        _words = new List<Word>();
        _random = new Random();
        InitializeWords(text ?? string.Empty);
    }

    // Splits on spaces to create Word objects; keeps punctuation attached to words.
    private void InitializeWords(string text)
    {
        // Split on spaces so punctuation stays with words (e.g., "Son," stays a single token)
        var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var token in tokens)
        {
            _words.Add(new Word(token));
        }
    }

    // Returns the display text: the reference on one line and the scripture text below.
    public string GetDisplayText()
    {
        var sb = new StringBuilder();
        sb.AppendLine(_reference.GetDisplayText());

        for (int i = 0; i < _words.Count; i++)
        {
            sb.Append(_words[i].GetDisplayText());
            if (i < _words.Count - 1)
            {
                sb.Append(" ");
            }
        }

        return sb.ToString();
    }

    // Is every word hidden?
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    // Hide up to 'count' words. By default this method hides only currently visible words (no double-hiding).
    // If there are fewer visible words than 'count', hides the remaining visible words.
    public void HideRandomWords(int count = 3, bool hideOnlyVisible = true)
    {
        if (count <= 0) return;

        List<Word> candidates;

        if (hideOnlyVisible)
        {
            candidates = _words.Where(w => !w.IsHidden()).ToList();
        }
        else
        {
            // When allowed to re-hide already hidden words, candidate list is all words.
            candidates = _words.ToList();
        }

        if (!candidates.Any()) return;

        // Hide up to 'count' unique visible words
        for (int i = 0; i < count && candidates.Count > 0; i++)
        {
            int idx = _random.Next(candidates.Count);
            candidates[idx].Hide();

            // If hiding only visible words, remove the selected from candidates list so we don't pick it again.
            candidates.RemoveAt(idx);
        }
    }

    // Optional helper — number of words still visible
    public int GetVisibleWordCount()
    {
        return _words.Count(w => !w.IsHidden());
    }
}
