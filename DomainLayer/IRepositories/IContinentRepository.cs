using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepositories
{
    public interface IContinentRepository
    {
        /// <summary>
        /// Add continent to database.
        /// </summary>
        /// <param name="continent"></param>
        void AddContinent(Continent continent);
        /// <summary>
        /// Gets continent from database with given id
        /// </summary>
        /// <param name="id">id of continent to get</param>
        void GetContinent(int id);
        /// <summary>
        /// Updates continent in database with given continent object
        /// </summary>
        /// <param name="continent">updated continent</param>
        void UpdateContinent(Continent continent);
    }
}
