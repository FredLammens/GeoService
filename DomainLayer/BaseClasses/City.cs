using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class City
    {
        /// <summary>
        /// Id of city
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of city
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Population of city
        /// </summary>
        public uint Population { get; set; }
        /// <summary>
        /// Country city belongs to
        /// </summary>
        public Country BelongsTo { get; set; }
        /// <summary>
        /// is capital from 
        /// </summary>
        public Country CapitalFrom { get; set; }
        /// <summary>
        /// Constructor for makin city object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="population"></param>
        /// <param name="belongsTo"></param>

        public City( string name, uint population, Country belongsTo)
        {
            Name = name;
            Population = population;
            BelongsTo = belongsTo;
        }
        #region equals
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
        #endregion
    }
}
