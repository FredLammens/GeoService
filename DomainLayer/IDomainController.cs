using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IDomainController
    {
        /// <summary>
        /// Adds continent to database
        /// </summary>
        /// <param name="continent">continent to add</param>
        public void AddContinent(Continent continent);
        /// <summary>
        /// Gets continent from database
        /// </summary>
        /// <param name="continentId">continent to get</param>
        /// <returns></returns>
        public Continent GetContinent(int continentId);
        /// <summary>
        /// Delete's continent from database
        /// </summary>
        /// <param name="continentId">id of continent to delete</param>
        public void DeleteContinent(int continentId);
        /// <summary>
        /// Update's continent from database if already in database.
        /// Insert into database if doesnt exist yet.
        /// </summary>
        /// <param name="continentId">continent id to update</param>
        /// <param name="continent">continent object to update with</param>
        public void UpsertContinent(int continentId, Continent continent);
        /// <summary>
        /// Add's country to database
        /// </summary>
        /// <param name="continentId">continent id to add country to </param>
        /// <param name="country">country object to add to database</param>
        public void AddCountry(int continentId,Country country);
        /// <summary>
        /// Gets country from database
        /// </summary>
        /// <param name="continentId">continent id to get country from </param>
        /// <param name="countryId">country id to get</param>
        /// <returns>Country object</returns>
        public Country GetCountry(int continentId, int countryId);
        /// <summary>
        /// Deletes country from database
        /// </summary>
        /// <param name="continentId">continent id to remove country from </param>
        /// <param name="countryId">country id to delete </param>
        public void DeleteCountry(int continentId, int countryId);
        /// <summary>
        /// Updates country from database if already in DB.
        /// Inserts country in DB if not already in
        /// </summary>
        /// <param name="continentId">continent id to update country from</param>
        /// <param name="countryId">country id to be updated </param>
        /// <param name="country">country object to update</param>
        public void UpsertCountry(int continentId, int countryId, Country country);
        /// <summary>
        /// Adds city to database
        /// </summary>
        /// <param name="continentId">continent id to add city from</param>
        /// <param name="countryId">country id to add city to</param>
        /// <param name="city">city object to add</param>
        public void AddCity(int continentId, int countryId, City city);
        /// <summary>
        /// Get city from database
        /// </summary>
        /// <param name="continentId">continent id to get city from</param>
        /// <param name="countryId">country id to get city from</param>
        /// <param name="cityId">city id to get</param>
        /// <returns>City object</returns>
        public City GetCity(int continentId, int countryId, int cityId);
        /// <summary>
        /// Delete's city from database
        /// </summary>
        /// <param name="continentId">continent id to delete city from</param>
        /// <param name="countryId">country id to delete city from</param>
        /// <param name="cityId">city id to delete</param>
        public void DeleteCity(int continentId, int countryId, int cityId);
        /// <summary>
        /// Update's city from database if already in DB.
        /// Insert into DB if not in DB.
        /// </summary>
        /// <param name="continentId">continent id to update city from</param>
        /// <param name="countryId">country id to update city from</param>
        /// <param name="cityId">city id to update</param>
        /// <param name="city">city object to update</param>
        public void UpsertCity(int continentId, int countryId, int cityId, City city);
        /// <summary>
        /// Add's river to database
        /// </summary>
        /// <param name="river">river object to add</param>
        public void AddRiver(River river);
        /// <summary>
        /// Get's river to database
        /// </summary>
        /// <param name="riverId">riverId of river to get</param>
        /// <returns></returns>
        public River GetRiver(int riverId);
        /// <summary>
        /// Delete's river from database
        /// </summary>
        /// <param name="riverId">riverId to delete</param>
        public void DeleteRiver(int riverId);
        /// <summary>
        /// Update's river from database if already in DB.
        /// Insert river into database if not in DB.
        /// </summary>
        /// <param name="riverId">riverId to update</param>
        /// <param name="river">river object to update</param>
        public void UpsertRiver(int riverId, River river);


    }
}
