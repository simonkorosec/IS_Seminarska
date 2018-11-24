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
    public class IgraVAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public IgraVAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/IgraVAPI
        [HttpGet]
        public IEnumerable<IgraV> GetIgraV()
        {
            return _context.IgraV;
        }

        // GET: api/IgraVAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIgraV([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var igraV = await _context.IgraV.FindAsync(id);

            if (igraV == null)
            {
                return NotFound();
            }

            return Ok(igraV);
        }

        // PUT: api/IgraVAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIgraV([FromRoute] decimal id, [FromBody] IgraV igraV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != igraV.IdFilm)
            {
                return BadRequest();
            }

            _context.Entry(igraV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IgraVExists(id))
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

        // POST: api/IgraVAPI
        [HttpPost]
        public async Task<IActionResult> PostIgraV([FromBody] IgraV igraV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IgraV.Add(igraV);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IgraVExists(igraV.IdFilm))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIgraV", new { id = igraV.IdFilm }, igraV);
        }

        // DELETE: api/IgraVAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIgraV([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var igraV = await _context.IgraV.FindAsync(id);
            if (igraV == null)
            {
                return NotFound();
            }

            _context.IgraV.Remove(igraV);
            await _context.SaveChangesAsync();

            return Ok(igraV);
        }

        private bool IgraVExists(decimal id)
        {
            return _context.IgraV.Any(e => e.IdFilm == id);
        }
    }
}