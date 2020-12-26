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
            throw new NotImplementedException();
        }

        public void GetContinent(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContinent(Continent continent)
        {
            throw new NotImplementedException();
        }
    }
}
