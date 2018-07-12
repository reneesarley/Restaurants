using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiningTracker.Models;
using System.Collections.Generic;


namespace DiningTracker.Tests
{
    [TestClass]
    public class RestaurantTests : IDisposable
    {
        public void Dispose()
        {
            Restaurant.DeleteAll();
        }

        public RestaurantTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=diningTracker_test;";
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = Restaurant.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_RestaurantList()
        {
            //Arrange
            Restaurant newRestuarant = new Restaurant("testRestuarant", 0, false, false, "12354 street", "portland", "OR", 12345);


            //Act
            newRestuarant.Save();
            List<Restaurant> result = Restaurant.GetAll();
            List<Restaurant> testList = new List<Restaurant> { newRestuarant };

            //Assert
            CollectionAssert.AreEqual(result, testList);
        }
    }
}