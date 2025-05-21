using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main()
        {
            // the whole library of scriptures. i can add any scripture at any time
            var library = new ScriptureLibrary();
            library.Add(new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, " +
                "that whoever believes in him shall not perish but have eternal life."
            ));
            library.Add(new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; " +
                "in all your ways submit to him, and he will make your paths straight."
            ));

            library.Add(new Scripture(
                new ScriptureReference("Moroni", 10, 4),
                "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal " +
                "Father, in the name of Christ, if these things are not true⁠; and if ye shall ask with a sincere heart⁠,"+
                "with real intent⁠, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."
            ));
            

            // 2) Pick one at random
            var scripture = library.GetRandomScripture();
            if (scripture == null)
            {
                Console.WriteLine("No scriptures available.");
                return;
            }

            // 3) Run the same hide-words loop
            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                    break;

                Console.WriteLine();
                Console.Write("Press Enter to hide more words or type \"quit\" to exit: ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                    break;

                scripture.HideRandomWords();
            }

            Console.WriteLine();
            Console.WriteLine("All done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
