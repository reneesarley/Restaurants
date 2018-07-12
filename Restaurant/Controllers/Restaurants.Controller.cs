using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiningTracker.Models;
using Microsoft.AspNetCore.Mvc;


namespace DiningTracker.Controllers
{
    public class RestaurantsController : Controller
    {
        [HttpGet("restaurants/addNew")]
    public ActionResult AddNew()
    {

            return View(Cuisine.GetAll());
    }

        [HttpPost("/saveRestaurant")]
        public ActionResult AllRestaurants(string restaurantName, int cuisineId, bool allowsDogs, bool servesAlcohol)
        {
            Restaurant newRestaurant = new Restaurant(restaurantName, cuisineId, allowsDogs, servesAlcohol, "1234 street", "Portland", "OR", 12345);
            newRestaurant.Save();          
            return View(Restaurant.GetAll());
        }

        [HttpGet("restaurants/{cuisineName}/{id}/sortedByCuisine")]
        public ActionResult JustOneCuisine(string cuisineName, int id)
        {
            List<Object> model = new List<object>() { Restaurant.GetOneCuisine(id), cuisineName };

               
            return View("JustOneCuisine", model);
        }
    }
}
