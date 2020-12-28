using DataLayer.BaseClasses;
using DomainLayer.BaseClasses;
using DomainLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly GeoServiceContext context;
        public ContinentRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public void AddContinent(Continent continent)
        {

        }

        public void DeleteContinent(int continentId)
        {
            throw new NotImplementedException();
        }

        public City GetCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }

        public Continent GetContinent(int id)
        {
            throw new NotImplementedException();
        }

        public Country GetCountry(int continentId, int countryId)
        {
            throw new NotImplementedException();
        }

        public bool isInCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }

        public bool isInContinents(int continentId)
        {
            throw new NotImplementedException();
        }

        public bool isInCountry(int continentId, int countryId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(int continentId, int countryId, int cityId, City city)
        {
            throw new NotImplementedException();
        }

        public void UpdateContinent(Continent continent)
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(int continentId, int countryId, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
