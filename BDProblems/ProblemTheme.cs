using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDProblems
{
    public partial class ProblemTheme
    {
        
        public int Id { get; set; }
        [ForeignKey("Problem")]
        public int? ProblemId { get; set; }
        [ForeignKey("Theme")]
        public int? ThemeId { get; set; }

       
        public Problem Problem { get; set; }
        
        public Theme Theme { get; set; }
        
    }
}
