using System;
using System.Collections.Generic;

namespace SHAKILA.Models
{
    public partial class Countrylanguage
    {
        public string CountryCode { get; set; }
        public string Language { get; set; }
        public string IsOfficial { get; set; }
        public decimal Percentage { get; set; }
    }
}
