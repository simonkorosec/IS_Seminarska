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
    public class ZvrstController : Controller
    {
        private readonly KinoDatabaseContext _context;

        public ZvrstController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Zvrst
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zvrst.ToListAsync());
        }

        // GET: Zvrst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zvrst = await _context.Zvrst
                .FirstOrDefaultAsync(m => m.IdZvrst == id);
            if (zvrst == null)
            {
                return NotFound();
            }

            return View(zvrst);
        }

        // GET: Zvrst/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zvrst/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZvrst,Ime")] Zvrst zvrst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zvrst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zvrst);
        }

        // GET: Zvrst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zvrst = await _context.Zvrst.FindAsync(id);
            if (zvrst == null)
            {
                return NotFound();
            }
            return View(zvrst);
        }

        // POST: Zvrst/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZvrst,Ime")] Zvrst zvrst)
        {
            if (id != zvrst.IdZvrst)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zvrst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZvrstExists(zvrst.IdZvrst))
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
            return View(zvrst);
        }

        // GET: Zvrst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zvrst = await _context.Zvrst
                .FirstOrDefaultAsync(m => m.IdZvrst == id);
            if (zvrst == null)
            {
                return NotFound();
            }

            return View(zvrst);
        }

        // POST: Zvrst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zvrst = await _context.Zvrst.FindAsync(id);
            _context.Zvrst.Remove(zvrst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZvrstExists(int id)
        {
            return _context.Zvrst.Any(e => e.IdZvrst == id);
        }
    }
}
