// Program.cs
using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to CSV");
                Console.WriteLine("4. Load the journal from CSV");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option (1–5): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        WriteEntry(journal);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Filename to save as CSV (e.g. journal.csv): ");
                        var outFile = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(outFile))
                            journal.SaveToCsv(outFile);
                        else
                            Console.WriteLine("Invalid filename.");
                        break;
                    case "4":
                        Console.Write("Filename to load from CSV: ");
                        var inFile = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(inFile))
                            journal.LoadFromCsv(inFile);
                        else
                            Console.WriteLine("Invalid filename.");
                        break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice—please enter 1, 2, 3, 4, or 5.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        private static void WriteEntry(Journal journal)
        {
            var prompt = PromptGenerator.GetRandomPrompt();
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("Your response: ");
            var response = Console.ReadLine() ?? "";

            var date = DateTime.Now.ToShortDateString();
            journal.AddEntry(new Entry(date, prompt, response));
            Console.WriteLine("Entry recorded.");
        }
    }
}
