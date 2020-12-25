using DomainLayer.BaseClasses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayerTests
{
    [TestClass]
    public class CountryTests
    {
        [TestMethod]
        public void CountryNameNullThrowsException()
        {
            Continent continent = new Continent("Azië");
            Action act = () => new Country(null, 95540000, 331.212f, continent);
            act.Should().Throw<ArgumentException>().WithMessage("Name can't be null or empty.");
        }
        [TestMethod]
        public void CountrySurfaceNegativeThrowsException()
        {
            Continent continent = new Continent("Azië");
            Action act = () => new Country("vietnam", 95540000, -331.212f, continent);
            act.Should().Throw<ArgumentException>().WithMessage("Surface can't be negative.");
        }
        [TestMethod]
        public void CountryContinentNullThrowsException()
        {
            Action act = () => new Country("vietnam", 95540000, 331.212f, null);
            act.Should().Throw<ArgumentException>().WithMessage("continent can't be null.");
        }
        [TestMethod]
        public void CountryAddCityAlreadyAddedThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            country.AddCity("Hanoi", 7520700);
            Action act = () => country.AddCity("Hanoi", 7520700);
            act.Should().Throw<ArgumentException>().WithMessage("Hanoi already added.");
        }
        [TestMethod]
        public void CountryAddCityPopulationExceedsCountryPopulationThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            Action act = () => country.AddCity("Hanoi", 95540001);
            act.Should().Throw<Exception>().WithMessage("population: 95540001 would exceed country's population: 95540000.");
        }
        [TestMethod]
        public void CountryAddCityNormalTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            Action act = () => country.AddCity("Hanoi", 7520700);
            act.Should().NotThrow();
            country.Cities.Count.Should().Be(1);
        }
        [TestMethod]
        public void CountryRemoveCityNullThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            country.AddCity("Hanoi", 7520700);
            Action act = () => country.RemoveCity(null);
            act.Should().Throw<ArgumentException>().WithMessage("city can't be null");
        }
        [TestMethod]
        public void CountryRemoveCityAlreadyRemovedThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            Action act = () => country.RemoveCity(city);
            act.Should().Throw<ArgumentException>().WithMessage("city is not in vietnam.");
        }
        [TestMethod]
        public void CountryRemoveCityThatIsCapitalThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            country.AddCaptial(city.Name, city.Population);
            Action act = () => country.RemoveCity(city);
            act.Should().Throw<ArgumentException>().WithMessage("city: Hanoi is in capitals. pls remove from capital first.");
        }
        [TestMethod]
        public void CountryRemoveCityNormalTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            country.AddCity(city.Name, city.Population);
            Action act = () => country.RemoveCity(city);
            act.Should().NotThrow();
        }
        [TestMethod]
        public void CountryAddCapitalAlreadyAddedThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            country.AddCaptial(city.Name, city.Population);
            Action act = () => country.AddCaptial(city.Name, city.Population);
            act.Should().Throw<ArgumentException>().WithMessage("capital: Hanoi already added.");
        }
        [TestMethod]
        public void CountryAddCapitalNormalTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            Action act = () => country.AddCaptial(city.Name, city.Population);
            act.Should().NotThrow();
            country.Capitals.Count.Should().Be(1);
        }
        [TestMethod]
        public void CountryRemoveCapitalNullThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            country.AddCaptial(city.Name, city.Population);
            Action act = () => country.RemoveCapital(null);
            act.Should().Throw<ArgumentException>().WithMessage("city can't be null");
        }
        [TestMethod]
        public void CountryRemoveCapitalAlreadyRemovedThrowsException()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            country.AddCaptial(city.Name, city.Population);
            country.RemoveCapital(city);
            Action act = () => country.RemoveCapital(city);
            act.Should().Throw<ArgumentException>().WithMessage("capital: Hanoi is not in vietnam.");
        }
        [TestMethod]
        public void CountryRemoveCapitalNormalTest()
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            City city = new City("Hanoi", 7520700, country);
            country.AddCaptial(city.Name, city.Population);
            Action act = () => country.RemoveCapital(city);
            act.Should().NotThrow();
            country.Capitals.Count.Should().Be(0);
        }

    }
}
