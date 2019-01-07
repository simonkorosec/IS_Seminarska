using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kino.Controllers
{
    [Authorize]
    public class TehnologijaController : Controller
    {
        private readonly KinoDatabaseContext _context;

        public TehnologijaController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Tehnologija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tehnologija.ToListAsync());
        }

        // GET: Tehnologija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tehnologija = await _context.Tehnologija
                .FirstOrDefaultAsync(m => m.IdTehnologije == id);
            if (tehnologija == null)
            {
                return NotFound();
            }

            return View(tehnologija);
        }

        // GET: Tehnologija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tehnologija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTehnologije,ImeTehnologije")] Tehnologija tehnologija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tehnologija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tehnologija);
        }

        // GET: Tehnologija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tehnologija = await _context.Tehnologija.FindAsync(id);
            if (tehnologija == null)
            {
                return NotFound();
            }
            return View(tehnologija);
        }

        // POST: Tehnologija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTehnologije,ImeTehnologije")] Tehnologija tehnologija)
        {
            if (id != tehnologija.IdTehnologije)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tehnologija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TehnologijaExists(tehnologija.IdTehnologije))
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
            return View(tehnologija);
        }

        // GET: Tehnologija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tehnologija = await _context.Tehnologija
                .FirstOrDefaultAsync(m => m.IdTehnologije == id);
            if (tehnologija == null)
            {
                return NotFound();
            }

            return View(tehnologija);
        }

        // POST: Tehnologija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tehnologija = await _context.Tehnologija.FindAsync(id);
            _context.Tehnologija.Remove(tehnologija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TehnologijaExists(int id)
        {
            return _context.Tehnologija.Any(e => e.IdTehnologije == id);
        }
    }
}
