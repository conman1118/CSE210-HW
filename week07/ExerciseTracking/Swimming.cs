// Swimming.cs
using System;

namespace FitnessTracker
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, double lengthMinutes, int laps)
            : base(date, lengthMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // each lap is 50 m → km → miles
            double km = _laps * 50.0 / 1000.0;
            return km * 0.62;
        }

        public override double GetSpeed()
        {
            // mph
            return GetDistance() / (LengthMinutes / 60.0);
        }

        public override double GetPace()
        {
            var dist = GetDistance();
            return dist > 0
                ? LengthMinutes / dist
                : 0;
        }
    }
}
