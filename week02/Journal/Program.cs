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
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option (1–5): ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        WriteEntry(journal);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Filename to save to: ");
                        journal.SaveToFile(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Filename to load from: ");
                        journal.LoadFromFile(Console.ReadLine());
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
            string prompt = PromptGenerator.GetRandomPrompt();
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            // Use current date as string
            string date = DateTime.Now.ToShortDateString();
            var entry = new Entry(date, prompt, response);
            journal.AddEntry(entry);

            Console.WriteLine("Entry recorded.");
        }
    }
}
