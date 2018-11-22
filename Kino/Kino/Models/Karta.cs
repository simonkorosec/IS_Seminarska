using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Karta
    {
        public decimal IdSedeza { get; set; }
        public decimal IdFilm { get; set; }
        public decimal IdDvorane { get; set; }
        public DateTime CasZacetka { get; set; }
        public DateTime CasKonca { get; set; }
        public DateTime Datum { get; set; }
        public double? Cena { get; set; }
    }
}
