using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitHub.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserFavorite { get; set; }
        public List<Workout> Workouts { get; set; }
        public string BgImagePath { get; set; }
    }
}