using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDProblems
{
    public partial class ProblemGrade
    {
        public int Id { get; set; }
        [ForeignKey("Problem")]
        public int? ProblemId { get; set; }
        [ForeignKey("Grade")]
        public int? GradeId { get; set; }

        
        public virtual Grade Grade { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
