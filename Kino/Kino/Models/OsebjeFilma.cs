using System;
using System.ComponentModel;

namespace Kino.Models
{
    public partial class OsebjeFilma
    {
        public int IdOsebjeFilma { get; set; }

        [DisplayName("Režiser")]
        public string Ime { get; set; }

        public DateTime DatumRojstva { get; set; }
    }
}
