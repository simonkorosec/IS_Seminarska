using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kino.Models;
using Kino.Models.Wraper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Kino.Controllers {
    public class KolosejController : Controller {
        private readonly KinoDatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public KolosejController(KinoDatabaseContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        // GET: Kolosej
        [Authorize]
        public async Task<IActionResult> Index() {
            var wrapperList = new List<KolosejWrapper>();
            var currentUser = await _userManager.GetUserAsync(User);

            IEnumerable<Kolosej> koloseji = await _context.Kolosej.ToListAsync();

            foreach (var kolosej in koloseji) {
                if (kolosej.OwnerId != currentUser.Id) {
                    continue;
                }

                var wrapper = new KolosejWrapper();
                wrapper.Kolosej = kolosej;
                wrapper.Naslov = _context.Naslov.FirstOrDefault(s => s.IdNaslov == kolosej.IdNaslov);
                wrapper.Poste = _context.Poste.FirstOrDefault(s => s.StPoste == wrapper.Naslov.StPoste);

                wrapper.StringNaslov = "" + wrapper.Naslov.Ulica + " " + wrapper.Naslov.HisnaSt + ", " +
                                       wrapper.Poste.Kraj + " " + wrapper.Poste.StPoste + "";
                wrapperList.Add(wrapper);
            }

            return View(wrapperList);
        }

        // GET: Kolosej/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var kolosej = await _context.Kolosej
                .FirstOrDefaultAsync(m => m.IdKolosej == id);
            if (kolosej == null) {
                return NotFound();
            }

            return View(kolosej);
        }

        // GET: Kolosej/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Kolosej/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(KolosejWrapper kolosejWrapper) {
            var currentUser = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid) {
                var posta = kolosejWrapper.Poste;
                var naslov = kolosejWrapper.Naslov;
                var kolosej = kolosejWrapper.Kolosej;
                naslov.StPoste = posta.StPoste;

                if (_context.Poste.Find(posta.StPoste) == null) {
                    _context.Add(posta);
                }
                _context.Add(naslov);
                _context.SaveChanges();

                kolosej.IdNaslov = naslov.IdNaslov;
                kolosej.OwnerId = currentUser.Id;
                _context.Add(kolosej);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(kolosejWrapper);
        }

        // GET: Kolosej/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var kolosej = await _context.Kolosej.FindAsync(id);
            if (kolosej == null) {
                return NotFound();
            }

            return View(kolosej);
        }

        // POST: Kolosej/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("IdKolosej,IdNaslov,Ime")] Kolosej kolosej) {
            if (id != kolosej.IdKolosej) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(kolosej);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!KolosejExists(kolosej.IdKolosej)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(kolosej);
        }

        // GET: Kolosej/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var kolosej = await _context.Kolosej
                .FirstOrDefaultAsync(m => m.IdKolosej == id);
            if (kolosej == null) {
                return NotFound();
            }

            return View(kolosej);
        }

        // POST: Kolosej/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var kolosej = await _context.Kolosej.FindAsync(id);
            _context.Kolosej.Remove(kolosej);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KolosejExists(int id) {
            return _context.Kolosej.Any(e => e.IdKolosej == id);
        }


        public IActionResult Chose(int? id) {
            if (id == null) {
                return NotFound();
            }

            HttpContext.Session.SetInt32("IdKolosej", (int) id);

            return RedirectToAction("Index", "Dvorana");

            //throw new NotImplementedException();
        }
    }
}