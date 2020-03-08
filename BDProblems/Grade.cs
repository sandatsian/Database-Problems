using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDProblems
{
    public partial class Grade
    {
        public Grade()
        {
            ProblemGrade = new HashSet<ProblemGrade>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "It's empty!")]
        [Display(Name = "Grade Name")]
        public string GradeName { get; set; }

        public virtual ICollection<ProblemGrade> ProblemGrade { get; set; }
    }
}
