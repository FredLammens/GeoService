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
        }
        [TestMethod]
        public void CountryContinentNullThrowsException()
        {
        }
        [TestMethod]
        public void CountryAddRiverNullThrowsException()
        {
        }
        [TestMethod]
        public void CountryAddRiverAlreadyAddedThrowsException()
        {
        }
        [TestMethod]
        public void CountryAddRiverNormalTest()
        {
        }
        [TestMethod]
        public void CountryRemoveRiverNullThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveRiverAlreadyRemovedThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveRiverNormalTest()
        {
        }
        [TestMethod]
        public void CountryAddCityAlreadyAddedThrowsException()
        {
        }
        [TestMethod]
        public void CountryAddCityPopulationExceedsCountryPopulationThrowsException()
        {

        }
        [TestMethod]
        public void CountryAddCityNormalTest()
        {
        }
        [TestMethod]
        public void CountryRemoveCityNullThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveCityAlreadyRemovedThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveCityThatIsCapitalThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveCityNormalTest()
        {
        }
        [TestMethod]
        public void CountryAddCapitalAlreadyAddedThrowsException()
        {
        }
        [TestMethod]
        public void CountryAddCapitalNormalTest()
        {
        }
        [TestMethod]
        public void CountryRemoveCapitalNullThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveCapitalAlreadyRemovedThrowsException()
        {
        }
        [TestMethod]
        public void CountryRemoveCapitalNormalTest()
        {
        }
    }
}
