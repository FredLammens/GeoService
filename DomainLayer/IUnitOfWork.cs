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
        /// Method for completing unit of work.
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
