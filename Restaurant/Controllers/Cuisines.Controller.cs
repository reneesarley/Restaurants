using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DiningTracker.Controllers
{
    public class CuisinesController : Controller
    {
        [HttpGet("cuisines/addNew")]
        public ActionResult AddNew()
        {
            return View();
        }
    }
}
 