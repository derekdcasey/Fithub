using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitHub.Models;

namespace FitHub.Controllers
{
    public class WorkoutPlansController : Controller
    {
        // GET: WorkoutPlans
        public ActionResult Index()
        {
            return View();
        }
    }
}