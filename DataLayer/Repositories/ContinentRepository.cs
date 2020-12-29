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

        public void DeleteContinent(int continentId)
        {
            if (!context.Continents.Any(c => c.Id == continentId))
                throw new Exception($"continent with is: {continentId} not in database.");
            context.Continents.Remove(context.Continents.Single(c => c.Id == continentId));
        }

        public void UpdateContinent(Continent continent)
        {
            if (!context.Continents.Any(c => c.Name == continent.Name))
                throw new Exception($"Continent: {continent.Name} not in database.");
            DContinent continentToUpdate =  context.Continents
                                            .Include(continent => continent.Countries)
                                            .Single(c => c.Name == continent.Name);
            continentToUpdate.Name = continent.Name;
        }

        public bool isInContinents(int continentId)
        {
            throw new NotImplementedException();
        }
    }
}
