using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Predstava
    {
        public int IdFilm { get; set; }
        public int IdDvorane { get; set; }
        public TimeSpan CasZacetka { get; set; }
        public TimeSpan CasKonca { get; set; }
        public DateTime Datum { get; set; }
    }
}
