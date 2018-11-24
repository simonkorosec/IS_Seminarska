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
    public class PredstavaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public PredstavaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PredstavaAPI
        [HttpGet]
        public IEnumerable<Predstava> GetPredstava()
        {
            return _context.Predstava;
        }

        // GET: api/PredstavaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPredstava([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var predstava = await _context.Predstava.FindAsync(id);

            if (predstava == null)
            {
                return NotFound();
            }

            return Ok(predstava);
        }

        // PUT: api/PredstavaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredstava([FromRoute] decimal id, [FromBody] Predstava predstava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != predstava.IdFilm)
            {
                return BadRequest();
            }

            _context.Entry(predstava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredstavaExists(id))
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

        // POST: api/PredstavaAPI
        [HttpPost]
        public async Task<IActionResult> PostPredstava([FromBody] Predstava predstava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Predstava.Add(predstava);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PredstavaExists(predstava.IdFilm))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPredstava", new { id = predstava.IdFilm }, predstava);
        }

        // DELETE: api/PredstavaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredstava([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var predstava = await _context.Predstava.FindAsync(id);
            if (predstava == null)
            {
                return NotFound();
            }

            _context.Predstava.Remove(predstava);
            await _context.SaveChangesAsync();

            return Ok(predstava);
        }

        private bool PredstavaExists(decimal id)
        {
            return _context.Predstava.Any(e => e.IdFilm == id);
        }
    }
}