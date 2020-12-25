using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class DContinent
    {
        /// <summary>
        /// Data continent Id
        /// </summary>
        [Key]
        public uint Id { get; set; }

        /// <summary>
        /// Data continent name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Data continent population
        /// </summary>
        [Required]
        public ulong Population { get; set; }
        /// <summary>
        /// Data continent countries
        /// </summary>
        [Required]
        public List<DCountry> Countries { get; set; } = new List<DCountry>();


        public DContinent() { }

        public DContinent(uint id, string name, ulong population)
        {
            Id = id;
            Name = name;
            Population = population;
        }

        public DContinent(uint id, string name, ulong population, List<DCountry> countries) : this(id, name, population)
        {
            Countries = countries;
        }
    }
}
