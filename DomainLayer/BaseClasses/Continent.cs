using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get => Name; private set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be null or empty."); Name = value; } }
        public uint Population { get => Population; 
            private set 
            {
                if (value < 0) 
                    throw new ArgumentException("Population can't be negative.");
                Population = value;
            } 
        }
        private List<Country> _countries = new List<Country>();
        public IReadOnlyList<Country> Countries { get => _countries.AsReadOnly();}

        public Continent() { }
        public Continent(string name)
        {
            Name = name;
            SetPopulation();
        }

        public Continent(string name, List<Country> countries)
        {
            Name = name;
            bool allCountriesFromContinent = countries.TrueForAll(country => country.Continent == this);
            if (allCountriesFromContinent == false)
                throw new ArgumentException($"All countries need to be of continent: {name}");
            _countries = countries;
            SetPopulation();
        }

        private void SetPopulation() 
        {
            if (_countries.Count > 0)
            {
                _countries.ForEach(countrie => Population += countrie.Population);
            }
            else
                Population = 0;
        }

        public void AddCountry(string name, uint population, float surface ) 
        {
            Country country = new Country(name, population, surface, this);
            bool inCountries = _countries.Contains(country);
            if (inCountries)
                throw new ArgumentException("country already added.");
            _countries.Add(country);
            Population += population;
        }
        public void DeleteCountry(Country country)
        {
            CheckCountryForNull(country);
            bool hasCities = (country.Cities.Count > 0);
            if (hasCities)
                throw new Exception($"{country.Name} still has cities.");
            bool removed = _countries.Remove(country);
            if (removed == false) 
            {
                    throw new ArgumentException($"country is not in {Name}");
                //TODO: population aanpassen.
            }
        }

        private void CheckCountryForNull(Country country) 
        {
            if (country == null)
                throw new ArgumentException("country can't be null");
        }

        #region equals
        public override bool Equals(object obj)
        {
            return obj is Continent continent &&
                   Name == continent.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        #endregion
    }
}
