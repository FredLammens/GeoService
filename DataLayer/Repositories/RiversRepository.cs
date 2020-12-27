using DomainLayer.BaseClasses;
using DomainLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class RiversRepository : IRiversRepository
    {
        private readonly GeoServiceContext context;
        public RiversRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public void AddRiver(River river)
        {
            throw new NotImplementedException();
        }

        public void DeleteRiver(int riverId)
        {
            throw new NotImplementedException();
        }

        public River GetRiver(int riverId)
        {
            throw new NotImplementedException();
        }

        public bool isInRivers(int riverId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRiver(int riverId, River river)
        {
            throw new NotImplementedException();
        }
    }
}
