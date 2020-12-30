using DomainLayer.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class Mapper
    {
        #region  from Database to Domain
        #region River TODO
        public static River FromDRiverToRiver(DRiver river)
        {
            //return new River(river.Name, river.Length, river.Countries[0].Country);
            throw new NotImplementedException();
        }
        #endregion
        public static Continent FromDContinentToContinent(DContinent dContinent)
        {
            Continent continent = new Continent(dContinent.Name)
            {
                Id = (uint)dContinent.Id,
            };
            if (dContinent.Countries.Count > 0)
            {
                foreach (DCountry dCountry in dContinent.Countries)
                {
                    Country toAdd = new Country(dCountry.Name, dCountry.Population, dCountry.Surface, continent) { Id = (uint)dCountry.Id };
                    continent.AddCountry(toAdd);
                }
            }
            return continent;
        }
        public static Country FromDCountryToCountry(DCountry dCountry)
        {
            Country country = new Country(dCountry.Name, dCountry.Population, dCountry.Surface, FromDContinentToContinent(dCountry.Continent)) { Id = (uint)dCountry.Id };
            // Todo: Check if city isnt in capital catch?
            if (dCountry.Capitals != null)
            {
                foreach (DCity dCity in dCountry.Capitals)
                {
                    City toAdd = new City(dCity.Name, dCity.Population, country) { Id = (uint)dCity.Id, CapitalFrom = country };
                    country.AddCaptial(toAdd);
                }
            }
            if (dCountry.Cities != null)
            {
                foreach (DCity dCity in dCountry.Cities)
                {
                    City toAdd = new City(dCity.Name, dCity.Population, country) { Id = (uint)dCity.Id };
                    country.AddCity(toAdd);
                }
            }
            return country;
        }
        public static City FromDCityToCity(DCity dCity)
        {
            City city = new City(dCity.Name, dCity.Population, FromDCountryToCountry(dCity.BelongsTo)) { Id = (uint)dCity.Id };
            if (dCity.CapitalFrom != null)
                city.CapitalFrom = FromDCountryToCountry(dCity.CapitalFrom);
            return city;
        }
        #endregion
        #region from Domain to Database
        #region River TODO
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
        #endregion
        public static DContinent FromContinentToDContinent(Continent continent)
        {
            DContinent dContinent = new DContinent
            {
                Name = continent.Name,
                Population = continent.Population
            };
            dContinent.Id = (int)continent.Id;
            return dContinent;
        }
        public static DCountry FromCountryToDCountry(Country country)
        {
            DCountry dataCountry = new DCountry
            {
                Name = country.Name,
                Population = country.Population,
                Surface = country.Surface,
                Continent = FromContinentToDContinent(country.Continent)
            };
            dataCountry.Id = (int)country.Id;
            return dataCountry;
        }
        public static DCity FromCityToDCity(City city)
        {
            DCity dCity = new DCity
            {
                Name = city.Name,
                Population = city.Population,
                BelongsTo = FromCountryToDCountry(city.BelongsTo)
            };
            if (city.CapitalFrom != null)
                dCity.CapitalFrom = FromCountryToDCountry(city.CapitalFrom);
            return dCity;
        }
        #endregion
    }
}
