﻿using System;
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
        /// Data Rivers of country
        /// </summary>
        public List<CountryRiver> Rivers { get; set; }
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

        public DCountry(string name, uint population, float surface, List<CountryRiver> rivers, List<DCity> cities, List<DCity> capitals)
        {
            Name = name;
            Population = population;
            Surface = surface;
            Rivers = rivers;
            Cities = cities;
            Capitals = capitals;
        }
    }
}
