using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitHub.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public Exercise Exercise { get; set; }
        [Required][Display(Name = "Exercise")]
        public int ExerciseId { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required][Display(Name = "Rest Time(seconds)")]
        public int RestInSeconds { get; set; }
        [Display(Name = "Superset")]
        public bool IsSuperSet { get; set; }
        public string Note { get; set; }
        public int WorkoutPlanId { get; set; }

        public int DayNumber { get; set; }
    }
}