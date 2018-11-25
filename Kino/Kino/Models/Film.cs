using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Kino.Models
{
    public partial class Film
    {
        public int IdFilm { get; set; }
        public int IdZalozba { get; set; }
        public int IdOmejitve { get; set; }
        
        [DisplayName("Režiser")]
        public int IdOsebjeFilma { get; set; }

        public string Naslov { get; set; }
        public int? Leto { get; set; }
        public int? CasTrajanja { get; set; }
    }
}
