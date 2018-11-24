using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers.APIcontrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class DvoranaAPIController : ControllerBase {
        private readonly KinoDatabaseContext _context;

        public DvoranaAPIController(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: api/DvoranaAP
        [HttpGet]
        public IEnumerable<Dvorana> GetDvorana() {
            return _context.Dvorana;
        }

        // GET: api/DvoranaAP/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDvorana([FromRoute] decimal id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var dvorana = await _context.Dvorana.FindAsync(id);

            if (dvorana == null) {
                return NotFound();
            }

            return Ok(dvorana);
        }

        // PUT: api/DvoranaAP/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDvorana([FromRoute] decimal id, [FromBody] Dvorana dvorana) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != dvorana.IdDvorane) {
                return BadRequest();
            }

            _context.Entry(dvorana).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!DvoranaExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DvoranaAP
        [HttpPost]
        public async Task<IActionResult> PostDvorana([FromBody] Dvorana dvorana) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Dvorana.Add(dvorana);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDvorana", new {id = dvorana.IdDvorane}, dvorana);
        }

        // DELETE: api/DvoranaAP/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDvorana([FromRoute] decimal id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var dvorana = await _context.Dvorana.FindAsync(id);
            if (dvorana == null) {
                return NotFound();
            }

            _context.Dvorana.Remove(dvorana);
            await _context.SaveChangesAsync();

            return Ok(dvorana);
        }

        private bool DvoranaExists(decimal id) {
            return _context.Dvorana.Any(e => e.IdDvorane == id);
        }
    }
}