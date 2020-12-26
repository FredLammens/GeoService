using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class DomainController : IDomainController
    {
        public void AddCity(int continentId, int countryId, City city)
        {
            throw new NotImplementedException();
        }

        public void AddContinent(Continent continent)
        {
            throw new NotImplementedException();
        }

        public void AddCountry(int continentId, Country country)
        {
            throw new NotImplementedException();
        }

        public void AddRiver(River river)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteContinent(int continentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(int continentId, int countryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRiver(int riverId)
        {
            throw new NotImplementedException();
        }

        public City GetCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }

        public Continent GetContinent(int continentId)
        {
            throw new NotImplementedException();
        }

        public Country GetCountry(int continentId, int countryId)
        {
            throw new NotImplementedException();
        }

        public River GetRiver(int riverId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(int continentId, int countryId, int cityId, City city)
        {
            throw new NotImplementedException();
        }

        public void UpdateContinent(int continentId, Continent continent)
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(int continentId, int countryId, Country country)
        {
            throw new NotImplementedException();
        }

        public void UpdateRiver(int riverId, River river)
        {
            throw new NotImplementedException();
        }
    }
}
