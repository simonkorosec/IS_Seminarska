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
    public class StarostnaOmejitevController : Controller
    {
        private readonly KinoDatabaseContext _context;

        public StarostnaOmejitevController(KinoDatabaseContext context)
        {
            _context = context;
        }

        // GET: StarostnaOmejitev
        public async Task<IActionResult> Index()
        {
            return View(await _context.StarostnaOmejitev.ToListAsync());
        }

        // GET: StarostnaOmejitev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starostnaOmejitev = await _context.StarostnaOmejitev
                .FirstOrDefaultAsync(m => m.IdOmejitve == id);
            if (starostnaOmejitev == null)
            {
                return NotFound();
            }

            return View(starostnaOmejitev);
        }

        // GET: StarostnaOmejitev/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StarostnaOmejitev/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOmejitve,Ime")] StarostnaOmejitev starostnaOmejitev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starostnaOmejitev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starostnaOmejitev);
        }

        // GET: StarostnaOmejitev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starostnaOmejitev = await _context.StarostnaOmejitev.FindAsync(id);
            if (starostnaOmejitev == null)
            {
                return NotFound();
            }
            return View(starostnaOmejitev);
        }

        // POST: StarostnaOmejitev/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOmejitve,Ime")] StarostnaOmejitev starostnaOmejitev)
        {
            if (id != starostnaOmejitev.IdOmejitve)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starostnaOmejitev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarostnaOmejitevExists(starostnaOmejitev.IdOmejitve))
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
            return View(starostnaOmejitev);
        }

        // GET: StarostnaOmejitev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starostnaOmejitev = await _context.StarostnaOmejitev
                .FirstOrDefaultAsync(m => m.IdOmejitve == id);
            if (starostnaOmejitev == null)
            {
                return NotFound();
            }

            return View(starostnaOmejitev);
        }

        // POST: StarostnaOmejitev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starostnaOmejitev = await _context.StarostnaOmejitev.FindAsync(id);
            _context.StarostnaOmejitev.Remove(starostnaOmejitev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarostnaOmejitevExists(int id)
        {
            return _context.StarostnaOmejitev.Any(e => e.IdOmejitve == id);
        }
    }
}
