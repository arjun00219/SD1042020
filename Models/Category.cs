using System;
using System.Collections.Generic;

namespace SHAKILA.Models
{
    public partial class Category
    {
        public byte CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
