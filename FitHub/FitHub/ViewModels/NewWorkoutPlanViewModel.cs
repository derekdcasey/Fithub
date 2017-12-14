using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitHub.Models;

namespace FitHub.ViewModels
{
    public class NewWorkoutPlanViewModel
    {
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<WorkoutPlan> WorkoutPlans { get; set; }
        public IEnumerable<Workout> Workouts { get; set; }
        public Workout Workout { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }


    }
}