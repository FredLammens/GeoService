using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepositories
{
    public interface ICountriesRepository
    {
        /// <summary>
        /// Get's country from country id from continent gotten with id
        /// </summary>
        /// <param name="continentId">continent id to get country from</param>
        /// <param name="countryId">country id to get</param>
        /// <returns></returns>
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
    }
}
