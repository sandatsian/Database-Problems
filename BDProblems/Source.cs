using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDProblems
{
    public partial class Source
    {
        public Source()
        {
            Problem = new HashSet<Problem>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "It's empty!")]
        [Display(Name = "Source's Name")]
        public string SourceName { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Problem> Problem { get; set; }
    }
}
