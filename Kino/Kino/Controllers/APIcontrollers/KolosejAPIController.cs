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
    public class KolosejAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public KolosejAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/KolosejAPI
        [HttpGet]
        public IEnumerable<Kolosej> GetKolosej()
        {
            return _context.Kolosej;
        }

        // GET: api/KolosejAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKolosej([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kolosej = await _context.Kolosej.FindAsync(id);

            if (kolosej == null)
            {
                return NotFound();
            }

            return Ok(kolosej);
        }

        // PUT: api/KolosejAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKolosej([FromRoute] decimal id, [FromBody] Kolosej kolosej)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kolosej.IdKolosej)
            {
                return BadRequest();
            }

            _context.Entry(kolosej).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KolosejExists(id))
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

        // POST: api/KolosejAPI
        [HttpPost]
        public async Task<IActionResult> PostKolosej([FromBody] Kolosej kolosej)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kolosej.Add(kolosej);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKolosej", new { id = kolosej.IdKolosej }, kolosej);
        }

        // DELETE: api/KolosejAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKolosej([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kolosej = await _context.Kolosej.FindAsync(id);
            if (kolosej == null)
            {
                return NotFound();
            }

            _context.Kolosej.Remove(kolosej);
            await _context.SaveChangesAsync();

            return Ok(kolosej);
        }

        private bool KolosejExists(decimal id)
        {
            return _context.Kolosej.Any(e => e.IdKolosej == id);
        }
    }
}