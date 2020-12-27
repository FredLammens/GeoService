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
        /// <param name="river">river object to add</param>
        void AddRiver(River river);
        /// <summary>
        /// Gets river from database
        /// </summary>
        /// <param name="riverId">river id to get</param>
        /// <returns>River object</returns>
        River GetRiver(int riverId);
        /// <summary>
        /// Deletes river from database
        /// </summary>
        /// <param name="riverId">river id</param>
        void DeleteRiver(int riverId);
        /// <summary>
        /// Updates river from database
        /// </summary>
        /// <param name="riverId">riverId to update</param>
        /// <param name="river">river object to update to</param>
        void UpdateRiver(int riverId, River river);
        /// <summary>
        /// Checks if river with id is in rivers DB
        /// </summary>
        /// <param name="riverId">river id to check</param>
        /// <returns>true if found</returns>

        bool isInRivers(int riverId);
    }
}
