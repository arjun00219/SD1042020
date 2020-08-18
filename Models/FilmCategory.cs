using System;
using System.Collections.Generic;

namespace SHAKILA.Models
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public byte CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
