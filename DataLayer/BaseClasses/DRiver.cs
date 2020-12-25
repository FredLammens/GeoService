using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class DRiver
    {
        /// <summary>
        /// Data Id of river
        /// </summary>
        [Key]
        public uint Id { get; set; }
        /// <summary>
        /// Data Name of River
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Data Length of river in m
        /// </summary>
        [Required]
        public double Length { get; set; }

        /// <summary>
        /// Data List of countries that river is in.
        /// </summary>
        [Required]
        public List<DCountry> Countries { get; set; } = new List<DCountry>();

        public DRiver()
        {

        }
        public DRiver(uint id, string name, double length)
        {
            Id = id;
            Name = name;
            Length = length;
        }

        public DRiver(uint id, string name, double length, List<DCountry> countries) : this(id, name, length)
        {
            Countries = countries;
        }
    }
}
