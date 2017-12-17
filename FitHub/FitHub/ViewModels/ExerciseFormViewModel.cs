using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitHub.Models;

namespace FitHub.ViewModels
{
    public class ExerciseFormViewModel
    {
        public Exercise Exercise { get; set; }


        public string Title
        {
            get
            {
                return Exercise.Id == 0 ? "New Media" : "Edit Media";
            }
        }

        public ExerciseFormViewModel()
        {
            Exercise = new Exercise();
            Exercise.Id = 0;
        }
    }
}