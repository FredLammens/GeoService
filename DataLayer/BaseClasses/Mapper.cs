using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class Mapper
    {
        public static DRiver FromRiverToDRiver(River river) 
        {
            //return new DRiver(river.Id, river.Name, river.Length,);
            throw new NotImplementedException();
        }
        public static DCountry FromCountryToDCountry(Country country) 
        {
            //return new DCountry(country.Name,country.Population,country.Surface,)
            throw new NotImplementedException();
        }
    }
}
