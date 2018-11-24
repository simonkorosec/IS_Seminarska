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
    public class PripadaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public PripadaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PripadaAPI
        [HttpGet]
        public IEnumerable<Pripada> GetPripada()
        {
            return _context.Pripada;
        }

        // GET: api/PripadaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPripada([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pripada = await _context.Pripada.FindAsync(id);

            if (pripada == null)
            {
                return NotFound();
            }

            return Ok(pripada);
        }

        // PUT: api/PripadaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPripada([FromRoute] decimal id, [FromBody] Pripada pripada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pripada.IdZvrst)
            {
                return BadRequest();
            }

            _context.Entry(pripada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PripadaExists(id))
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

        // POST: api/PripadaAPI
        [HttpPost]
        public async Task<IActionResult> PostPripada([FromBody] Pripada pripada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pripada.Add(pripada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PripadaExists(pripada.IdZvrst))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPripada", new { id = pripada.IdZvrst }, pripada);
        }

        // DELETE: api/PripadaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePripada([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pripada = await _context.Pripada.FindAsync(id);
            if (pripada == null)
            {
                return NotFound();
            }

            _context.Pripada.Remove(pripada);
            await _context.SaveChangesAsync();

            return Ok(pripada);
        }

        private bool PripadaExists(decimal id)
        {
            return _context.Pripada.Any(e => e.IdZvrst == id);
        }
    }
}