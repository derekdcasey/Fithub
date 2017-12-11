using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitHub.Models;

namespace FitHub.Controllers
{
    public class WorkoutsController : Controller
    {
        // GET: Workouts
        public ActionResult Index()
        {
            return View();
        }
    }
}