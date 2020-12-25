using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class Continent
    {
        /// <summary>
        /// continentId
        /// </summary>
        public int Id { get; set; }
        private string _name;
        /// <summary>
        /// coninent name = unique
        /// </summary>
        public string Name { get => _name; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                { 
                    throw new ArgumentException("Name can't be null or empty.");
                }
                _name = value; 
            } 
        }
        private ulong _population = 0;
        /// <summary>
        /// population generated from populations of all countries
        /// </summary>
        public ulong Population { get => _population; 
            private set 
            {
                if (value < 0) 
                    throw new ArgumentException("Population can't be negative.");
                _population = value;
            } 
        }
        private List<Country> _countries = new List<Country>();
        /// <summary>
        /// countries in continent
        /// </summary>
        public IReadOnlyList<Country> Countries { get => _countries.AsReadOnly();}

        public Continent() { }
        /// <summary>
        /// constructor of continent with no countries
        /// </summary>
        /// <param name="name">Name of continent</param>
        public Continent(string name)
        {
            Name = name;
        }
        /// <summary>
        /// method to add country and automatically updates population
        /// </summary>
        /// <param name="name">Name of country</param>
        /// <param name="population">Population of country</param>
        /// <param name="surface">surface area of country</param>
        public void AddCountry(string name, uint population, float surface ) 
        {
            Country country = new Country(name, population, surface, this);
            bool inCountries = _countries.Contains(country);
            if (inCountries)
                throw new ArgumentException("country already added.");
            _countries.Add(country);
            Population += population;
        }
        /// <summary>
        /// method to delete country and automatically updates population
        /// </summary>
        /// <param name="country"></param>
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
            }
            Population -= country.Population;
        }
        /// <summary>
        /// checks country for null value and returns exception if true
        /// </summary>
        /// <param name="country">Country to check</param>
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
