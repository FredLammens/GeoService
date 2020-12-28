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
    public class RiversRepository : IRiversRepository
    {
        private readonly GeoServiceContext context;
        public RiversRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public void AddRiver(River river)
        {
            if (context.Rivers.Any(r => r.Name == river.Name))
                throw new Exception("River already in database.");
            DRiver dRiver = Mapper.FromRiverToDRiver(river);
            context.Rivers.Add(dRiver);
        }

        public void DeleteRiver(int riverId)
        {
            CheckIfRiverInDB(riverId);
            context.Rivers.Remove(context.Rivers.Single(r => r.Id == riverId));
        }

        public River GetRiver(int riverId)
        {
            CheckIfRiverInDB(riverId);
            DRiver dRiver = context.Rivers
                                   .AsNoTracking()
                                   .Include(r => r.Countries)
                                   .AsNoTracking()
                                   .Single(r => r.Id == riverId);
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
        private void CheckIfRiverInDB(int riverId) 
        {
            if (!context.Rivers.Any(r => r.Id == riverId))
                throw new Exception("river not in database.");
        }
    }
}
