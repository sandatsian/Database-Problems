using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BDProblems
{
    public partial class Theme
    {
        public Theme()
        {
            ProblemTheme = new HashSet<ProblemTheme>();
        }

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "It's empty!")]
        [Display(Name = "Theme Name")]
        public string ThemeName { get; set; }

        public virtual ICollection<ProblemTheme> ProblemTheme { get; set; }
    }
}
