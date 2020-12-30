using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class Country
    {
        /// <summary>
        /// CountryId
        /// </summary>
        public uint Id { get; set; }
        private string _name;
        /// <summary>
        /// Country name = unique
        /// </summary>
        public string Name { get => _name; 
            private set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name can't be null or empty.");
                _name = value; 
            } 
        }
        /// <summary>
        /// Population of country , can't be negative
        /// </summary>
        public uint Population { get; set; }
        private float _surface;
        /// <summary>
        /// Surface area of country
        /// </summary>
        public float Surface {
            get => _surface;
            private set 
            {
                if (value < 0)
                    throw new ArgumentException("Surface can't be negative.");
                _surface = value;
            }
        }
        private Continent _continent;
        /// <summary>
        /// Continent country belongs to
        /// </summary>
        public Continent Continent { get => _continent; 
            set {
                _continent = value ?? throw new ArgumentException("continent can't be null.");
            } 
        }

        private List<River> _rivers = new List<River>();
        private List<City> _cities = new List<City>();
        private List<City> _capitals = new List<City>();
        /// <summary>
        /// Rivers of country
        /// </summary>
        public IReadOnlyList<River> Rivers => _rivers.AsReadOnly();
        /// <summary>
        /// Cities of country capital is also added
        /// </summary>
        public IReadOnlyList<City> Cities => _cities.AsReadOnly();
        /// <summary>
        /// capitals of country
        /// </summary>
        public IReadOnlyList<City> Capitals => _capitals.AsReadOnly();
        /// <summary>
        /// Constructor to make country object
        /// </summary>
        /// <param name="name">Country name = unique</param>
        /// <param name="population">Population of country</param>
        /// <param name="surface">Surface area of country</param>
        /// <param name="continent">continent country belongs to</param>
        public Country(string name, uint population, float surface, Continent continent)
        {
            Name = name;
            Population = population;
            Surface = surface;
            Continent = continent;
        }

        /// <summary>
        /// Adds city to list of cities of country
        /// </summary>
        /// <param name="name">Name of city</param>
        /// <param name="population">Population of city</param>
        public void AddCity(City city) 
        {
            CheckCityForSameCountry(city);
            bool inCities = _cities.Contains(city);
            if (inCities)
                throw new ArgumentException($"{city.Name} already added.");
            //check population city doesnt exceed population country
            if (!IsPopulationCorrect(city.Population))
                throw new Exception($"population: {city.Population} would exceed country's population: {Population}.");
            city.Id = (uint)(_cities.Count);
            _cities.Add(city);
        }
        /// <summary>
        /// Removes city of list of cities of country. checks if city is not a capital before removing
        /// </summary>
        /// <param name="city">City to remove</param>
        public void RemoveCity(City city) 
        {
            CheckCityForNull(city);
            bool isInCapitals = _capitals.Contains(city);
            if (isInCapitals)
                throw new ArgumentException($"city: {city.Name} is in capitals. pls remove from capital first.");
            bool isRemoved = _cities.Remove(city);
            if (!isRemoved)
            {
                    throw new ArgumentException($"city is not in {Name}.");
            }
        }
        /// <summary>
        /// Adds capital to list of capitals of country.
        /// </summary>
        /// <param name="name">Name of capital to add</param>
        /// <param name="population">Population of capital to add</param>
        public void AddCaptial(City capital) 
        {
            CheckCityForSameCountry(capital);
            CheckCapitalNotFromOtherCountry(capital);
            bool inCapitals = _capitals.Contains(capital);
            if (inCapitals)
                throw new ArgumentException($"capital: {capital.Name} already added.");
            capital.CapitalFrom = this;
            _capitals.Add(capital);
            //addToCities
            City toAddToCities = _cities.SingleOrDefault(city => city == capital);
            if (toAddToCities != null)
            {
                toAddToCities.CapitalFrom = this;
            }
            else 
            {
                AddCity(toAddToCities);
            }
        }
        /// <summary>
        /// Removes capital from country
        /// </summary>
        /// <param name="capital">Capital to remove</param>
        public void RemoveCapital(City capital) 
        {
            CheckCityForNull(capital);
            bool isRemoved = _capitals.Remove(capital);
            if (!isRemoved)
            {
                throw new ArgumentException($"capital: {capital.Name} is not in {Name}.");
            }
        }
        /// <summary>
        /// Add river to country
        /// </summary>
        /// <param name="river">River to add</param>
        internal void AddRiver(River river)
        {
            CheckRiverForNull(river);
            bool isInRivers = _rivers.Contains(river);
            if (isInRivers)
                throw new ArgumentException($"{river.Name} is already in {this.Name}");
            river.Id = (uint)(_rivers.Count);
            _rivers.Add(river);
        }
        /// <summary>
        /// Removes river of country
        /// </summary>
        /// <param name="river">River to remove</param>
        internal void RemoveRiver(River river)
        {
            CheckRiverForNull(river);
            bool isRemoved = _rivers.Remove(river);
            if (!isRemoved)
            {
                throw new ArgumentException($"river is not in {Name}");
            }
        }

        /// <summary>
        /// Checks river for null value returns exception if null
        /// </summary>
        /// <param name="river">River to check</param>
        private void CheckRiverForNull(River river)
        {
            if (river == null)
                throw new ArgumentException("river can't be null");
        }
        #region Checkfunctions
        /// <summary>
        /// Checks if population of all cities isnt bigger than population.
        /// </summary>
        /// <param name="populationToAdd">Population to add</param>
        /// <returns>ispopulation bigger than calculated population of cities</returns>
        private bool IsPopulationCorrect(uint populationToAdd) 
        {
            uint populationCalculated = populationToAdd;
            _cities.ForEach(city => populationCalculated += city.Population);
            return (Population >= populationCalculated);
        }

        /// <summary>
        /// Checks city for null value returns exception if null
        /// </summary>
        /// <param name="city">city to check</param>
        private void CheckCityForNull(City city) 
        {
            if (city == null)
                throw new ArgumentException("city can't be null");
        }
        private void CheckCityForSameCountry(City city) 
        {
            if (city.BelongsTo != this)
                throw new ArgumentException($"city is not from country: {Name}");
        }
        private void CheckCapitalNotFromOtherCountry(City capital) 
        {
            if(capital.CapitalFrom != this)
                throw new ArgumentException($"capital is not from country: {Name}");
        }

        #endregion
        #region equals
        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   Name == country.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        #endregion
    }
}
