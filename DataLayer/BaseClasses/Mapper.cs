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
            DRiver dataRiver = new DRiver
            {
                Length = river.Length,
                Name = river.Name,
                Countries = FromCountryToCountryRiver(river.Countries, river)
            };
            return dataRiver;
        }
        //country moet geen rivieren hebben rivier moet minstens 1 country hebben
        public static List<CountryRiver> FromCountryToCountryRiver(IReadOnlyList<Country> countries, River river) 
        {
            List<CountryRiver> countrieRivers = new List<CountryRiver>();
            foreach (Country country in countries)
            {
                CountryRiver countrieRiver = new CountryRiver
                {
                    Country = FromCountryToDCountry(country)
                };
                DRiver dataRiver = new DRiver
                {
                    Length = river.Length,
                    Name = river.Name
                };
                countrieRiver.River = dataRiver;
                countrieRivers.Add(countrieRiver);
                // Todo: key veranderen naar name??? van countryRiver1 nee want bij toevoeging rivier ?
            }
            return countrieRivers;
        }
        public static DCountry FromCountryToDCountry(Country country) 
        {
            DCountry dataCountry = new DCountry
            {
                Name = country.Name,
                Population = country.Population,
                Surface = country.Surface
            };
            return dataCountry;
        }
        public static DContinent FromContinentToDContinent(Continent continent) 
        {
            DContinent dContinent = new DContinent
            {
                Name = continent.Name,
                Population = continent.Population
            };
            List<DCountry> toAdd = new List<DCountry>();
            foreach (Country country in continent.Countries)
            {
                toAdd.Add(FromCountryToDCountry(country));
            }
            dContinent.Countries = toAdd;
            return dContinent;        
        }
        public static River FromDRiverToRiver(DRiver river) 
        {
            //return new River(river.Name, river.Length, river.Countries[0].Country);
            throw new NotImplementedException();
        }
        public static Country FromDCountryToCountry(DCountry dCountry) 
        {
            //return new Country(dCountry.Name,dCountry.Population,dCountry.Surface,)
            throw new NotImplementedException();
        }
        public static Continent FromDContinentToContinent(DContinent dContinent) 
        {
            Continent c =  new Continent(dContinent.Name)
            {
                Id = dContinent.Id,
            };
            //c.AddCountry(dContinent.Countries)
            throw new NotImplementedException();
        }
    }
}
