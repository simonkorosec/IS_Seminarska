using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Models;
using Kino.Models.Wraper;
using Microsoft.AspNetCore.Http;

namespace Kino.Controllers {
    public class DvoranaController : Controller {
        private readonly KinoDatabaseContext _context;

        public DvoranaController(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: Dvorana
        public async Task<IActionResult> Index() {
            var IdKolosej = HttpContext.Session.GetInt32("IdKolosej");
            if (IdKolosej == null)
            {
                return
                    RedirectToAction("Index", "Kolosej");
                // Če ni naštiman IdKolosej dj na seznam kolosejev
            }

            // Pokažemo samo tiste od trenutnega koloseja
            var wrapper = new KolosejWrapper();
            wrapper.DvoranaList = await _context.Dvorana.Where(s => s.IdKolosej == IdKolosej).ToListAsync();
            wrapper.TehnologijaList = await _context.Tehnologija.ToListAsync();
            return View(wrapper);
        }

        // GET: Dvorana/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var dvorana = await _context.Dvorana
                .FirstOrDefaultAsync(m => m.IdDvorane == id);
            if (dvorana == null) {
                return NotFound();
            }

            return View(dvorana);
        }

        // GET: Dvorana/Create
        public async Task<IActionResult> Create() {
            KolosejWrapper wrapper = new KolosejWrapper();
            wrapper.TehnologijaList = await _context.Tehnologija.ToListAsync();

            return View(wrapper);
        }

        // POST: Dvorana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KolosejWrapper kolosejWrapper) {
            var IdKolosej = HttpContext.Session.GetInt32("IdKolosej");
            if (IdKolosej == null) {
                return
                    RedirectToAction(nameof(KolosejController.Index));
                // Če ni naštiman IdKolosej pjt na seznam kolosejev
            }

            var dvorana = kolosejWrapper.Dvorana;

            if (ModelState.IsValid) {
                dvorana.IdKolosej = (int) IdKolosej;
                _context.Add(dvorana);
                _context.SaveChanges();
                AddSeats(dvorana.IdDvorane, dvorana.StVrst, dvorana.StSedezovNaVrsto);

                return RedirectToAction(nameof(Index));
            }

            return View(kolosejWrapper);
        }

        private void AddSeats(int IdDvorane, int? dvoranaStVrst, int? dvoranaStSedezovNaVrsto) {
            if (dvoranaStVrst == null || dvoranaStSedezovNaVrsto == null) return;

            for (var i = 0; i < dvoranaStVrst; i++) {
                for (var j = 0; j < dvoranaStSedezovNaVrsto; j++) {
                    var sedez = new Sedez() {IdDvorane = IdDvorane, Vrsta = (i + 1), Stevilka = (j + 1)};
                    _context.Add(sedez);
                    _context.SaveChanges();
                }
            }
        }

        // GET: Dvorana/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var dvorana = await _context.Dvorana.FindAsync(id);
            if (dvorana == null) {
                return NotFound();
            }

            return View(dvorana);
        }

        // POST: Dvorana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdDvorane,IdKolosej,IdTehnologije,Ime,StVrst,StSedezovNaVrsto")]
            Dvorana dvorana) {
            if (id != dvorana.IdDvorane) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(dvorana);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!DvoranaExists(dvorana.IdDvorane)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(dvorana);
        }

        // GET: Dvorana/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var dvorana = await _context.Dvorana
                .FirstOrDefaultAsync(m => m.IdDvorane == id);
            if (dvorana == null) {
                return NotFound();
            }

            return View(dvorana);
        }

        // POST: Dvorana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var dvorana = await _context.Dvorana.FindAsync(id);
            var range = _context.Sedez.Where(s => s.IdDvorane == dvorana.IdDvorane);
            _context.Sedez.RemoveRange(range);
            _context.Dvorana.Remove(dvorana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DvoranaExists(int id) {
            return _context.Dvorana.Any(e => e.IdDvorane == id);
        }
    }
}