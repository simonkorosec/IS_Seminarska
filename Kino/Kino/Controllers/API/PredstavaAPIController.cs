using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kino.Models;

namespace Kino.Controllers.API {
    public class PredstavaPodatki {
        public int IdFilm { get; set; }
        public string NaslovFilma { get; set; }
        public int IdDvorane { get; set; }
        public string ImeDvorane { get; set; }
        public string ImeKoloseja { get; set; }
        public string CasZacetka { get; set; }
        public string CasKonca { get; set; }
        public string Datum { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PredstavaAPIController : ControllerBase {
        private readonly KinoDatabaseContext _context;

        public PredstavaAPIController(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: api/PredstavaAPI
        [HttpGet]
        public IEnumerable<PredstavaPodatki> GetPredstava() {
            IEnumerable<Predstava> predstave = _context.Predstava;

            return (from predstava in predstave
                let d = _context.Dvorana.FirstOrDefault(x => x.IdDvorane == predstava.IdDvorane)
                select new PredstavaPodatki {
                    IdFilm =  predstava.IdFilm,
                    NaslovFilma = _context.Film.FirstOrDefault(x => x.IdFilm == predstava.IdFilm)?.Naslov,
                    IdDvorane = d.IdDvorane,
                    ImeDvorane = d?.Ime.Trim(),
                    ImeKoloseja = _context.Kolosej.FirstOrDefault(x => x.IdKolosej == d.IdKolosej)?.Ime,
                    CasZacetka = predstava.CasZacetka.ToString(),
                    CasKonca = predstava.CasKonca.ToString(),
                    Datum = predstava.Datum.ToString(CultureInfo.GetCultureInfo("si-SI")).Split(" ")[0]
                }).ToList();
        }

        private bool PredstavaExists(int id) {
            return _context.Predstava.Any(e => e.IdFilm == id);
        }
    }
}