using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public double Surface { get; set; }
        public Continent Continent { get => Continent; set { value.AddCountry(this); Continent = value; } }
        public River River { get; set; }
        public List<City> Cities { get; set; }
        public List<City> Capitals { get; set; }



    }
}
