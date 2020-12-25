using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class River
    {
        /// <summary>
        /// Id of river
        /// </summary>
        public int Id { get; set; }
        private string _name;
        /// <summary>
        /// Name of River
        /// </summary>
        public string Name { get => _name; private set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be null or empty."); _name = value; } }
        private double _length;
        /// <summary>
        /// Length of river in m
        /// </summary>
        public double Length
        {
            get => _length;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Length can't be negative.");
                _length = value;
            }
        }
       
        private List<Country> _countries = new List<Country>();
        /// <summary>
        /// List of countries that river is in.
        /// </summary>
        public IReadOnlyList<Country> Countries { get => _countries.AsReadOnly(); }
        /// <summary>
        /// Constructor to make river object
        /// </summary>
        /// <param name="name">Name of river</param>
        /// <param name="length">length of river in m</param>
        /// <param name="country">country river is in</param>
        public River(string name, double length, Country country)
        {
            Name = name;
            Length = length;
            AddCountry(country);
        }
        /// <summary>
        /// Adds country to list where river is situated
        /// </summary>
        /// <param name="country">Country river is in</param>
        public void AddCountry(Country country)
        {
            bool inCountries = _countries.Contains(country);
            if (inCountries)
                throw new ArgumentException("country already added.");
            _countries.Add(country);
            country.AddRiver(this);         
        }
        /// <summary>
        /// Deletes country from list where river is situated
        /// </summary>
        /// <param name="country">Country river is in</param>
        public void DeleteCountry(Country country) 
        {
            if (_countries.Count < 2)
                throw new ArgumentException($"{Name} needs to be in at least 1 country.");
            bool isRemoved = _countries.Remove(country);
            if (!isRemoved)
                throw new Exception("county was already removed.");

        }
    }
}
