using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class DomainController : IDomainController
    {
        private readonly IUnitOfWork uow;
        public DomainController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddContinent(Continent continent) 
        {
            uow.Continents.AddContinent(continent);
            uow.Complete();
        }
        public Continent GetContinent(int continentId) 
        {
            return uow.Continents.GetContinent(continentId);
        }
        public void DeleteContinent(int continentId) 
        {
            uow.Continents.DeleteContinent(continentId);
            uow.Complete();
        }
        public void UpsertContinent(int continentId, Continent continent) 
        {
            //if continent not in DB add 
            if (!uow.Continents.isInContinents(continentId))
            {
                uow.Continents.UpdateContinent(continent);
                uow.Complete();
            }
            else //if continent in DB update
            { 
                uow.Continents.AddContinent(continent);
                uow.Complete();
            }      
        }
        public void AddCountry(int continentId, Country country) 
        {
            uow.Continents.AddCountry(continentId, country);
            uow.Complete();
        }
        public Country GetCountry(int continentId, int countryId) 
        {
            return uow.Continents.GetCountry(continentId, countryId);
        }
        public void DeleteCountry(int continentId, int countryId) 
        {
            uow.Continents.DeleteCountry(continentId,countryId);
            uow.Complete();
        }
        public void UpsertCountry(int continentId, int countryId, Country country) 
        {
            //if Country is not in DB add 
            if (!uow.Continents.isInCountry(continentId, countryId))
            {
                AddCountry(continentId, country);
                uow.Complete();
            }
            else //if Country is in DB update
            {
                uow.Continents.UpdateCountry(continentId, countryId, country);
                uow.Complete();
            }
        }
        public void AddCity(int continentId, int countryId, City city) 
        {
            //Country country = GetCountry(continentId, countryId);
            //country.AddCity(city);
            //uow.Continents.UpdateCountry(continentId,countryId,country);
            //uow.Complete();
            throw new NotImplementedException();
        }

        public City GetCity(int continentId, int countryId, int cityId) 
        {
            //return uow.Continents.GetCity(continentId, countryId, cityId);
            throw new NotImplementedException();
        }

        public void DeleteCity(int continentId, int countryId, int cityId) 
        {
            //Country country = GetCountry(continentId, countryId);
            //country.RemoveCity(GetCity(continentId, countryId, cityId));
            //uow.Continents.UpdateCountry(continentId, countryId, country);
            //uow.Complete();
            throw new NotImplementedException();
        }

        public void UpsertCity(int continentId, int countryId, int cityId, City city) 
        {
            ////if City is not in DB add 
            //if (!uow.Continents.isInCity(continentId, countryId, cityId))
            //{
            //    AddCity(continentId, countryId, city);
            //    uow.Complete();
            //}
            //else //if city is in DB update
            //{ 
            //    uow.Continents.UpdateCity(continentId, countryId, cityId, city);
            //    uow.Complete();
            //}
            throw new NotImplementedException();
        }

        public void AddRiver(River river) 
        {
            uow.Rivers.AddRiver(river);
            uow.Complete();
        }

        public River GetRiver(int riverId) 
        {
            return uow.Rivers.GetRiver(riverId);
        }

        public void DeleteRiver(int riverId) 
        {
            uow.Rivers.DeleteRiver(riverId);
            uow.Complete();
        }

        public void UpsertRiver(int riverId, River river) 
        {
            if (!uow.Rivers.isInRivers(riverId))
            {
                AddRiver(river);
                uow.Complete();
            }
            else 
            {
                uow.Rivers.UpdateRiver(riverId, river);
                uow.Complete();
            }
        }
    }
}
