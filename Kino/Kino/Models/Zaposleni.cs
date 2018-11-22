using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Zaposleni
    {
        public decimal IdZaposleni { get; set; }
        public decimal IdNaslov { get; set; }
        public decimal IdPozicije { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRojstva { get; set; }
        public double? UrnaPostavka { get; set; }
    }
}
