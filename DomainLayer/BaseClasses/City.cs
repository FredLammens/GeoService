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
        public uint Id { get; set; }
        private string _name;
        /// <summary>
        /// Name of city
        /// </summary>
        public string Name { get => _name; private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null or empty.");
                }
                _name = value;
            }
        }
        /// <summary>
        /// Population of city
        /// </summary>
        public uint Population { get; set; }
        private Country _belongsTo;
        /// <summary>
        /// Country city belongs to
        /// </summary>
        public Country BelongsTo { get => _belongsTo;
            private set 
            {
                _belongsTo = value ?? throw new ArgumentException("City needs to belong to country.");
            }
        }
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

        public City(string name, uint population, Country belongsTo)
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
