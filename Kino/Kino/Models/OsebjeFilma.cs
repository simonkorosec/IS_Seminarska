using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class OsebjeFilma
    {
        public int IdOsebjeFilma { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRojstva { get; set; }
    }
}
