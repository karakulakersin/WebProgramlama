using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogSosyalMedya.Data;
using BlogSosyalMedya.Models;

namespace BlogSosyalMedya.Controllers
{
    public class TatilTuruController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TatilTuruController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TatilTuru
        public async Task<IActionResult> Index()
        {
            return View(await _context.TatilTuru.ToListAsync());
        }

        // GET: TatilTuru/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatilTuru = await _context.TatilTuru
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatilTuru == null)
            {
                return NotFound();
            }

            return View(tatilTuru);
        }

        // GET: TatilTuru/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TatilTuru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurAdi,Ucret")] TatilTuru tatilTuru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tatilTuru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tatilTuru);
        }

        // GET: TatilTuru/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatilTuru = await _context.TatilTuru.FindAsync(id);
            if (tatilTuru == null)
            {
                return NotFound();
            }
            return View(tatilTuru);
        }

        // POST: TatilTuru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurAdi,Ucret")] TatilTuru tatilTuru)
        {
            if (id != tatilTuru.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tatilTuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TatilTuruExists(tatilTuru.Id))
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
            return View(tatilTuru);
        }

        // GET: TatilTuru/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatilTuru = await _context.TatilTuru
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatilTuru == null)
            {
                return NotFound();
            }

            return View(tatilTuru);
        }

        // POST: TatilTuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tatilTuru = await _context.TatilTuru.FindAsync(id);
            _context.TatilTuru.Remove(tatilTuru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TatilTuruExists(int id)
        {
            return _context.TatilTuru.Any(e => e.Id == id);
        }
    }
}
