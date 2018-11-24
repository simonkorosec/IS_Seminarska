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
    public class SedezAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public SedezAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SedezAPI
        [HttpGet]
        public IEnumerable<Sedez> GetSedez()
        {
            return _context.Sedez;
        }

        // GET: api/SedezAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSedez([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sedez = await _context.Sedez.FindAsync(id);

            if (sedez == null)
            {
                return NotFound();
            }

            return Ok(sedez);
        }

        // PUT: api/SedezAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSedez([FromRoute] decimal id, [FromBody] Sedez sedez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sedez.IdSedeza)
            {
                return BadRequest();
            }

            _context.Entry(sedez).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedezExists(id))
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

        // POST: api/SedezAPI
        [HttpPost]
        public async Task<IActionResult> PostSedez([FromBody] Sedez sedez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sedez.Add(sedez);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSedez", new { id = sedez.IdSedeza }, sedez);
        }

        // DELETE: api/SedezAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSedez([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sedez = await _context.Sedez.FindAsync(id);
            if (sedez == null)
            {
                return NotFound();
            }

            _context.Sedez.Remove(sedez);
            await _context.SaveChangesAsync();

            return Ok(sedez);
        }

        private bool SedezExists(decimal id)
        {
            return _context.Sedez.Any(e => e.IdSedeza == id);
        }
    }
}