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
    public class ProdukcijskaZalozbaController : Controller
    {
        private readonly KinoDatabaseContext _context;

        public ProdukcijskaZalozbaController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: ProdukcijskaZalozba
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdukcijskaZalozba.ToListAsync());
        }

        // GET: ProdukcijskaZalozba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkcijskaZalozba = await _context.ProdukcijskaZalozba
                .FirstOrDefaultAsync(m => m.IdZalozba == id);
            if (produkcijskaZalozba == null)
            {
                return NotFound();
            }

            return View(produkcijskaZalozba);
        }

        // GET: ProdukcijskaZalozba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdukcijskaZalozba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZalozba,Ime")] ProdukcijskaZalozba produkcijskaZalozba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkcijskaZalozba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkcijskaZalozba);
        }

        // GET: ProdukcijskaZalozba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkcijskaZalozba = await _context.ProdukcijskaZalozba.FindAsync(id);
            if (produkcijskaZalozba == null)
            {
                return NotFound();
            }
            return View(produkcijskaZalozba);
        }

        // POST: ProdukcijskaZalozba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZalozba,Ime")] ProdukcijskaZalozba produkcijskaZalozba)
        {
            if (id != produkcijskaZalozba.IdZalozba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkcijskaZalozba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukcijskaZalozbaExists(produkcijskaZalozba.IdZalozba))
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
            return View(produkcijskaZalozba);
        }

        // GET: ProdukcijskaZalozba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkcijskaZalozba = await _context.ProdukcijskaZalozba
                .FirstOrDefaultAsync(m => m.IdZalozba == id);
            if (produkcijskaZalozba == null)
            {
                return NotFound();
            }

            return View(produkcijskaZalozba);
        }

        // POST: ProdukcijskaZalozba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkcijskaZalozba = await _context.ProdukcijskaZalozba.FindAsync(id);
            _context.ProdukcijskaZalozba.Remove(produkcijskaZalozba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukcijskaZalozbaExists(int id)
        {
            return _context.ProdukcijskaZalozba.Any(e => e.IdZalozba == id);
        }
    }
}
