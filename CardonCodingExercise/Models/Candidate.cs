using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CardonCodingExercise.Models
{
    public class Candidate
    {
      

        public int ID {get; set;}

        [Display(Name = "First Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$")]
        public string LastName { get; set; }

        
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }



        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"(\([2-9]\d\d\)|[2-9]\d\d) ?[-.,]? ?[2-9]\d\d ?[-.,]? ?\d{4}$",ErrorMessage="Enter a 10 digit phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(5,MinimumLength=5, ErrorMessage="Enter a 5 digit number")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage="Must contain numbers only")]
        public string ZipCode { get; set; }

        // list of qualifications
        public  virtual ICollection<Qualification> Qualifications { get; set; }


    }
    public class CandidateDBContext : DbContext
    {
        public CandidateDBContext(): base("CandidateDBContext")
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }



    }


}