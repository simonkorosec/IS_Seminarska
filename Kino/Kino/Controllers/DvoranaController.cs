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
    public class DvoranaController : Controller
    {
        private readonly KinoDatabaseContext _context;

        public DvoranaController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Dvorana
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dvorana.ToListAsync());
        }

        // GET: Dvorana/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvorana = await _context.Dvorana
                .FirstOrDefaultAsync(m => m.IdDvorane == id);
            if (dvorana == null)
            {
                return NotFound();
            }

            return View(dvorana);
        }

        // GET: Dvorana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dvorana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDvorane,IdKolosej,IdTehnologije,Ime,StVrst,StSedezovNaVrsto")] Dvorana dvorana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dvorana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dvorana);
        }

        // GET: Dvorana/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvorana = await _context.Dvorana.FindAsync(id);
            if (dvorana == null)
            {
                return NotFound();
            }
            return View(dvorana);
        }

        // POST: Dvorana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdDvorane,IdKolosej,IdTehnologije,Ime,StVrst,StSedezovNaVrsto")] Dvorana dvorana)
        {
            if (id != dvorana.IdDvorane)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvorana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DvoranaExists(dvorana.IdDvorane))
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
            return View(dvorana);
        }

        // GET: Dvorana/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvorana = await _context.Dvorana
                .FirstOrDefaultAsync(m => m.IdDvorane == id);
            if (dvorana == null)
            {
                return NotFound();
            }

            return View(dvorana);
        }

        // POST: Dvorana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var dvorana = await _context.Dvorana.FindAsync(id);
            _context.Dvorana.Remove(dvorana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DvoranaExists(decimal id)
        {
            return _context.Dvorana.Any(e => e.IdDvorane == id);
        }
    }
}
