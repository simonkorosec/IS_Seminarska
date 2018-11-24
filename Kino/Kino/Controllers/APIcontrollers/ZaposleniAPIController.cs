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
    public class ZaposleniAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public ZaposleniAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ZaposleniAPI
        [HttpGet]
        public IEnumerable<Zaposleni> GetZaposleni()
        {
            return _context.Zaposleni;
        }

        // GET: api/ZaposleniAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZaposleni([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zaposleni = await _context.Zaposleni.FindAsync(id);

            if (zaposleni == null)
            {
                return NotFound();
            }

            return Ok(zaposleni);
        }

        // PUT: api/ZaposleniAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZaposleni([FromRoute] decimal id, [FromBody] Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposleni.IdZaposleni)
            {
                return BadRequest();
            }

            _context.Entry(zaposleni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposleniExists(id))
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

        // POST: api/ZaposleniAPI
        [HttpPost]
        public async Task<IActionResult> PostZaposleni([FromBody] Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Zaposleni.Add(zaposleni);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZaposleni", new { id = zaposleni.IdZaposleni }, zaposleni);
        }

        // DELETE: api/ZaposleniAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZaposleni([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zaposleni = await _context.Zaposleni.FindAsync(id);
            if (zaposleni == null)
            {
                return NotFound();
            }

            _context.Zaposleni.Remove(zaposleni);
            await _context.SaveChangesAsync();

            return Ok(zaposleni);
        }

        private bool ZaposleniExists(decimal id)
        {
            return _context.Zaposleni.Any(e => e.IdZaposleni == id);
        }
    }
}