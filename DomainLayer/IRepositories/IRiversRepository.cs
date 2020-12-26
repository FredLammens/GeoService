using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepositories
{
    public interface IRiversRepository
    {
        /// <summary>
        /// Adds river to database.
        /// </summary>
        /// <param name="river"></param>
        void AddRiver(River river);
    }
}
