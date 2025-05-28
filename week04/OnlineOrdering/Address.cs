using System;

namespace Shop
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Trim().ToUpper() == "USA";
        }

        public override string ToString()
        {
            // Street on its own line, then "City, State/Province" line, then country
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}
