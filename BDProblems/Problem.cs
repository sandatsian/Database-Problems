using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDProblems
{
    public partial class Problem
    {
        public Problem()
        {
            ProblemGrade = new HashSet<ProblemGrade>();
            ProblemTheme = new HashSet<ProblemTheme>();
        }
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "It's empty!")]
        [Display(Name = "Solution")]
        public string Solution { get; set; }
        [Required(ErrorMessage = "It's empty!")]
        [Display(Name = "Statement")]
        public string Statement { get; set; }
        public int? LevelId { get; set; }
        public int? SourceId { get; set; }

        public virtual Level Level { get; set; }
        public virtual Source Source { get; set; }
        public ICollection<ProblemGrade> ProblemGrade { get; set; }
        public ICollection<ProblemTheme> ProblemTheme { get; set; }
    }
}
