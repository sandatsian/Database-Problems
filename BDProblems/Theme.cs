using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDProblems
{
    public partial class Theme
    {
        public Theme()
        {
            ProblemTheme = new HashSet<ProblemTheme>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва теми")]
        public string ThemeName { get; set; }

        public virtual ICollection<ProblemTheme> ProblemTheme { get; set; }
    }
}
