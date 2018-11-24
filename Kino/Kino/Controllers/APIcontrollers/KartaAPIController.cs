using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers.APIcontrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KartaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public KartaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/KartaAPI
        [HttpGet]
        public IEnumerable<Karta> GetKarta()
        {
            return _context.Karta;
        }

        // GET: api/KartaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKarta([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var karta = await _context.Karta.FindAsync(id);

            if (karta == null)
            {
                return NotFound();
            }

            return Ok(karta);
        }

        // PUT: api/KartaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKarta([FromRoute] decimal id, [FromBody] Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != karta.IdSedeza)
            {
                return BadRequest();
            }

            _context.Entry(karta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KartaExists(id))
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

        // POST: api/KartaAPI
        [HttpPost]
        public async Task<IActionResult> PostKarta([FromBody] Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Karta.Add(karta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KartaExists(karta.IdSedeza))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKarta", new { id = karta.IdSedeza }, karta);
        }

        // DELETE: api/KartaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKarta([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var karta = await _context.Karta.FindAsync(id);
            if (karta == null)
            {
                return NotFound();
            }

            _context.Karta.Remove(karta);
            await _context.SaveChangesAsync();

            return Ok(karta);
        }

        private bool KartaExists(decimal id)
        {
            return _context.Karta.Any(e => e.IdSedeza == id);
        }
    }
}