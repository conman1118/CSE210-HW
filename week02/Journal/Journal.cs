// Journal.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalApp
{
    public class Journal
    {
        private readonly List<Entry> _entries = new List<Entry>();

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
                Console.WriteLine(e);
        }

        /// <summary>
        /// Save all entries to a CSV file with proper quoting.
        /// </summary>
        public void SaveToCsv(string filename)
        {
            using var writer = new StreamWriter(filename);
            // header row
            writer.WriteLine("Date,Prompt,Response");

            foreach (var e in _entries)
            {
                writer.WriteLine($"{Quote(e.Date)},{Quote(e.Prompt)},{Quote(e.Response)}");
            }

            Console.WriteLine($"Journal saved as CSV to \"{filename}\".");
        }

        /// <summary>
        /// Load entries from a CSV file produced by SaveToCsv.
        /// </summary>
        public void LoadFromCsv(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File \"{filename}\" not found.");
                return;
            }

            var lines = File.ReadAllLines(filename).ToList();
            if (lines.Count < 2)
            {
                Console.WriteLine("CSV file has no data rows.");
                return;
            }

            _entries.Clear();
            // skip header
            foreach (var line in lines.Skip(1))
            {
                var parts = ParseCsvLine(line);
                if (parts.Length == 3)
                    _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }

            Console.WriteLine($"Journal loaded from \"{filename}\" ({_entries.Count} entries).");
        }

        // Wraps a field in quotes, doubling any internal quotes
        private static string Quote(string field)
        {
            var escaped = field.Replace("\"", "\"\"");
            return $"\"{escaped}\"";
        }

        // Simple RFC-style CSV parser for one line
        private static string[] ParseCsvLine(string line)
        {
            var fields = new List<string>();
            bool inQuotes = false;
            var cur = "";

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        // look ahead for escaped quote
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            cur += '"';
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        cur += c;
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        fields.Add(cur);
                        cur = "";
                    }
                    else
                    {
                        cur += c;
                    }
                }
            }

            fields.Add(cur);
            return fields.ToArray();
        }
    }
}
