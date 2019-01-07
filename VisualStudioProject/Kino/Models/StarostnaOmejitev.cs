using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Kino.Models
{
    public partial class StarostnaOmejitev
    {
        public int IdOmejitve { get; set; }
        [DisplayName("Starostna Omejitev")]
        public string Ime { get; set; }
    }
}
