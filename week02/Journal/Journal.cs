// Journal.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // Manages a list of Entry objects and handles save/load
    public class Journal
    {
        private readonly List<Entry> _entries = new List<Entry>();
        private const string Separator = "~|~";

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries yet.");
                return;
            }

            Console.WriteLine("\n--- Journal Entries ---");
            foreach (var e in _entries)
            {
                Console.WriteLine(e);
            }
        }

        public void SaveToFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach (var e in _entries)
                {
                    // date~|~prompt~|~response
                    writer.WriteLine($"{e.Date}{Separator}{e.Prompt}{Separator}{e.Response}");
                }
            }
            Console.WriteLine($"Journal saved to \"{filename}\".");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File \"{filename}\" not found.");
                return;
            }

            _entries.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                var parts = line.Split(new[] { Separator }, StringSplitOptions.None);
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
            Console.WriteLine($"Journal loaded from \"{filename}\" ({_entries.Count} entries).");
        }
    }
}
