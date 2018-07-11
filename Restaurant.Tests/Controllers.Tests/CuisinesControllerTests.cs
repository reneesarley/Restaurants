using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiningTracker.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DiningTracker.Tests
{
    [TestClass]
    public class CuisinesControllerTests
    {
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

    }
}
