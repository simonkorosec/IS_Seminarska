using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kino.Controllers {
    [Authorize]
    public class OsebjeFilmaController : Controller {
        private readonly KinoDatabaseContext _context;

        public OsebjeFilmaController(KinoDatabaseContext context) {
            _context = context;
        }

        // GET: OsebjeFilma
        public async Task<IActionResult> Index() {
            return View(await _context.OsebjeFilma.ToListAsync());
        }

        // GET: OsebjeFilma/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var osebjeFilma = await _context.OsebjeFilma
                .FirstOrDefaultAsync(m => m.IdOsebjeFilma == id);
            if (osebjeFilma == null) {
                return NotFound();
            }

            return View(osebjeFilma);
        }

        // GET: OsebjeFilma/Create
        public IActionResult Create() {
            return View();
        }

        // POST: OsebjeFilma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOsebjeFilma,Ime,DatumRojstva")]
            OsebjeFilma osebjeFilma) {
            if (ModelState.IsValid) {
                _context.Add(osebjeFilma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(osebjeFilma);
        }

        // GET: OsebjeFilma/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var osebjeFilma = await _context.OsebjeFilma.FindAsync(id);
            if (osebjeFilma == null) {
                return NotFound();
            }

            return View(osebjeFilma);
        }

        // POST: OsebjeFilma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOsebjeFilma,Ime,DatumRojstva")]
            OsebjeFilma osebjeFilma) {
            if (id != osebjeFilma.IdOsebjeFilma) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(osebjeFilma);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!OsebjeFilmaExists(osebjeFilma.IdOsebjeFilma)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(osebjeFilma);
        }

        // GET: OsebjeFilma/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var osebjeFilma = await _context.OsebjeFilma
                .FirstOrDefaultAsync(m => m.IdOsebjeFilma == id);
            if (osebjeFilma == null) {
                return NotFound();
            }

            return View(osebjeFilma);
        }

        // POST: OsebjeFilma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var osebjeFilma = await _context.OsebjeFilma.FindAsync(id);
            _context.OsebjeFilma.Remove(osebjeFilma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsebjeFilmaExists(int id) {
            return _context.OsebjeFilma.Any(e => e.IdOsebjeFilma == id);
        }
    }
}