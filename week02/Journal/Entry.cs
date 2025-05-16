// Entry.cs
using System;

namespace JournalApp
{
    // Represents one journal entry
    public class Entry
    {
        public string Date { get; }
        public string Prompt { get; }
        public string Response { get; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            // Customize how each entry is displayed
            return $"{Date} — {Prompt}\n  {Response}\n";
        }
    }
}
