// StationaryBike.cs
using System;

namespace FitnessTracker
{
    public class StationaryBike : Activity
    {
        private double _speedMph;

        public StationaryBike(DateTime date, double lengthMinutes, double speedMph)
            : base(date, lengthMinutes)
        {
            _speedMph = speedMph;
        }

        public override double GetDistance()
        {
            // distance = speed × hours
            return _speedMph * (LengthMinutes / 60.0);
        }

        public override double GetSpeed()
        {
            return _speedMph;
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
