using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers.API {
    public class KartaPodatki {
        public int IdSedeza { get; set; }
        public int IdFilm { get; set; }
        public int IdDvorane { get; set; }
        public string CasZacetka { get; set; }
        public string CasKonca { get; set; }
        public string Datum { get; set; }
        public string Cena { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UporabnikApi : ControllerBase {
        private readonly KinoDatabaseContext _context;

        public UporabnikApi(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: api/UporabnikApi/5
        [HttpGet("{id}")]
        public LinkedList<KartaPodatki> GetKarte([FromRoute] string id) {
            var returnKarte = new LinkedList<KartaPodatki>();
            var karte = _context.Karta.Where(e => e.Username == id).ToList();

            foreach (var karta in karte) {
                returnKarte.AddFirst(new KartaPodatki() {
                    IdSedeza = karta.IdSedeza,
                    IdDvorane = karta.IdDvorane,
                    IdFilm = karta.IdFilm,
                    CasZacetka = karta.CasZacetka.ToString(),
                    CasKonca = karta.CasKonca.ToString(),
                    Datum = karta.Datum.ToString(CultureInfo.GetCultureInfo("si-SI")).Split(" ")[0],
                    Cena = karta.Cena.ToString(CultureInfo.GetCultureInfo("en-GB"))
                });
            }

            return returnKarte;
        }


        // PUT: api/UporabnikApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUporabnik([FromRoute] string id, [FromBody] Uporabnik uporabnik) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != uporabnik.Username) {
                return BadRequest();
            }

            _context.Entry(uporabnik).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!UporabnikExists(id)) {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/UporabnikApi
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUporabnik([FromBody] Uporabnik uporabnik) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            uporabnik.Password = Hash(uporabnik.Password);
            _context.Uporabnik.Add(uporabnik);
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (UporabnikExists(uporabnik.Username)) {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
            }

            return Ok();
        }

        // POST: api/UporabnikApi
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUporabnik([FromBody] Uporabnik uporabnik) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = _context.Uporabnik.First(x => x.Username == uporabnik.Username);

            if (user != null && user.Password == Hash(uporabnik.Password)) {
                return Ok();
            }

            return BadRequest();
        }


        // DELETE: api/UporabnikApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUporabnik([FromRoute] string id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var uporabnik = await _context.Uporabnik.FindAsync(id);
            if (uporabnik == null) {
                return NotFound();
            }

            _context.Uporabnik.Remove(uporabnik);
            await _context.SaveChangesAsync();

            return Ok(uporabnik);
        }

        private bool UporabnikExists(string id) {
            return _context.Uporabnik.Any(e => e.Username == id);
        }

        public static string Hash(string value) {
            var sha1 = SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var t in hash) {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}