using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class Continent
    {
        public int Id { get; private set; }
        public string Name { get => Name; private set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be null or empty"); Name = value; } }
        public long Population { get; private set; }
        private List<Country> _countries = new List<Country>();
        public IReadOnlyList<Country> Countries { get => _countries.AsReadOnly();}

        public Continent() { }
        public Continent(int id, string name)
        {
            Id = id;
            Name = name;
            SetPopulation();
        }

        public Continent(int id, string name, List<Country> countries)
        {
            Id = id;
            Name = name;
            AddCountries(countries);
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
        private void AddCountries(List<Country> countries) 
        {
            _countries = countries;
            SetPopulation();
        }

        public void AddCountry(Country country) 
        {
            if (country.Equals(null))
                throw new ArgumentException("country can't be null");
            _countries.Add(country);
            Population += country.Population;
        }
        public void DeleteCountry(Country country)
        {
            Country toDelete = GetCountry(country);
            _countries.Remove(country);
        }
        public Country GetCountry(Country country) 
        {
            Country returnCountry = _countries.Where(c => c.Id == country.Id).SingleOrDefault();
            if (country.Equals(null))
                throw new ArgumentException($"country is not in {Name}");
            return returnCountry;
        }
    }
}
