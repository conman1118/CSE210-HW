using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            // split on spaces, keep punctuation attached
            _words = text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word(w))
                .ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference);
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", _words));
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden);
        }

        /// <summary>
        /// Hide up to count random words that are not yet hidden.
        /// </summary>
        public void HideRandomWords(int count = 3)
        {
            var visible = _words.Where(w => !w.IsHidden).ToList();
            if (!visible.Any()) return;

            for (int i = 0; i < count && visible.Count > 0; i++)
            {
                int idx = _random.Next(visible.Count);
                visible[idx].Hide();
                visible.RemoveAt(idx);
            }
        }
    }
}
