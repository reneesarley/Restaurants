using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiningTracker.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DiningTracker.Models;

namespace DiningTracker.Tests
{
    [TestClass]
    public class CuisinesControllerTests //: IDisposable
    {

        //public void Dispose()
        //{
        //    Cuisine.DeleteAll();
        //}

        //public CuisinesControllerTest()
        //{
        //    DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=diningTracker_test;";
        //}

        [TestMethod]
        public void AddNew_ReturnsCorrectView_True()
        {
            //Arrange
            CuisinesController controller = new CuisinesController();

            //Act
            ActionResult addNewView = controller.AddNew();

            //Assert
            Assert.IsInstanceOfType(addNewView, typeof(ViewResult));
        }

        [TestMethod]
        public void SaveToDb_ReturnsCorrectView_True()
        {
            //Arrange
            CuisinesController controller = new CuisinesController();

            //Act
            ActionResult SaveToDbView = controller.SaveToDb("testName");

            //Assert
            Assert.IsInstanceOfType(SaveToDbView, typeof(ViewResult));
        }

    }
}
