using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitHub.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkoutPlanId { get; set; }
    }
}