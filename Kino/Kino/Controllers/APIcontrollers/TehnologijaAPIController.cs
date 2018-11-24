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
    public class TehnologijaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public TehnologijaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TehnologijaAPI
        [HttpGet]
        public IEnumerable<Tehnologija> GetTehnologija()
        {
            return _context.Tehnologija;
        }

        // GET: api/TehnologijaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTehnologija([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tehnologija = await _context.Tehnologija.FindAsync(id);

            if (tehnologija == null)
            {
                return NotFound();
            }

            return Ok(tehnologija);
        }

        // PUT: api/TehnologijaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTehnologija([FromRoute] decimal id, [FromBody] Tehnologija tehnologija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tehnologija.IdTehnologije)
            {
                return BadRequest();
            }

            _context.Entry(tehnologija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TehnologijaExists(id))
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

        // POST: api/TehnologijaAPI
        [HttpPost]
        public async Task<IActionResult> PostTehnologija([FromBody] Tehnologija tehnologija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tehnologija.Add(tehnologija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTehnologija", new { id = tehnologija.IdTehnologije }, tehnologija);
        }

        // DELETE: api/TehnologijaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTehnologija([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tehnologija = await _context.Tehnologija.FindAsync(id);
            if (tehnologija == null)
            {
                return NotFound();
            }

            _context.Tehnologija.Remove(tehnologija);
            await _context.SaveChangesAsync();

            return Ok(tehnologija);
        }

        private bool TehnologijaExists(decimal id)
        {
            return _context.Tehnologija.Any(e => e.IdTehnologije == id);
        }
    }
}