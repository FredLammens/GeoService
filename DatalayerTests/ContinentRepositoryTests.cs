using DataLayer;
using DomainLayer.BaseClasses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DatalayerTests
{
    [TestClass]
    public class ContinentRepositoryTests
    {
        #region Continent
        [TestMethod]
        public void AddAndGetContinentNormalTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            uow.Continents.AddContinent(continent);
            uow.Complete();
            Continent returned = uow.Continents.GetContinent(1);
            returned.Name.Should().Be("Azië");
        }
        [TestMethod]
        public void AddContinentAlreadyInDBTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            uow.Continents.AddContinent(continent);
            uow.Complete();
            Action act = () => uow.Continents.AddContinent(continent);
            act.Should().Throw<Exception>().WithMessage("Continent: Azië already in database.");
        }
        [TestMethod]
        public void DeleteContinentNormalTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            uow.Continents.AddContinent(continent);
            uow.Complete();
            uow.Continents.DeleteContinent(1);
            uow.Complete();
            Action act = () => uow.Continents.GetContinent(1);
            act.Should().Throw<Exception>().WithMessage("Continent with id: 1 not in DB.");
        }
        [TestMethod]
        public void UpdateContinentNormalTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            Continent update = new Continent("Afrika");
            uow.Continents.AddContinent(continent);
            uow.Complete();
            uow.Continents.UpdateContinent(update, 1);
            uow.Complete();
            Continent returned = uow.Continents.GetContinent(1);
            returned.Name.Should().Be("Afrika");
        }
        [TestMethod]
        public void UpdateContinentNotInDBTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent update = new Continent("Afrika");
            Action act = () => uow.Continents.UpdateContinent(update, 1);
            act.Should().Throw<Exception>().WithMessage("Continent with id: 1 not in database.");
        }
        [TestMethod]
        public void IsInContinentsDBTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Afrika");
            bool isIn =  uow.Continents.isInContinents(2);
            isIn.Should().BeFalse();
            uow.Continents.AddContinent(continent);
            uow.Complete();
            bool isNotIn = uow.Continents.isInContinents(1);
            isNotIn.Should().BeTrue();
        }
        #endregion
        #region Country
        [TestMethod]
        public void AddandGetCountryNormalTest() 
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            uow.Continents.AddContinent(continent);
            uow.Complete();
            uow.Continents.AddCountry(1, country);
            uow.Complete();
            Continent returned = uow.Continents.GetContinent(1);
            returned.Name.Should().Be("Azië");
            returned.Countries.Count.Should().Be(1);
            returned.Countries[0].Id.Should().Be(1);
            returned.Countries[0].Name.Should().Be("vietnam");
            returned.Countries[0].Population.Should().Be(95540000);
            returned.Countries[0].Surface.Should().Be(331.212f);
        }
        [TestMethod]
        public void AddCountryContinentNotInDBTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            Action act = () => uow.Continents.AddCountry(1, country);
            act.Should().Throw<Exception>().WithMessage("Continent with id: 1 not in DB.");
        }
        [TestMethod]
        public void GetCountryContinentNotInDBTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Action act = () => uow.Continents.GetCountry(1,3);
            act.Should().Throw<Exception>().WithMessage("Continent with id: 1 not in DB.");
        }
        [TestMethod]
        public void GetCountryCountryNotInDBTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            uow.Continents.AddContinent(continent);
            uow.Complete();
            Action act = () => uow.Continents.GetCountry(1, 3);
            act.Should().Throw<Exception>().WithMessage("Country with id: 3 not in DB.");
        }
        [TestMethod]
        public void DeleteCountryNormalTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent);
            uow.Continents.AddContinent(continent);
            uow.Complete();
            uow.Continents.AddCountry(1, country);
            uow.Complete();
            Action act = () => uow.Continents.DeleteCountry(1, 0);
            act.Should().NotThrow();
            act = () => uow.Continents.GetCountry(1, 1);
            act.Should().Throw<Exception>().WithMessage("Country with id: 1 not in DB.");
        }
        [TestMethod]
        public void DeleteCountryContinentNotInDatabaseTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Action act = () => uow.Continents.DeleteCountry(1, 3);
            act.Should().Throw<Exception>().WithMessage("Continent with id: 1 not in DB.");
        }
        [TestMethod]
        public void DeleteCountryCountryNotInDatabaseTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            uow.Continents.AddContinent(continent);
            uow.Complete();
            Action act = () => uow.Continents.DeleteCountry(1, 3);
            act.Should().Throw<Exception>().WithMessage("Country with id: 3 not in DB.");
        }
        [TestMethod]
        public void UpdateCountryNormalTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent) {Id = 1};
            Country toUpdate = new Country("vietnam", 126500000, 377930f, continent) {Id = 5 };
            uow.Continents.AddContinent(continent);
            uow.Complete();
            uow.Continents.AddCountry(1, country);
            uow.Complete();
            Action act = () => uow.Continents.UpdateCountry(1,1,toUpdate);
            act.Should().NotThrow();
            uow.Complete();
            Country updated = uow.Continents.GetCountry(1, 5);
            uow.Complete();
            updated.Name.Should().Be("vietnam");
            updated.Population.Should().Be(126500000);
            updated.Surface.Should().Be(377930f);
        }
        [TestMethod]
        public void IsInCountryDatabaseNormalTest()
        {
            UnitOfWork uow = new UnitOfWork(new GeoServiceTestContext(false));
            Continent continent = new Continent("Azië");
            Country country = new Country("vietnam", 95540000, 331.212f, continent) { Id = 3 };
            uow.Continents.AddContinent(continent);
            uow.Complete();
            uow.Continents.AddCountry(1, country);
            uow.Complete();
            bool isIn = uow.Continents.isInCountry(1, 3);
            isIn.Should().BeTrue();
            bool isNotIn = uow.Continents.isInCountry(1, 10);
            isNotIn.Should().BeFalse();
        }
        #endregion
    }
}
