using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get => Name; private set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be null or empty."); Name = value; } }
        public long Population
        {
            get => Population;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Population can't be negative.");
                Population = value;
            }
        }
        public double Surface {
            get => Surface;
            private set 
            {
                if (value < 0)
                    throw new ArgumentException("Surface can't be negative.");
                Surface = value;
            }
        }
        public Continent Continent { get; set; }

        private List<River> _rivers = new List<River>();
        private List<City> _cities = new List<City>();
        private List<City> _capitals = new List<City>();
        public IReadOnlyList<River> Rivers => _rivers.AsReadOnly();
        public IReadOnlyList<City> Cities => _cities.AsReadOnly();
        public IReadOnlyList<City> Capitals => _capitals.AsReadOnly();

        public Country(string name, long population, double surface, Continent continent)
        {
            Name = name;
            Population = population;
            Surface = surface;
            Continent = continent;
        }
        //Todo: fix river like city 
        internal void AddRiver(River river) 
        {
            CheckRiverForNull(river);
            bool isInRivers = _rivers.Contains(river);
            if (isInRivers)
                throw new ArgumentException($"{river.Name} is already in {this.Name}");
            _rivers.Add(river);
        }
        public void RemoveRiver(River river) 
        {
            CheckRiverForNull(river);
            bool isRemoved = _rivers.Remove(river);
            if (!isRemoved)
            {
                    throw new ArgumentException($"river is not in {Name}");
            }
        }
        public void AddCity(string name, long population) 
        {
            City city = new City(name, population, this);
            bool inCities = _cities.Contains(city);
            if (inCities)
                throw new ArgumentException("city already added.");
            //check population city doesnt exceed population country
            if (!IsPopulationCorrect(population))
                throw new Exception("population would exceed country's population.");
            _cities.Add(city);
        }
        public void RemoveCity(City city) 
        {
            CheckCityForNull(city);
            bool isRemoved = _cities.Remove(city);
            if (!isRemoved)
            {
                    throw new ArgumentException($"river is not in {Name}");
            }
        }
        public void AddCaptial(string name, long population) 
        {
            City capital = new City(name, population, this)
            {
                CapitalFrom = this
            };
            bool inCapitals = _capitals.Contains(capital);
            if (inCapitals)
                throw new ArgumentException("capital already added.");
            _capitals.Add(capital);
            //addToCities
            City toAddToCities = _cities.SingleOrDefault(city => city == capital);
            if (toAddToCities != null)
            {
                toAddToCities.CapitalFrom = this;
            }
            else 
            {
                _cities.Add(toAddToCities);
            }
        }
        public void RemoveCapital(City city) 
        {
            CheckCityForNull(city);
            bool isRemoved = _capitals.Remove(city);
            if (!isRemoved)
            {
                throw new ArgumentException($"river is not in {Name}");
            }
        }
        #region Checkfunctions

        private bool IsPopulationCorrect(long populationToAdd) 
        {
            long populationCalculated = populationToAdd;
            _cities.ForEach(city => populationCalculated += city.Population);
            return (Population >= populationCalculated);
        }
        private void CheckRiverForNull(River river) 
        {
            if (river == null)
                throw new ArgumentException("river can't be null");
        }
        private void CheckCityForNull(City city) 
        {
            if (city == null)
                throw new ArgumentException("city can't be null");
        }

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
        #region equals


        #endregion
    }
}
