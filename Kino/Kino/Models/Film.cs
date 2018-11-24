using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Film
    {
        public int IdFilm { get; set; }
        public int IdZalozba { get; set; }
        public int IdOmejitve { get; set; }
        public int IdOsebjeFilma { get; set; }
        public string Naslov { get; set; }
        public DateTime? Leto { get; set; }
        public DateTime? CasTrajanja { get; set; }
    }
}
