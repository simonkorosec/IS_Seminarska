using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class OsebjeFilma
    {
        public decimal IdOsebjeFilma { get; set; }
        public string Ime { get; set; }
        public DateTime? DatumRojstva { get; set; }
    }
}
