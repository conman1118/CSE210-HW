// Running.cs
using System;

namespace FitnessTracker
{
    public class Running : Activity
    {
        private double _distanceMiles;

        public Running(DateTime date, double lengthMinutes, double distanceMiles)
            : base(date, lengthMinutes)
        {
            _distanceMiles = distanceMiles;
        }

        public override double GetDistance()
        {
            return _distanceMiles;
        }

        public override double GetSpeed()
        {
            // mph = miles / hours
            return _distanceMiles / (LengthMinutes / 60.0);
        }

        public override double GetPace()
        {
            // minutes per mile
            return LengthMinutes / _distanceMiles;
        }
    }
}
