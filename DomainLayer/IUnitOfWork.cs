using DomainLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Repository for Continents from DB.
        /// </summary>
        IContinentRepository Continents { get; }
        /// <summary>
        /// Repository for Rivers from DB.
        /// </summary>
        IRiversRepository Rivers { get; }
        /// <summary>
        /// Repository for Countries from DB.
        /// </summary>
        ICountriesRepository Countries { get; }
        /// <summary>
        /// Repository for Cities from DB.
        /// </summary>
        ICitiesRepository Cities { get; }
        /// <summary>
        /// Method for completing unit of work.
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
