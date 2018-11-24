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
    public class NaslovAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public NaslovAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/NaslovAPI
        [HttpGet]
        public IEnumerable<Naslov> GetNaslov()
        {
            return _context.Naslov;
        }

        // GET: api/NaslovAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNaslov([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var naslov = await _context.Naslov.FindAsync(id);

            if (naslov == null)
            {
                return NotFound();
            }

            return Ok(naslov);
        }

        // PUT: api/NaslovAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaslov([FromRoute] decimal id, [FromBody] Naslov naslov)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != naslov.IdNaslov)
            {
                return BadRequest();
            }

            _context.Entry(naslov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaslovExists(id))
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

        // POST: api/NaslovAPI
        [HttpPost]
        public async Task<IActionResult> PostNaslov([FromBody] Naslov naslov)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Naslov.Add(naslov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaslov", new { id = naslov.IdNaslov }, naslov);
        }

        // DELETE: api/NaslovAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaslov([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var naslov = await _context.Naslov.FindAsync(id);
            if (naslov == null)
            {
                return NotFound();
            }

            _context.Naslov.Remove(naslov);
            await _context.SaveChangesAsync();

            return Ok(naslov);
        }

        private bool NaslovExists(decimal id)
        {
            return _context.Naslov.Any(e => e.IdNaslov == id);
        }
    }
}