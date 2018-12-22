using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Kino.Models
{
    public partial class ProdukcijskaZalozba
    {
        public int IdZalozba { get; set; }

        [DisplayName("Produkcijska Založba")]
        public string Ime { get; set; }
    }
}
