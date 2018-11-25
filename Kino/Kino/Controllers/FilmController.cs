using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Models;
using Kino.Models.Wraper;

namespace Kino.Controllers {
    public class FilmController : Controller {
        private readonly KinoDatabaseContext _context;

        public FilmController(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: Film
        public async Task<IActionResult> Index() {
            IEnumerable<Film> filmi = await _context.Film.ToListAsync();
            var wrapperList = new List<KolosejWrapper>();

            foreach (var film in filmi) {
                var wrapper = new KolosejWrapper();
                wrapper.Film = film;
                wrapper.ProdukcijskaZalozba =
                    _context.ProdukcijskaZalozba.FirstOrDefault(s => s.IdZalozba == film.IdZalozba);
                wrapper.StarostnaOmejitev =
                    _context.StarostnaOmejitev.FirstOrDefault(s => s.IdOmejitve == film.IdOmejitve);
                wrapper.OsebjeFilma = _context.OsebjeFilma.FirstOrDefault(s => s.IdOsebjeFilma == film.IdOsebjeFilma);

                wrapperList.Add(wrapper);
            }

            return View(wrapperList);
        }

        // GET: Film/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.IdFilm == id);
            if (film == null) {
                return NotFound();
            }

            return View(film);
        }

        // GET: Film/Create
        public async Task<IActionResult> Create() {
            var wrapper = new KolosejWrapper {
                OsebjeFilmaList = await _context.OsebjeFilma.ToListAsync(),
                ZalozbaList = await _context.ProdukcijskaZalozba.ToListAsync(),
                StarostnaOmejitevList = await _context.StarostnaOmejitev.ToListAsync()
            };

            return View(wrapper);
        }

        // POST: Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KolosejWrapper wrapper) {
            if (ModelState.IsValid) {
                _context.Add(wrapper.Film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(wrapper);
        }

        // GET: Film/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null) {
                return NotFound();
            }

            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdFilm,IdZalozba,IdOmejitve,IdOsebjeFilma,Naslov,Leto,CasTrajanja")]
            Film film) {
            if (id != film.IdFilm) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!FilmExists(film.IdFilm)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        // GET: Film/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.IdFilm == id);
            if (film == null) {
                return NotFound();
            }

            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id) {
            return _context.Film.Any(e => e.IdFilm == id);
        }
    }
}