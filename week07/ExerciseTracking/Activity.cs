// Activity.cs
using System;

namespace FitnessTracker
{
    public abstract class Activity
    {
        private DateTime _date;
        private double _lengthMinutes;

        protected Activity(DateTime date, double lengthMinutes)
        {
            _date = date;
            _lengthMinutes = lengthMinutes;
        }

        public DateTime Date => _date;
        public double LengthMinutes => _lengthMinutes;

        // In miles, mph, and minutes per mile
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            // e.g. "03 Nov 2022 Running (30 min): Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile"
            return string.Format("{0:dd MMM yyyy} {1} ({2} min): Distance {3:0.0} miles, Speed {4:0.0} mph, Pace: {5:0.00} min per mile",
                _date,
                this.GetType().Name,
                _lengthMinutes,
                GetDistance(),
                GetSpeed(),
                GetPace());
        }
    }
}
