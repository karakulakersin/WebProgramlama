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
    public class OtellController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtellController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Otell
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Otell.Include(o => o.Kategori).Include(o => o.Sehir).Include(o => o.Ulke);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Otell/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otell = await _context.Otell
                .Include(o => o.Kategori)
                .Include(o => o.Sehir)
                .Include(o => o.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otell == null)
            {
                return NotFound();
            }

            return View(otell);
        }

        // GET: Otell/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı");
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi");
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd");
            return View();
        }

        // POST: Otell/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OtelAdi,OtelYildizi,SehirId,UlkeId,KategoriId")] Otell otell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", otell.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", otell.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", otell.UlkeId);
            return View(otell);
        }

        // GET: Otell/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otell = await _context.Otell.FindAsync(id);
            if (otell == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", otell.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", otell.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", otell.UlkeId);
            return View(otell);
        }

        // POST: Otell/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OtelAdi,OtelYildizi,SehirId,UlkeId,KategoriId")] Otell otell)
        {
            if (id != otell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtellExists(otell.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", otell.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", otell.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", otell.UlkeId);
            return View(otell);
        }

        // GET: Otell/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otell = await _context.Otell
                .Include(o => o.Kategori)
                .Include(o => o.Sehir)
                .Include(o => o.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otell == null)
            {
                return NotFound();
            }

            return View(otell);
        }

        // POST: Otell/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otell = await _context.Otell.FindAsync(id);
            _context.Otell.Remove(otell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtellExists(int id)
        {
            return _context.Otell.Any(e => e.Id == id);
        }
    }
}
