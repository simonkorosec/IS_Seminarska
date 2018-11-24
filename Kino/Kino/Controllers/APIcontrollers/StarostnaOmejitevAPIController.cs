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
    public class StarostnaOmejitevAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public StarostnaOmejitevAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StarostnaOmejitevAPI
        [HttpGet]
        public IEnumerable<StarostnaOmejitev> GetStarostnaOmejitev()
        {
            return _context.StarostnaOmejitev;
        }

        // GET: api/StarostnaOmejitevAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStarostnaOmejitev([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starostnaOmejitev = await _context.StarostnaOmejitev.FindAsync(id);

            if (starostnaOmejitev == null)
            {
                return NotFound();
            }

            return Ok(starostnaOmejitev);
        }

        // PUT: api/StarostnaOmejitevAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarostnaOmejitev([FromRoute] decimal id, [FromBody] StarostnaOmejitev starostnaOmejitev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != starostnaOmejitev.IdOmejitve)
            {
                return BadRequest();
            }

            _context.Entry(starostnaOmejitev).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarostnaOmejitevExists(id))
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

        // POST: api/StarostnaOmejitevAPI
        [HttpPost]
        public async Task<IActionResult> PostStarostnaOmejitev([FromBody] StarostnaOmejitev starostnaOmejitev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StarostnaOmejitev.Add(starostnaOmejitev);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StarostnaOmejitevExists(starostnaOmejitev.IdOmejitve))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStarostnaOmejitev", new { id = starostnaOmejitev.IdOmejitve }, starostnaOmejitev);
        }

        // DELETE: api/StarostnaOmejitevAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarostnaOmejitev([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starostnaOmejitev = await _context.StarostnaOmejitev.FindAsync(id);
            if (starostnaOmejitev == null)
            {
                return NotFound();
            }

            _context.StarostnaOmejitev.Remove(starostnaOmejitev);
            await _context.SaveChangesAsync();

            return Ok(starostnaOmejitev);
        }

        private bool StarostnaOmejitevExists(decimal id)
        {
            return _context.StarostnaOmejitev.Any(e => e.IdOmejitve == id);
        }
    }
}