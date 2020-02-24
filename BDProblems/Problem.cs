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
        public int Id { get; set; }
        public string Solution { get; set; }
        public string Statement { get; set; }
        public int? LevelId { get; set; }
        public int? SourceId { get; set; }

        public virtual Level Level { get; set; }
        public virtual Source Source { get; set; }
        public virtual ICollection<ProblemGrade> ProblemGrade { get; set; }
        public virtual ICollection<ProblemTheme> ProblemTheme { get; set; }
    }
}
