using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepositories
{
    public interface IContinentRepository
    {
        #region continent
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
        /// <summary>
        /// Get's country from country id from continent gotten with id
        /// </summary>
        /// <param name="continentId">continent id to get country from</param>
        /// <param name="countryId">country id to get</param>
        /// <returns></returns>
        #endregion
        #region Country
        Country GetCountry(int continentId, int countryId);
        /// <summary>
        /// checks if country is part of continent
        /// </summary>
        /// <param name="continentId">continent id to check </param>
        /// <param name="countryId">country id</param>
        /// <returns></returns>
        bool isInCountry(int continentId, int countryId);
        /// <summary>
        /// Updates country from continent in DB
        /// </summary>
        /// <param name="continentId">continent id</param>
        /// <param name="countryId">country id to update</param>
        /// <param name="country">update object</param>
        void UpdateCountry(int continentId, int countryId, Country country);
        /// <summary>
        /// Gets city from database from country from continent
        /// </summary>
        /// <param name="continentId">continent id</param>
        /// <param name="countryId">country id</param>
        /// <param name="cityId">city id to get</param>
        /// <returns></returns>
        #endregion
        #region City
        City GetCity(int continentId, int countryId, int cityId);
        /// <summary>
        /// checks if city is part of country that is part of continent
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="countryId"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        bool isInCity(int continentId, int countryId, int cityId);
        /// <summary>
        /// Updates city form database from country from continent
        /// </summary>
        /// <param name="continentId">continent id</param>
        /// <param name="countryId">country id</param>
        /// <param name="cityId">city id</param>
        /// <param name="city">city object to update</param>
        void UpdateCity(int continentId, int countryId, int cityId, City city);
        #endregion

    }
}
