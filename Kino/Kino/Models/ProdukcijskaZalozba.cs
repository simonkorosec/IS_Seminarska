using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Kino.Models
{
    public partial class ProdukcijskaZalozba
    {
        public int IdZalozba { get; set; }
        
        [DisplayName("Produkcijska Zalozba")]
        public string Ime { get; set; }
    }
}
