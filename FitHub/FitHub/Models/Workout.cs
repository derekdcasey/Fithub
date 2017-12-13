using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitHub.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int RestInSeconds { get; set; }
        public bool IsSuperSet { get; set; }
        public string Note { get; set; }
        public int WorkoutPlanId { get; set; }

        public int DayNumber { get; set; }
    }
}