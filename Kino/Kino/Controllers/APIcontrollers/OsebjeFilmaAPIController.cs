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
    public class OsebjeFilmaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public OsebjeFilmaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/OsebjeFilmaAPI
        [HttpGet]
        public IEnumerable<OsebjeFilma> GetOsebjeFilma()
        {
            return _context.OsebjeFilma;
        }

        // GET: api/OsebjeFilmaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOsebjeFilma([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var osebjeFilma = await _context.OsebjeFilma.FindAsync(id);

            if (osebjeFilma == null)
            {
                return NotFound();
            }

            return Ok(osebjeFilma);
        }

        // PUT: api/OsebjeFilmaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsebjeFilma([FromRoute] decimal id, [FromBody] OsebjeFilma osebjeFilma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != osebjeFilma.IdOsebjeFilma)
            {
                return BadRequest();
            }

            _context.Entry(osebjeFilma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsebjeFilmaExists(id))
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

        // POST: api/OsebjeFilmaAPI
        [HttpPost]
        public async Task<IActionResult> PostOsebjeFilma([FromBody] OsebjeFilma osebjeFilma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OsebjeFilma.Add(osebjeFilma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOsebjeFilma", new { id = osebjeFilma.IdOsebjeFilma }, osebjeFilma);
        }

        // DELETE: api/OsebjeFilmaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsebjeFilma([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var osebjeFilma = await _context.OsebjeFilma.FindAsync(id);
            if (osebjeFilma == null)
            {
                return NotFound();
            }

            _context.OsebjeFilma.Remove(osebjeFilma);
            await _context.SaveChangesAsync();

            return Ok(osebjeFilma);
        }

        private bool OsebjeFilmaExists(decimal id)
        {
            return _context.OsebjeFilma.Any(e => e.IdOsebjeFilma == id);
        }
    }
}