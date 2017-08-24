using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Countries
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string LanguageCode { get; set; }

        public virtual Languages LanguageCodeNavigation { get; set; }
    }
}
