using System.Collections.Generic;

namespace Kino.Models.Wraper {
    public class KolosejWrapper {
        public Dvorana Dvorana { get; set; }
        public Film Film { get; set; }
        public IgraV IgraV { get; set; }
        public Karta Karta { get; set; }
        public Kolosej Kolosej { get; set; }
        public Naslov Naslov { get; set; }
        public OsebjeFilma OsebjeFilma { get; set; }
        public Poste Poste { get; set; }
        public Pozicija Pozicija { get; set; }
        public Predstava Predstava { get; set; }
        public Pripada Pripada { get; set; }
        public ProdukcijskaZalozba ProdukcijskaZalozba { get; set; }
        public Sedez Sedez { get; set; }
        public StarostnaOmejitev StarostnaOmejitev { get; set; }
        public Tehnologija Tehnologija { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Zvrst Zvrst { get; set; }

        public IEnumerable<Tehnologija> TehnologijaList { get; set; }
    }
}