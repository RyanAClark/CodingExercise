using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardonCodingExercise.Models
{
    public class Qualification
    {
        public int QualificationID { get; set; }
        public int CandidateID { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string QualificationName { get; set; }

        [Required]
        [Display(Name = "Date Started")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStarted { get; set; }

        [Required]
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCompleted { get; set; }


        public virtual Candidate Candidate { get; set; }
    }
}