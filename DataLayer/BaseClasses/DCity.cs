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


        public DCity()
        {

        }
    }
}
