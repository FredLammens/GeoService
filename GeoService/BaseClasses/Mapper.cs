using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class Mapper
    {
        public static Continent FromRContinentInToContinent(RContinentIn rContinentIn) 
        {
            return new Continent(rContinentIn.Name);
        }
        public static RContinentOut FromContinentToRContinentOut(Continent continent, string apiUrl) 
        {
            RContinentOut rOut = new RContinentOut() {
                Id = apiUrl + "api/Continent/" + continent.Id,
                Name = continent.Name,
                Population = (long)continent.Population
            };
            //countries toevoegen
            List<string> countriesToAdd = new List<string>();
            foreach (Country country in continent.Countries)
            {
                countriesToAdd.Add(rOut.Id + "/Country/" +  country.Id);
            }
            rOut.Countries = countriesToAdd;
            return rOut;
        }
        public static Country FromRCountryInToCountry(RCountryIn rCountryIn, Continent continent) 
        {
            return new Country(rCountryIn.Name, (uint)rCountryIn.Population, rCountryIn.Surface, continent);
        }
        public static RCountryOut FromCountryToRCountryOut(Country country, string apiUrl) 
        {
            RCountryOut rOut = new RCountryOut() {Name = country.Name,Population = (int)country.Population, Surface =  country.Surface, ContinentId = apiUrl + "api/Continent/"+ country.Continent.Id };
            rOut.CountryId = rOut.ContinentId +"/Country/"+ country.Id;
            return rOut;
        }
    }
}
