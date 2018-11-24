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
    public class FilmAPIController : ControllerBase
    {
        private readonly KinoDatabaseContext _context;

        public FilmAPIController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FilmAPI
        [HttpGet]
        public IEnumerable<Film> GetFilm()
        {
            return _context.Film;
        }

        // GET: api/FilmAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilm([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = await _context.Film.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        // PUT: api/FilmAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm([FromRoute] decimal id, [FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != film.IdFilm)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/FilmAPI
        [HttpPost]
        public async Task<IActionResult> PostFilm([FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Film.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.IdFilm }, film);
        }

        // DELETE: api/FilmAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Film.Remove(film);
            await _context.SaveChangesAsync();

            return Ok(film);
        }

        private bool FilmExists(decimal id)
        {
            return _context.Film.Any(e => e.IdFilm == id);
        }
    }
}