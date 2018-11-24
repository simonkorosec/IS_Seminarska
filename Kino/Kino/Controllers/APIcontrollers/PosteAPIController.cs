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
    public class PosteAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public PosteAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PosteAPI
        [HttpGet]
        public IEnumerable<Poste> GetPoste()
        {
            return _context.Poste;
        }

        // GET: api/PosteAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoste([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poste = await _context.Poste.FindAsync(id);

            if (poste == null)
            {
                return NotFound();
            }

            return Ok(poste);
        }

        // PUT: api/PosteAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoste([FromRoute] int id, [FromBody] Poste poste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poste.StPoste)
            {
                return BadRequest();
            }

            _context.Entry(poste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosteExists(id))
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

        // POST: api/PosteAPI
        [HttpPost]
        public async Task<IActionResult> PostPoste([FromBody] Poste poste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Poste.Add(poste);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PosteExists(poste.StPoste))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPoste", new { id = poste.StPoste }, poste);
        }

        // DELETE: api/PosteAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoste([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poste = await _context.Poste.FindAsync(id);
            if (poste == null)
            {
                return NotFound();
            }

            _context.Poste.Remove(poste);
            await _context.SaveChangesAsync();

            return Ok(poste);
        }

        private bool PosteExists(int id)
        {
            return _context.Poste.Any(e => e.StPoste == id);
        }
    }
}