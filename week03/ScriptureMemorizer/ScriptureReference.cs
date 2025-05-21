using System;

namespace ScriptureMemorizer
{
    public class ScriptureReference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;

        // Single‐verse constructor, e.g. “John 3:16”
        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        // Verse‐range constructor, e.g. “Proverbs 3:5-6”
        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public override string ToString()
        {
            if (_endVerse.HasValue)
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
            else
                return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}
