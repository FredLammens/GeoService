using DomainLayer.BaseClasses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayerTests
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void CityNameNullThrowsException() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f,continent);
            Action act = () => new City(null, 200, country);
            act.Should().Throw<ArgumentException>().WithMessage("Name can't be null or empty.");
        }
        [TestMethod]
        public void CityCountryNullThrowsException()
        {
            Action act = () => new City("Hanoi", 7520700, null);
            act.Should().Throw<ArgumentException>().WithMessage("City needs to belong to country.");
        }
        [TestMethod]
        public void CityNormal() 
        {
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            Action act = () => new City("Hanoi", 7520700, country);
            act.Should().NotThrow();
        }
    }
}
