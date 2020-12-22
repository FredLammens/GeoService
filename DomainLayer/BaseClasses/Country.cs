using System;
using System.Collections.Generic;
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
        //Todo: 
        public void AddCity(string name, long population) 
        {
            City city = new City(name, population, this);
            bool inCities = _cities.Contains(city);
            if (inCities)
                throw new ArgumentException("city already added.");
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
        //Todo: add capitalfrom
        public void AddCaptial(string name, long population) 
        {
            City city = new City(name, population, this);
            bool inCapitals = _capitals.Contains(city);
            if (inCapitals)
                throw new ArgumentException("capital already added.");
            _capitals.Add(city);
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
        #endregion
        #region equals
        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   Name == country.Name &&
                   Population == country.Population &&
                   Surface == country.Surface &&
                   EqualityComparer<Continent>.Default.Equals(Continent, country.Continent);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Population, Surface, Continent);
        }
        #endregion
    }
}
