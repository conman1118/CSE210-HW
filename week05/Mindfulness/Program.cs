using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for all activities
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _duration; // in seconds

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Public entry point for running the activity
        public void Run()
        {
            DisplayStartingMessage();
            PerformActivity();
            DisplayEndingMessage();
        }

        // Prompts for duration and displays starting message and initial pause
        private void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"=== {_name} ===");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Enter duration in seconds: ");
            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a positive integer for the duration: ");
            }
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            PauseWithSpinner(3);
        }

        // Displays ending message including activity name and duration, with a final pause
        private void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            PauseWithSpinner(2);
            Console.WriteLine($"You have completed {_duration} seconds of {_name}.");
            PauseWithSpinner(3);
        }

        // Shows a rotating spinner for the specified number of seconds
        protected void PauseWithSpinner(int seconds)
        {
            string[] spinnerChars = { "|", "/", "-", "\\" };
            int totalTicks = seconds * 10; // 10 ticks per second (each tick = 100ms)
            for (int i = 0; i < totalTicks; i++)
            {
                Console.Write(spinnerChars[i % spinnerChars.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
            }
            Console.WriteLine();
        }

        // Shows a countdown from the specified number down to 1
        protected void PauseWithCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        // Abstract method that derived classes implement with their specific logic
        protected abstract void PerformActivity();

        // Helper to retrieve the private _duration field
        protected int GetDuration()
        {
            var durationField = typeof(Activity)
                .GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (int)durationField.GetValue(this);
        }
    }

    // Breathing activity: alternates between "Breathe in..." and "Breathe out..."
    class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base(
                  "Breathing Activity",
                  "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan activityLength = TimeSpan.FromSeconds(GetDuration());

            while (DateTime.Now - startTime < activityLength)
            {
                Console.Write("Breathe in...");
                PauseWithCountdown(4);
                if (DateTime.Now - startTime >= activityLength) break;

                Console.Write("Breathe out...");
                PauseWithCountdown(4);
            }
        }
    }

    // Reflection activity: asks user to reflect on prompts and questions
    class ReflectionActivity : Activity
    {
        // Master lists of prompts and questions
        private readonly List<string> _allPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _allQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Available copies, so we can ensure no repeats until all used
        private List<string> _availablePrompts;
        private List<string> _availableQuestions;
        private Random _random = new Random();

        public ReflectionActivity()
            : base(
                  "Reflection Activity",
                  "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            // Initialize the "available" lists as fresh copies
            _availablePrompts = new List<string>(_allPrompts);
            _availableQuestions = new List<string>(_allQuestions);
        }

        protected override void PerformActivity()
        {
            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");

            // Ensure no prompt is selected until all have been used at least once.
            if (_availablePrompts.Count == 0)
            {
                // Refill once all prompts have been shown
                _availablePrompts = new List<string>(_allPrompts);
            }
            int promptIndex = _random.Next(_availablePrompts.Count);
            string prompt = _availablePrompts[promptIndex];
            _availablePrompts.RemoveAt(promptIndex);

            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            DateTime startTime = DateTime.Now;
            TimeSpan activityLength = TimeSpan.FromSeconds(GetDuration());

            while (DateTime.Now - startTime < activityLength)
            {
                // Ensure no question repeats until all have been used
                if (_availableQuestions.Count == 0)
                {
                    // Refill once all questions have been asked
                    _availableQuestions = new List<string>(_allQuestions);
                }

                int questionIndex = _random.Next(_availableQuestions.Count);
                string question = _availableQuestions[questionIndex];
                _availableQuestions.RemoveAt(questionIndex);

                Console.WriteLine(question);
                PauseWithSpinner(5);
            }
        }
    }

    // Listing activity: user lists as many items as possible within duration
    class ListingActivity : Activity
    {
        // Master list of prompts
        private readonly List<string> _allPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Available copy to prevent repeats
        private List<string> _availablePrompts;
        private Random _random = new Random();

        public ListingActivity()
            : base(
                  "Listing Activity",
                  "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            // Initialize the available prompts as a fresh copy
            _availablePrompts = new List<string>(_allPrompts);
        }

        protected override void PerformActivity()
        {
            Console.WriteLine();

            // --- PROMPT SELECTION LOGIC ---
            // Ensure no prompt repeats until all have been used at least once.
            if (_availablePrompts.Count == 0)
            {
                // Refill once all prompts have been shown
                _availablePrompts = new List<string>(_allPrompts);
            }
            int promptIndex = _random.Next(_availablePrompts.Count);
            string prompt = _availablePrompts[promptIndex];
            _availablePrompts.RemoveAt(promptIndex);

            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.Write("You may begin in: ");
            PauseWithCountdown(5);

            DateTime startTime = DateTime.Now;
            TimeSpan activityLength = TimeSpan.FromSeconds(GetDuration());
            int count = 0;

            Console.WriteLine("Start listing items (press Enter after each):");
            while (DateTime.Now - startTime < activityLength)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadLine();
                    count++;
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {count} items!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness App");
                Console.WriteLine("---------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                activity.Run();
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
            }
        }
    }
}
