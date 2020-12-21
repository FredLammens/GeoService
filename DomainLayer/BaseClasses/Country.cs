using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public double Surface { get; set; }
        public Continent Continent { get; set; }
        public River River { get; set; }
        public List<City> Cities { get; set; }
        public List<City> Capitals { get; set; }
    }
}
