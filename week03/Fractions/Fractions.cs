namespace MyFractions
{
    public class Fraction
    {
        // Private fields
        private int _top;
        private int _bottom;

        // 1) No-parameter constructor → 1/1
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        // 2) One-parameter constructor → top/1
        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        // 3) Two-parameter constructor → top/bottom
        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        // Getters and setters
        public int Top
        {
            get => _top;
            set => _top = value;
        }

        public int Bottom
        {
            get => _bottom;
            set => _bottom = value;
        }

        // Returns “top/bottom”
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        // Returns decimal equivalent
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
}
