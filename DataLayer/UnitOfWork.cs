using DataLayer.Repositories;
using DomainLayer;
using DomainLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// context used for database
        /// </summary>
        private readonly GeoServiceContext context;
        public IContinentRepository Continents { get; set; }

        public IRiversRepository Rivers { get; set; }

        public ICountriesRepository Countries { get; set; }

        public ICitiesRepository Cities { get; set; }

        public UnitOfWork(GeoServiceContext context)
        {
            this.context = context;
            Continents = new ContinentRepository(context);
            Rivers = new RiversRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
