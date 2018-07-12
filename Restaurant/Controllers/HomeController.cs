using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiningTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiningTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<object> models = new List<object>() { Cuisine.GetAll(), Restaurant.GetAll(), "All" };
            return View(models);
        }

        [HttpGet("{id}/sortedByCuisine")]
        public IActionResult IndexRestaurantSorted(int id)
        {
            List<object> models = new List<object>() {Cuisine.GetAll(), Restaurant.GetOneCuisine(id), Cuisine.Find(id).GetName()};
            return View("Index", models);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
