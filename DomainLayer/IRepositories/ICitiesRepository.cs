using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepositories
{
    public interface ICitiesRepository
    {
        /// <summary>
        /// Gets city from database from country from continent
        /// </summary>
        /// <param name="continentId">continent id</param>
        /// <param name="countryId">country id</param>
        /// <param name="cityId">city id to get</param>
        /// <returns></returns>
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
    }
}
