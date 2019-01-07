using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Models;
using Kino.Models.Wraper;
using Microsoft.AspNetCore.Authorization;

namespace Kino.Controllers {
    
    [Authorize]
    public class PredstavaController : Controller {
        private readonly KinoDatabaseContext _context;

        public PredstavaController(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: Predstava
        public async Task<IActionResult> Index() {
            IEnumerable<Predstava> predstave = await _context.Predstava.ToListAsync();
            var wrapperList = new List<KolosejWrapper>();

            foreach (var predstava in predstave) {
                var wrapper = new KolosejWrapper();
                wrapper.Predstava = predstava;
                wrapper.Film = _context.Film.FirstOrDefault(s => s.IdFilm == predstava.IdFilm);
                wrapper.Dvorana = _context.Dvorana.FirstOrDefault(s => s.IdDvorane == predstava.IdDvorane);

                wrapperList.Add(wrapper);
            }

            return View(wrapperList);
        }

        // GET: Predstava/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var predstava = await _context.Predstava
                .FirstOrDefaultAsync(m => m.IdFilm == id);
            if (predstava == null) {
                return NotFound();
            }

            return View(predstava);
        }

        // GET: Predstava/Create
        public async Task<IActionResult> Create() {
            KolosejWrapper wrapper = new KolosejWrapper();
            wrapper.FilmList = await _context.Film.ToListAsync();
            wrapper.DvoranaList = await _context.Dvorana.ToListAsync();

            return View(wrapper);
        }

        // POST: Predstava/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KolosejWrapper wrapper) {
            var predstava = wrapper.Predstava;
            if (ModelState.IsValid) {
                _context.Add(predstava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // če je kj narobe treba na nov nafilat tedva lista
            wrapper.FilmList = await _context.Film.ToListAsync();
            wrapper.DvoranaList = await _context.Dvorana.ToListAsync();

            return View(wrapper);
        }

        // GET: Predstava/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var predstava = await _context.Predstava.FindAsync(id);
            if (predstava == null) {
                return NotFound();
            }

            return View(predstava);
        }

        // POST: Predstava/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFilm,IdDvorane,CasZacetka,CasKonca,Datum")]
            Predstava predstava) {
            if (id != predstava.IdFilm) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(predstava);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!PredstavaExists(predstava.IdFilm)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(predstava);
        }

        // GET: Predstava/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var predstava = await _context.Predstava
                .FirstOrDefaultAsync(m => m.IdFilm == id);
            if (predstava == null) {
                return NotFound();
            }

            return View(predstava);
        }

        // POST: Predstava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var predstava = await _context.Predstava.FindAsync(id);
            _context.Predstava.Remove(predstava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredstavaExists(int id) {
            return _context.Predstava.Any(e => e.IdFilm == id);
        }
    }
}