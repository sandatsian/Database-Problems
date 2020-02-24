using System;
using System.Collections.Generic;

namespace BDProblems
{
    public partial class Grade
    {
        public Grade()
        {
            ProblemGrade = new HashSet<ProblemGrade>();
        }

        public int Id { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<ProblemGrade> ProblemGrade { get; set; }
    }
}
