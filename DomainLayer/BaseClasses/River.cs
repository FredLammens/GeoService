using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class River
    {
        public int Id { get; set; }
        public string Name { get => Name; private set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be null or empty."); Name = value; } }
        public double Length
        {
            get => Length;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Length can't be negative.");
                Length = value;
            }
        }

        private List<Country> _countries = new List<Country>();
        public IReadOnlyList<Country> Countries { get => _countries.AsReadOnly(); }

        public void AddCountry(string name, long population, double surface)
        {
            Country country = new Country(name, population, surface, this);
            bool inCountries = _countries.Contains(country);
            if (inCountries)
                throw new ArgumentException("country already added.");
            _countries.Add(country);
            Population += population;
        }
    }
}
