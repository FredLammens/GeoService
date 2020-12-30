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
        public int Id { get; set; }

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

    }
}
