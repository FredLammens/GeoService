using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Country city belongs to
        /// </summary>
        public DCountry BelongsTo { get; set; }
        /// <summary>
        /// is capital from 
        /// </summary>
        public DCountry CapitalFrom { get; set; }
        public DCity()
        {

        }
    }
}
