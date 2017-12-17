using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitHub.Models;
using FitHub.ViewModels;

namespace FitHub.Controllers
{
    public class ExercisesController : Controller
    {
        ApplicationDbContext _ctx;

        public ExercisesController()
        {
            _ctx = new ApplicationDbContext();
        }

        // GET: Exercises
        public ActionResult Index()
        {
            var exercises = _ctx.Exercises.ToList();

            return View(exercises);
        }

        public ActionResult Details(int id)
        {
            var exercise = _ctx.Exercises.SingleOrDefault(e => e.Id == id);

            if (exercise == null)
                return HttpNotFound();

            return View(exercise);

        }

        //GET Exercises/New
        public ActionResult New()
        {
            var exercise = _ctx.Exercises.SingleOrDefault();

            var viewModel = new ExerciseFormViewModel();
            return View("ExerciseForm", viewModel);
        }
    }
}