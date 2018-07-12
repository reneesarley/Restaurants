using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiningTracker.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DiningTracker.Models;

namespace DiningTracker.Tests
{
    [TestClass]
    public class RestaurantsControllerTests
    {
       
        [TestMethod]
        public void AddNew_ReturnsCorrectView_True()
        {
            //Arrange
            RestaurantsController controller = new RestaurantsController();
            //Act
            ActionResult addNewView = controller.AddNew();
            //Assert
            Assert.IsInstanceOfType(addNewView, typeof(ViewResult));
        }
    }

}