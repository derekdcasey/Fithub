using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitHub.Models;
using FitHub.ViewModels;
using System.Data.Entity.Infrastructure;
using System.IO;

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
            var exercise = _ctx.Exercises.SingleOrDefault(c => c.Id == id);

            if (exercise == null)
                return HttpNotFound();

            return View(exercise);

        }

        //GET Exercises/New
        public ActionResult New()
        {

            var viewModel = new ExerciseFormViewModel()
            {
                //gives a value cannot be empty error
              //  MuscleGroups = _ctx.MuscleGroups.ToList()
            };
            return View("ExerciseForm", viewModel);
        }

        //POST : Exercises/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Exercise exercise)
        {
            //Server side validation - start
            if (!ModelState.IsValid)
            {
                var viewModel = new ExerciseFormViewModel()
                {
                    Exercise = exercise,
                    MuscleGroups = _ctx.MuscleGroups.ToList(),
                };

                return View("ExerciseForm", viewModel);
            }
            //**********Server side validation - end *********
            if (exercise.Id == 0)
            {
                string imagePath = Path.GetFileNameWithoutExtension(exercise.ImageFile.FileName);
                string extension = Path.GetExtension(exercise.ImageFile.FileName);
                imagePath = imagePath + DateTime.Now.ToString("yymmssfff") + extension;
                exercise.ImagePath = "~/ImageUploads/" + imagePath;
                imagePath = Path.Combine(Server.MapPath("~/ImageUploads/"), imagePath);
                exercise.ImageFile.SaveAs(imagePath);
                _ctx.Exercises.Add(exercise);
            }
            else
            {
                var exerciseInDB = _ctx.Exercises.Single(c => c.Id == exercise.Id);

                exerciseInDB.Name = exercise.Name;
                exerciseInDB.Description = exercise.Description;
                exerciseInDB.MuscleGroupId = exercise.MuscleGroupId;
                exerciseInDB.ImagePath = exercise.ImagePath;
                
            }

            _ctx.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "Exercises");
        }


        //GET : Exercises/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            var exerciseInDB = _ctx.Exercises.SingleOrDefault(c => c.Id == id);

            if (exerciseInDB == null)
                return HttpNotFound();

            var viewModel = new ExerciseFormViewModel()
            {
                Exercise = exerciseInDB,
                MuscleGroups = _ctx.MuscleGroups.ToList()
            };

            return View("ExerciseForm", viewModel);
        }

        //GET : Exercises/Delete/1
        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id.HasValue)
            {
                var exercise = _ctx.Exercises.Find(id);

                if (exercise == null)
                    return HttpNotFound();

                if (saveChangesError.GetValueOrDefault())
                {
                    ViewBag.ErrorMessage = "Delete Failed. Please try again or contact adminstrator";
                }

                return View(exercise);
            }
            return HttpNotFound();
        }

        //POST= : Exercises/Delete/1
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                var exercise = _ctx.Exercises.Find(id);
                if (exercise == null)
                    return View("Error");//new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                _ctx.Exercises.Remove(exercise);
                _ctx.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
    }
}