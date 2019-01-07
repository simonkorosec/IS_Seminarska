using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Dvorana
    {
        public int IdDvorane { get; set; }
        public int IdKolosej { get; set; }
        public int IdTehnologije { get; set; }
        public string Ime { get; set; }
        public int StVrst { get; set; }
        public int StSedezovNaVrsto { get; set; }
    }
}
