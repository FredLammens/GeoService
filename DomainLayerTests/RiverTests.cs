using DomainLayer.BaseClasses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayerTests
{
    [TestClass]
    public class RiverTests
    {
        [TestMethod]
        public void RiverNameNullThrowsException() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            Action act = () => new River(null, 4.350, country);
            act.Should().Throw<ArgumentException>().WithMessage("Name can't be null or empty.");
        }
        [TestMethod]
        public void RiverLengthNegativeThrowsException() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            Action act = () => new River("Mekong", -4.350, country);
            act.Should().Throw<ArgumentException>().WithMessage("Length can't be negative.");
        }
        [TestMethod]
        public void RiverAddCountryAlreadyAddedThrowsException() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            River river = new River("Mekong", 4.350, country);
            Action act = () => river.AddCountry(country);
            act.Should().Throw<ArgumentException>().WithMessage("Country already added.");
        }
        [TestMethod]
        public void RiveAddCountryNormal() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            Country country2 = new Country("japan", 126500000, 377930f ,continent);
            River river = new River("Mekong", 4.350, country);
            Action act = () => river.AddCountry(country2);
            act.Should().NotThrow();
            country.Rivers.Count.Should().Be(1);
            country2.Rivers.Count.Should().Be(1);
        }
        [TestMethod]
        public void RiverDeleteCountryOnly1CountryThrowsException() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            River river = new River("Mekong", 4.350, country);
            Action act = () => river.DeleteCountry(country);
            act.Should().Throw<ArgumentException>().WithMessage("Mekong needs to be in at least 1 country.");
        }
        [TestMethod]
        public void RiverDeleteCountryAlreadyRemovedThrowsException() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            Country country2 = new Country("japan", 126500000, 377930f, continent);
            Country country3 = new Country("thailand", 69430000, 513120f, continent);
            River river = new River("Mekong", 4.350, country);
            river.AddCountry(country2);
            Action act = () => river.DeleteCountry(country3);
            act.Should().Throw<Exception>().WithMessage("country: thailand was already removed.");
        }
        [TestMethod]
        public void RiveDeleteCountryNormal() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331212f, continent);
            Country country2 = new Country("japan", 126500000, 377930f, continent);
            Country country3 = new Country("thailand", 69430000, 513120f, continent);
            River river = new River("Mekong", 4.350, country);
            river.AddCountry(country2);
            river.AddCountry(country3);
            Action act = () => river.DeleteCountry(country3);
            act.Should().NotThrow();
        }
    }
}
