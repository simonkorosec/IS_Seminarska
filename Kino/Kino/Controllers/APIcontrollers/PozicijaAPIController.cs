using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers.APIcontrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozicijaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public PozicijaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PozicijaAPI
        [HttpGet]
        public IEnumerable<Pozicija> GetPozicija()
        {
            return _context.Pozicija;
        }

        // GET: api/PozicijaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPozicija([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pozicija = await _context.Pozicija.FindAsync(id);

            if (pozicija == null)
            {
                return NotFound();
            }

            return Ok(pozicija);
        }

        // PUT: api/PozicijaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozicija([FromRoute] decimal id, [FromBody] Pozicija pozicija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pozicija.IdPozicije)
            {
                return BadRequest();
            }

            _context.Entry(pozicija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozicijaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PozicijaAPI
        [HttpPost]
        public async Task<IActionResult> PostPozicija([FromBody] Pozicija pozicija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pozicija.Add(pozicija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPozicija", new { id = pozicija.IdPozicije }, pozicija);
        }

        // DELETE: api/PozicijaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePozicija([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pozicija = await _context.Pozicija.FindAsync(id);
            if (pozicija == null)
            {
                return NotFound();
            }

            _context.Pozicija.Remove(pozicija);
            await _context.SaveChangesAsync();

            return Ok(pozicija);
        }

        private bool PozicijaExists(decimal id)
        {
            return _context.Pozicija.Any(e => e.IdPozicije == id);
        }
    }
}