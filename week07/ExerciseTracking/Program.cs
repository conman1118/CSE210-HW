// Program.cs
using System;
using System.Collections.Generic;

namespace FitnessTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),         // 3 miles in 30 min
                new StationaryBike(new DateTime(2022, 11, 3), 45, 12.0), // 12 mph for 45 min
                new Swimming(new DateTime(2022, 11, 3), 60, 20)          // 20 laps in 60 min
            };

            foreach (var act in activities)
            {
                Console.WriteLine();
                Console.WriteLine(act.GetSummary());
            }
        }
    }
}
