using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Karta
    {
        public int IdSedeza { get; set; }
        public int IdFilm { get; set; }
        public int IdDvorane { get; set; }
        public TimeSpan CasZacetka { get; set; }
        public TimeSpan CasKonca { get; set; }
        public DateTime Datum { get; set; }
        public double Cena { get; set; }
        public string Username { get; set; }
    }
}
