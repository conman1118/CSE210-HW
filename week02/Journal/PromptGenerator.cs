// PromptGenerator.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalApp
{
    public static class PromptGenerator
    {
        private static readonly Random _rng = new Random();

        // my master list of prompts
        private static readonly List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
            // …i can add more if i like
        };

        private static List<string> _shuffled;
        private static int _idx;

        static PromptGenerator()
        {
            Reset();
        }

        public static string GetRandomPrompt()
        {
            if (_idx >= _shuffled.Count)
                Reset();
            return _shuffled[_idx++];
        }

        private static void Reset()
        {
            _shuffled = _prompts.OrderBy(_ => _rng.Next()).ToList();
            _idx = 0;
        }
    }
}
