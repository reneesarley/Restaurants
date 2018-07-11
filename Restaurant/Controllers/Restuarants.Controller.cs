using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiningTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiningTracker.Controllers
{
    public class RestuarantsController : Controller
    {
        [HttpGet("restuarant/addNew")]
        public ActionResult AddNew()
        {

            return View();
        }
    }
}
