// PromptGenerator.cs
using System;
using System.Collections.Generic;

namespace JournalApp
{
    // Provides random prompts
    public static class PromptGenerator
    {
        private static readonly Random _rand = new Random();
        private static readonly List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // feel free to add more of your own...
        };

        public static string GetRandomPrompt()
        {
            int idx = _rand.Next(_prompts.Count);
            return _prompts[idx];
        }
    }
}
