using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogSosyalMedya.Data;
using BlogSosyalMedya.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BlogSosyalMedya.Controllers
{
    public class TatilYerleriController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TatilYerleriController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: TatilYerleri
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TatilYerleri.Include(t => t.Kategori).Include(t => t.Sehir).Include(t => t.Ulke);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TatilYerleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatilYerleri = await _context.TatilYerleri
                .Include(t => t.Kategori)
                .Include(t => t.Sehir)
                .Include(t => t.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatilYerleri == null)
            {
                return NotFound();
            }

            return View(tatilYerleri);
        }

        // GET: TatilYerleri/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı");
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi");
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd");
            return View();
        }

        // POST: TatilYerleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YerAdı,SehirId,UlkeId,KategoriId,Puani")] TatilYerleri tatilYerleri)
        {
            if (ModelState.IsValid)
            {
                //******
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"YerResimleri");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                tatilYerleri.Fotograf= @"\YerResimleri\" + fileName + extension;

                //********
                _context.Add(tatilYerleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", tatilYerleri.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", tatilYerleri.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", tatilYerleri.UlkeId);
            return View(tatilYerleri);
        }

        // GET: TatilYerleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatilYerleri = await _context.TatilYerleri.FindAsync(id);
            if (tatilYerleri == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", tatilYerleri.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", tatilYerleri.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", tatilYerleri.UlkeId);
            return View(tatilYerleri);
        }

        // POST: TatilYerleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YerAdı,SehirId,UlkeId,KategoriId,Puani")] TatilYerleri tatilYerleri)
        {
            if (id != tatilYerleri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tatilYerleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TatilYerleriExists(tatilYerleri.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdı", tatilYerleri.KategoriId);
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "SehirAdi", tatilYerleri.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "UlkeAd", tatilYerleri.UlkeId);
            return View(tatilYerleri);
        }

        // GET: TatilYerleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatilYerleri = await _context.TatilYerleri
                .Include(t => t.Kategori)
                .Include(t => t.Sehir)
                .Include(t => t.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatilYerleri == null)
            {
                return NotFound();
            }

            return View(tatilYerleri);
        }

        // POST: TatilYerleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tatilYerleri = await _context.TatilYerleri.FindAsync(id);
            _context.TatilYerleri.Remove(tatilYerleri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TatilYerleriExists(int id)
        {
            return _context.TatilYerleri.Any(e => e.Id == id);
        }
    }
}
