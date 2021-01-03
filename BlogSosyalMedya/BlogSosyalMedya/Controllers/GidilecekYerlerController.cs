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
    public class GidilecekYerlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GidilecekYerlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GidilecekYerlers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GidilecekYerler.Include(g => g.Kategori).Include(g => g.Sehir).Include(g => g.Ulke);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GidilecekYerlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gidilecekYerler = await _context.GidilecekYerler
                .Include(g => g.Kategori)
                .Include(g => g.Sehir)
                .Include(g => g.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gidilecekYerler == null)
            {
                return NotFound();
            }

            return View(gidilecekYerler);
        }

        // GET: GidilecekYerlers/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı");
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi");
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd");
            return View();
        }

        // POST: GidilecekYerlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YerAdi,SehirId,UlkeId,KategoriId,Fotograf")] GidilecekYerler gidilecekYerler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gidilecekYerler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", gidilecekYerler.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", gidilecekYerler.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", gidilecekYerler.UlkeId);
            return View(gidilecekYerler);
        }

        // GET: GidilecekYerlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gidilecekYerler = await _context.GidilecekYerler.FindAsync(id);
            if (gidilecekYerler == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", gidilecekYerler.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", gidilecekYerler.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", gidilecekYerler.UlkeId);
            return View(gidilecekYerler);
        }

        // POST: GidilecekYerlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YerAdi,SehirId,UlkeId,KategoriId,Fotograf")] GidilecekYerler gidilecekYerler)
        {
            if (id != gidilecekYerler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gidilecekYerler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GidilecekYerlerExists(gidilecekYerler.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", gidilecekYerler.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", gidilecekYerler.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", gidilecekYerler.UlkeId);
            return View(gidilecekYerler);
        }

        // GET: GidilecekYerlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gidilecekYerler = await _context.GidilecekYerler
                .Include(g => g.Kategori)
                .Include(g => g.Sehir)
                .Include(g => g.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gidilecekYerler == null)
            {
                return NotFound();
            }

            return View(gidilecekYerler);
        }

        // POST: GidilecekYerlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gidilecekYerler = await _context.GidilecekYerler.FindAsync(id);
            _context.GidilecekYerler.Remove(gidilecekYerler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GidilecekYerlerExists(int id)
        {
            return _context.GidilecekYerler.Any(e => e.Id == id);
        }
    }
}
