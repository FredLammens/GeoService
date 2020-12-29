using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepositories
{
    public interface IContinentRepository
    {
        /// <summary>
        /// Add continent to database. if not already present
        /// </summary>
        /// <param name="continent">continent object to add.</param>
        void AddContinent(Continent continent);
        /// <summary>
        /// Gets continent from database with given id
        /// </summary>
        /// <param name="id">id of continent to get</param>
        Continent GetContinent(int id);
        /// <summary>
        /// Updates continent in database with given continent object
        /// </summary>
        /// <param name="continent">updated continent</param>
        void UpdateContinent(Continent continent);
        /// <summary>
        /// Checks if continent is in database.
        /// </summary>
        /// <param name="continentId">continentId to check</param>
        /// <returns></returns>
        bool isInContinents(int continentId);
        /// <summary>
        /// Delete's continent from database if all cities are removed from this continent.
        /// </summary>
        /// <param name="continentId">id of continent to remove</param>
        void DeleteContinent(int continentId);

    }
}
