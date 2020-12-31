using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class DCountry
    {
        [Key]
        public int Key { get; set; }
        /// <summary>
        /// Data CountryId
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Data Country name = unique
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Data Population of country
        /// </summary>
        [Required]
        public uint Population { get; set; }
        /// <summary>
        /// Data Surface area of country
        /// </summary>
        [Required]
        public float Surface { get; set; }


        /// <summary>
        /// Data Rivers of country
        /// </summary>
        public List<CountryRiver> Rivers { get; set; }
        /// <summary>
        /// Data Cities of country
        /// </summary>
        [NotMapped]
        public List<DCity> Cities { get; set; }
        /// <summary>
        /// Data capitals of country
        /// </summary>
        [NotMapped]
        public List<DCity> Capitals { get; set; }

        /// <summary>
        /// Continent where country belongs to
        /// </summary>
        [Required]
        public DContinent Continent { get; set; }
        public DCountry()
        {

        }

    }
}
