using DomainLayer.BaseClasses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainLayerTests
{
    [TestClass]
    public class ContinentTests
    {
        [TestMethod]
        public void ContinentNameNullThrowsException()
        {
            Continent continent;
            Action act = () => continent = new Continent(null);
            act.Should().Throw<ArgumentException>().WithMessage("Name can't be null or empty.");
        }
        [TestMethod]
        public void ContinentNameThrowsNoException()
        {
            Action act = () => new Continent("Azië");
            act.Should().NotThrow();
        }
        [TestMethod]
        public void ContinentAddCountryAlreadyInTest()
        {
            Continent continent = new Continent("Azië");
            continent.AddCountry("vietnam", 95540000, 331.212f);
            Action act = () => continent.AddCountry("vietnam", 95540000, 331.212f);
            act.Should().Throw<ArgumentException>().WithMessage("country already added.");
        }

        [TestMethod]
        public void ContinentAddCountryCheckPopulationTest()
        {
            Continent continent = new Continent("Azië");
            continent.AddCountry("vietnam", 95540000, 331.212f);
            continent.Population.Should().Be(95540000);
        }
        [TestMethod]
        public void ContinentAddCountryTest()
        {
            Continent continent = new Continent("Azië");
            continent.AddCountry("vietnam", 95540000, 331.212f);
            continent.Population.Should().Be(95540000);
            continent.Countries.Count.Should().Be(1);
        }
        [TestMethod]
        public void ContinentDeleteCountryNullThrowsExceptionTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            continent.AddCountry(country.Name, country.Population, country.Surface);
            Action act = () => continent.DeleteCountry(null);
            act.Should().Throw<ArgumentException>().WithMessage("country can't be null");
        }
        [TestMethod]
        public void ContinentDeleteCountryAlreadyRemovedThrowsExceptionTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            continent.AddCountry(country.Name, country.Population, country.Surface);
            continent.DeleteCountry(country);
            Action act = () => continent.DeleteCountry(country);
            act.Should().Throw<ArgumentException>().WithMessage("country is not in Azië");
        }
        [TestMethod]
        public void ContinentDeleteCountryTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            continent.AddCountry(country.Name, country.Population, country.Surface);
            Action act = () => continent.DeleteCountry(country);
            act.Should().NotThrow();
        }
    }
}
