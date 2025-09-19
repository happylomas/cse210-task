using System;


    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse; 

        // Constructor for single verse (e.g., John 3:16)
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        // Constructor for verse range (e.g., Proverbs 3:5-6)
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        // Getters (no setters: reference is immutable after creation)
        public string GetBook() => _book;
        public int GetChapter() => _chapter;
        public int GetStartVerse() => _startVerse;
        public int? GetEndVerse() => _endVerse;

        public string GetDisplayText()
        {
            if (_endVerse == null)
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
            }
        }
    }
