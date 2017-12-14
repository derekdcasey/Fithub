using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitHub.Models;
using System.Data.Entity;
using FitHub.ViewModels;

namespace FitHub.Controllers
{
    public class WorkoutsController : Controller
    {

        public WorkoutsController()
        {
            _context = new ApplicationDbContext();
        }
        private ApplicationDbContext _context;
        // GET: Workouts
        public ActionResult Index()
        {
            var workouts = _context.WorkoutPlans.ToList();
            return View(workouts);
        }
        public ActionResult Details(int id)
        {
           var workouts = _context.Workouts.Where(t => t.WorkoutPlanId ==  id).Include(m=>m.Exercise).ToList();
            var workoutPlan = _context.WorkoutPlans.SingleOrDefault(m => m.Id == id);

            if (workoutPlan == null)
                return HttpNotFound();

            var viewModel = new NewWorkoutPlanViewModel
            {
                Workouts = workouts,
                WorkoutPlan = workoutPlan
            };
            return View(viewModel);

        }

        public ActionResult NewPlan()
        {
            var workoutPlan = _context.WorkoutPlans.SingleOrDefault();

            var viewModel = new NewWorkoutPlanViewModel
            {
                WorkoutPlan = workoutPlan
            };
            return View(viewModel);
        }

        public ActionResult NewWorkout()
        {
            var exercises = _context.Exercises.ToList();
            var workoutPlans = _context.WorkoutPlans.ToList();

            var viewModel = new NewWorkoutPlanViewModel
            {
                Exercises = exercises,
                WorkoutPlans = workoutPlans
            };
            return View(viewModel);
        }
         
        [HttpPost]
        public ActionResult CreatePlan(WorkoutPlan workoutPlan)
        {
            _context.WorkoutPlans.Add(workoutPlan);
            _context.SaveChanges();

            
            
            return RedirectToAction("NewWorkout", "Workouts");
        }
        [HttpPost]
        public ActionResult CreateWorkout(Workout workout)
        {
           
            
            _context.Workouts.Add(workout);

            _context.SaveChanges();

            return RedirectToAction("NewWorkout", "Workouts");
        }

    }
}