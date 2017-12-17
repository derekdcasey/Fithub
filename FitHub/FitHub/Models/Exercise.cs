using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitHub.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required][MaxLength(50)]
        public string Name { get; set; }
        [Required][MaxLength(500)]
        public string Description { get; set; }
        public string MuscleGroup { get; set; }
        [Required]
        [Display(Name = "Muscle Group")]
        public int MuscleGroupId { get; set; }
        [Display(Name = "Upload File")][MaxLength(255)]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}