using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public Country BelongsTo { get; set; }
        public Country CapitalFrom { get; set; }

        public City( string name, long population, Country belongsTo)
        {
            Name = name;
            Population = population;
            BelongsTo = belongsTo;
        }

        public override bool Equals(object obj)
        {
            return obj is City city &&
                   Name == city.Name &&
                   Population == city.Population;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Population);
        }
    }
}
