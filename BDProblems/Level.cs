using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDProblems
{
    public partial class Level
    {
        public Level()
        {
            Problem = new HashSet<Problem>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "It's empty!")]
        [Display(Name = "Level Name")]
        public string Name { get; set; }

        public virtual ICollection<Problem> Problem { get; set; }
    }
}
