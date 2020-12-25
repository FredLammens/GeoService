using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class DCountry
    {
        /// <summary>
        /// Data CountryId
        /// </summary>
        [Key]
        public uint Id { get; set; }
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
        /// Data Continent country belongs to
        /// </summary>
        [Required]
        public DContinent Continent { get; set; }


        /// <summary>
        /// Data Rivers of country
        /// </summary>
        public List<DRiver> Rivers { get; set; }
        /// <summary>
        /// Data Cities of country
        /// </summary>
        public List<DCity> Cities { get; set; }
        /// <summary>
        /// Data capitals of country
        /// </summary>
        public List<DCity> Capitals { get; set; }
        public DCountry()
        {

        }

        public DCountry(uint id, string name, uint population, float surface)
        {
            Id = id;
            Name = name;
            Population = population;
            Surface = surface;
        }

        /// <summary>
        /// Constructor to make country object
        /// </summary>
        /// <param name="name">Country name = unique</param>
        /// <param name="population">Population of country</param>
        /// <param name="surface">Surface area of country</param>
        /// <param name="continent">continent country belongs to</param>
        public DCountry(string name, uint population, float surface, DContinent continent)
        {
            Name = name;
            Population = population;
            Surface = surface;
            Continent = continent;
        }
    }
}
