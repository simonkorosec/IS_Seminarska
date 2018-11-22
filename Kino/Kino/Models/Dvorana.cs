using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Dvorana
    {
        public decimal IdDvorane { get; set; }
        public decimal IdKolosej { get; set; }
        public decimal IdTehnologije { get; set; }
        public string Ime { get; set; }
        public decimal StVrst { get; set; }
        public decimal StSedezovNaVrsto { get; set; }
    }
}
