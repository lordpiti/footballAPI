using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Languages
    {
        public Languages()
        {
            Countries = new HashSet<Countries>();
        }

        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}
