using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Models;

namespace Kino.Controllers
{
    public class KolosejController : Controller
    {
        private readonly KinoDatabaseContext _context;

        public KolosejController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Kolosej
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kolosej.ToListAsync());
        }

        // GET: Kolosej/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolosej = await _context.Kolosej
                .FirstOrDefaultAsync(m => m.IdKolosej == id);
            if (kolosej == null)
            {
                return NotFound();
            }

            return View(kolosej);
        }

        // GET: Kolosej/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kolosej/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKolosej,IdNaslov,Ime")] Kolosej kolosej)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kolosej);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kolosej);
        }

        // GET: Kolosej/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolosej = await _context.Kolosej.FindAsync(id);
            if (kolosej == null)
            {
                return NotFound();
            }
            return View(kolosej);
        }

        // POST: Kolosej/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdKolosej,IdNaslov,Ime")] Kolosej kolosej)
        {
            if (id != kolosej.IdKolosej)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kolosej);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KolosejExists(kolosej.IdKolosej))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kolosej);
        }

        // GET: Kolosej/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolosej = await _context.Kolosej
                .FirstOrDefaultAsync(m => m.IdKolosej == id);
            if (kolosej == null)
            {
                return NotFound();
            }

            return View(kolosej);
        }

        // POST: Kolosej/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var kolosej = await _context.Kolosej.FindAsync(id);
            _context.Kolosej.Remove(kolosej);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KolosejExists(decimal id)
        {
            return _context.Kolosej.Any(e => e.IdKolosej == id);
        }
    }
}
