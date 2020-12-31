using DataLayer.BaseClasses;
using DomainLayer.BaseClasses;
using DomainLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #region Continent
        public Continent GetContinent(int id)
        {
            if (!context.Continents.Any(c => c.Id == id))
                throw new Exception($"Continent with id: {id} not in DB.");
            DContinent dContinent = context.Continents
                                           .AsNoTracking()
                                           .Include(continent => continent.Countries)
                                           .AsNoTracking()
                                           .Single(c => c.Id == id);
            return Mapper.FromDContinentToContinent(dContinent);
        }

        public void AddContinent(Continent continent)
        {
            DContinent dContinent = Mapper.FromContinentToDContinent(continent);
            if (context.Continents.Any(c => c.Name == continent.Name))
                throw new Exception($"Continent: {continent.Name} already in database.");
            context.Continents.Add(dContinent);
        }
        public Continent GetContinentByName(string name) 
        {
            if (!context.Continents.Any(c => c.Name == name))
                throw new Exception($"Continent: {name} not in DB.");
            DContinent dContinent = context.Continents
                                           .AsNoTracking()
                                           .Include(continent => continent.Countries)
                                           .AsNoTracking()
                                           .Single(c => c.Name == name);
            return Mapper.FromDContinentToContinent(dContinent);
        }
        public void DeleteContinent(int continentId)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"continent with is: {continentId} not in database.");
            if (GetContinent(continentId).Countries.Count > 0)
                throw new Exception("Continent still has countries. Pls remove these first.");
            context.Continents.Remove(context.Continents.Single(c => c.Id == continentId));
        }

        public void UpdateContinent(Continent continent, int continentId)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in database.");
            DContinent continentToUpdate =  context.Continents
                                            .Include(continent => continent.Countries)
                                            .Single(c => c.Id == continentId);
            continentToUpdate.Name = continent.Name;
        }

        public bool isInContinents(int continentId)
        {
            return context.Continents.Any(c => c.Id == continentId);
        }
        #endregion
        #region Country
        public Country GetCountry(int continentId, int countryId)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in DB.");
            DContinent continent = context.Continents
                                           .Include(continent => continent.Countries)
                                           .AsNoTracking()
                                           .Single(c => c.Id == continentId);
            DCountry country = continent.Countries.SingleOrDefault(c => c.Id == countryId);
            if (country == null)
                throw new Exception($"Country with id: {countryId} not in DB.");
            return Mapper.FromDCountryToCountry(country);
        }
        public Country GetCountryByName(int continentId, string name)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in DB.");
            DContinent continent = context.Continents
                                           .Include(continent => continent.Countries)
                                           .AsNoTracking()
                                           .Single(c => c.Id == continentId);
            DCountry country = continent.Countries.SingleOrDefault(c => c.Name == name);
            if (country == null)
                throw new Exception($"Country: {name} not in DB.");
            return Mapper.FromDCountryToCountry(country);
        }
        public bool isInCountry(int continentId, int countryId)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in DB.");
            DContinent continent = context.Continents
                                           .Include(continent => continent.Countries)
                                           .AsNoTracking()
                                           .Single(c => c.Id == continentId);
            return continent.Countries.Any(c => c.Id == countryId);
        }

        public void UpdateCountry(int continentId, int countryId, Country country)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in DB.");
            DContinent continent = context.Continents
                                           .Include(continent => continent.Countries)
                                           .Single(c => c.Id == continentId);
            DCountry countryToUpdate = continent.Countries.SingleOrDefault(c => c.Id == countryId);
            if (countryToUpdate == null)
                throw new Exception($"country with id: {countryId} not in DB.");
            countryToUpdate.Id = (int)country.Id;
            countryToUpdate.Population = country.Population;
            countryToUpdate.Surface = country.Surface;
            countryToUpdate.Name = country.Name;
        }
        public void AddCountry(int continentId, Country country)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in DB.");
            DContinent continent = context.Continents
                                           .Include(continent => continent.Countries)
                                           .Single(c => c.Id == continentId);
            if (continent.Countries.Any(c => c.Name == country.Name))
                throw new Exception($"Country: {country.Name} already in DB.");
            DCountry toAdd = Mapper.FromCountryToDCountry(country);
            if (toAdd.Id == 0)
                toAdd.Id = continent.Countries.Count;
            continent.Countries.Add(toAdd);
        }

        public void DeleteCountry(int continentId, int countryId)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"Continent with id: {continentId} not in DB.");
            DContinent continent = context.Continents
                                           .Include(continent => continent.Countries)
                                           .Single(c => c.Id == continentId);
            DCountry country = continent.Countries.SingleOrDefault(c => c.Id == countryId);
            if (country == null)
                throw new Exception($"country with id: {countryId} not in DB.");
            continent.Countries.Remove(country);
        }
        #endregion
        #region City
        public City GetCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }

        public bool isInCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(int continentId, int countryId, int cityId, City city)
        {
            throw new NotImplementedException();
        }


        public void AddCity(int continentId, int countryId, City city)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(int continentId, int countryId, int cityId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
