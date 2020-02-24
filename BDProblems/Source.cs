using System;
using System.Collections.Generic;

namespace BDProblems
{
    public partial class Source
    {
        public Source()
        {
            Problem = new HashSet<Problem>();
        }

        public int Id { get; set; }
        public string SourceName { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Problem> Problem { get; set; }
    }
}
