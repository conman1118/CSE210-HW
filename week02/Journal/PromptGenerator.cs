// PromptGenerator.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalApp
{
    public static class PromptGenerator
    {
        private static readonly Random _rng = new Random();

        // Your master list of prompts
        private static readonly List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // …add any others you like
        };

        // A working, shuffled copy
        private static List<string> _shuffledPrompts;
        private static int _nextIndex;

        // Static constructor: prepare first shuffle
        static PromptGenerator()
        {
            ResetShuffled();
        }

        // Public API: get the next prompt
        public static string GetRandomPrompt()
        {
            // If we’ve run out, start a new round
            if (_nextIndex >= _shuffledPrompts.Count)
                ResetShuffled();

            return _shuffledPrompts[_nextIndex++];
        }

        // Shuffle into _shuffledPrompts, reset index
        private static void ResetShuffled()
        {
            _shuffledPrompts = _prompts
                .OrderBy(_ => _rng.Next())
                .ToList();
            _nextIndex = 0;
        }
    }
}
