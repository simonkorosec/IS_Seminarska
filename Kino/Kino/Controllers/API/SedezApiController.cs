using System.Collections.Generic;
using System.Linq;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Controllers.API {
    [Route("api/[controller]")]
    [ApiController]
    public class SedezApiController : ControllerBase {
        private readonly KinoDatabaseContext _context;

        public SedezApiController(KinoDatabaseContext context) {
            _context = context;
        }

        // POST: api/SedezApi
        [HttpPost]
        public LinkedList<Sedez> PostSedez([FromBody] Predstava predstava) {
            var sedezi = new LinkedList<Sedez>();

            var all_sedezi = _context.Sedez.Where(x => x.IdDvorane == predstava.IdDvorane);
            var karte = _context.Karta.Where(x => x.IdDvorane == predstava.IdDvorane &&
                                                  x.IdFilm == predstava.IdFilm &&
                                                  x.CasKonca == predstava.CasKonca &&
                                                  x.CasZacetka == predstava.CasZacetka &&
                                                  x.Datum == predstava.Datum);


            var zasedeni = (from karta in karte select karta.IdSedeza).ToHashSet();

            foreach (var sedez in all_sedezi) {
                if (zasedeni.All(x => x != sedez.IdSedeza)) {
                    sedezi.AddLast(sedez);
                }
            }

            return sedezi;
        }
    }
}