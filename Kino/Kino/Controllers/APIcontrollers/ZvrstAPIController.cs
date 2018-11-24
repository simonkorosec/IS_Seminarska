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
    public class ZvrstAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public ZvrstAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ZvrstAPI
        [HttpGet]
        public IEnumerable<Zvrst> GetZvrst()
        {
            return _context.Zvrst;
        }

        // GET: api/ZvrstAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZvrst([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zvrst = await _context.Zvrst.FindAsync(id);

            if (zvrst == null)
            {
                return NotFound();
            }

            return Ok(zvrst);
        }

        // PUT: api/ZvrstAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZvrst([FromRoute] decimal id, [FromBody] Zvrst zvrst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zvrst.IdZvrst)
            {
                return BadRequest();
            }

            _context.Entry(zvrst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZvrstExists(id))
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

        // POST: api/ZvrstAPI
        [HttpPost]
        public async Task<IActionResult> PostZvrst([FromBody] Zvrst zvrst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Zvrst.Add(zvrst);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZvrst", new { id = zvrst.IdZvrst }, zvrst);
        }

        // DELETE: api/ZvrstAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZvrst([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zvrst = await _context.Zvrst.FindAsync(id);
            if (zvrst == null)
            {
                return NotFound();
            }

            _context.Zvrst.Remove(zvrst);
            await _context.SaveChangesAsync();

            return Ok(zvrst);
        }

        private bool ZvrstExists(decimal id)
        {
            return _context.Zvrst.Any(e => e.IdZvrst == id);
        }
    }
}