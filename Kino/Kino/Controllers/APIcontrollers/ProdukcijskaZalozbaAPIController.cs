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
    public class ProdukcijskaZalozbaAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public ProdukcijskaZalozbaAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProdukcijskaZalozbaAPI
        [HttpGet]
        public IEnumerable<ProdukcijskaZalozba> GetProdukcijskaZalozba()
        {
            return _context.ProdukcijskaZalozba;
        }

        // GET: api/ProdukcijskaZalozbaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdukcijskaZalozba([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produkcijskaZalozba = await _context.ProdukcijskaZalozba.FindAsync(id);

            if (produkcijskaZalozba == null)
            {
                return NotFound();
            }

            return Ok(produkcijskaZalozba);
        }

        // PUT: api/ProdukcijskaZalozbaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukcijskaZalozba([FromRoute] decimal id, [FromBody] ProdukcijskaZalozba produkcijskaZalozba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produkcijskaZalozba.IdZalozba)
            {
                return BadRequest();
            }

            _context.Entry(produkcijskaZalozba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdukcijskaZalozbaExists(id))
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

        // POST: api/ProdukcijskaZalozbaAPI
        [HttpPost]
        public async Task<IActionResult> PostProdukcijskaZalozba([FromBody] ProdukcijskaZalozba produkcijskaZalozba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProdukcijskaZalozba.Add(produkcijskaZalozba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdukcijskaZalozba", new { id = produkcijskaZalozba.IdZalozba }, produkcijskaZalozba);
        }

        // DELETE: api/ProdukcijskaZalozbaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukcijskaZalozba([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produkcijskaZalozba = await _context.ProdukcijskaZalozba.FindAsync(id);
            if (produkcijskaZalozba == null)
            {
                return NotFound();
            }

            _context.ProdukcijskaZalozba.Remove(produkcijskaZalozba);
            await _context.SaveChangesAsync();

            return Ok(produkcijskaZalozba);
        }

        private bool ProdukcijskaZalozbaExists(decimal id)
        {
            return _context.ProdukcijskaZalozba.Any(e => e.IdZalozba == id);
        }
    }
}