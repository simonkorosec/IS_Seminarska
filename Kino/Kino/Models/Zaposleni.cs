using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Zaposleni
    {
        public int IdZaposleni { get; set; }
        public int IdNaslov { get; set; }
        public int IdPozicije { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRojstva { get; set; }
        public double UrnaPostavka { get; set; }
    }
}
