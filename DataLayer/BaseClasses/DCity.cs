using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class DCity
    {
        /// <summary>
        /// Data Id of city
        /// </summary>
        [Key]
        public uint Id { get; set; }
        /// <summary>
        /// Data Name of city
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Data Population of city
        /// </summary>
        [Required]
        public uint Population { get; set; }
        /// <summary>
        /// Data Country city belongs to
        /// </summary>
        [Required]
        public DCountry BelongsTo { get; set; }
        /// <summary>
        /// Capital from DataCountry
        /// </summary>
        public DCountry CapitalFrom { get; set; }

        public DCity()
        {

        }

        public DCity(uint id, string name, uint population)
        {
            Id = id;
            Name = name;
            Population = population;
        }
    }
}
