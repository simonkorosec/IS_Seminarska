using System;
using System.Collections.Generic;

namespace Kino.Models
{
    public partial class Film
    {
        public decimal IdFilm { get; set; }
        public decimal IdZalozba { get; set; }
        public decimal IdOmejitve { get; set; }
        public decimal IdOsebjeFilma { get; set; }
        public string Naslov { get; set; }
        public DateTime? Leto { get; set; }
        public DateTime? CasTrajanja { get; set; }
    }
}
