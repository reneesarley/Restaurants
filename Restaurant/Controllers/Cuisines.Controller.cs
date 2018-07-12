using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiningTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiningTracker.Controllers
{
    public class CuisinesController : Controller
    {
        [HttpGet("cuisines/create")]
        public ActionResult AddNew()
        {
 
            return View();
        }

        [HttpPost("/create")]
        public ActionResult SaveToDb(string cuisineName)
        {
            Cuisine newCuisine = new Cuisine(cuisineName);
            newCuisine.Save();
            return View(Cuisine.GetAll());
        }

    }
}
 