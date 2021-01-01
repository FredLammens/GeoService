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
        public static RContinentOut FromContinentToRContinentOut(Continent continent) 
        {
            RContinentOut rOut = new RContinentOut() {
                Id = continent.Id.ToString(),
                Name = continent.Name,
                Population = (long)continent.Population
            };
            //countries toevoegen
            List<string> countriesToAdd = new List<string>();
            foreach (Country country in continent.Countries)
            {
                countriesToAdd.Add(Constants.apiUrl + country.Id);
            }
            rOut.Countries = countriesToAdd;
            return rOut;
        }
        public static Country FromRCountryInToCountry(RCountryIn rCountryIn, Continent continent) 
        {
            return new Country(rCountryIn.Name, (uint)rCountryIn.Population, rCountryIn.Surface, continent);
        }
        public static RCountryOut FromCountryToRCountryOut(Country country) 
        {
            RCountryOut rOut = new RCountryOut() {Name = country.Name,Population = (int)country.Population, Surface =  country.Surface, ContinentId = country.Continent.Id.ToString() };
            rOut.CountryId = country.Id.ToString();
            return rOut;
        }
    }
}
