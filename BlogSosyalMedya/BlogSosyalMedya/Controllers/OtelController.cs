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
    public class OtelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Otel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Otel.Include(o => o.Sehir).Include(o => o.Ulke);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Otel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otel = await _context.Otel
                .Include(o => o.Sehir)
                .Include(o => o.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otel == null)
            {
                return NotFound();
            }

            return View(otel);
        }

        // GET: Otel/Create
        public IActionResult Create()
        {
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "Id");
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id");
            return View();
        }

        // POST: Otel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OtelYildizi,OtelAdi,SehirId,UlkeId")] Otel otel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "Id", otel.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id", otel.UlkeId);
            return View(otel);
        }

        // GET: Otel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otel = await _context.Otel.FindAsync(id);
            if (otel == null)
            {
                return NotFound();
            }
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "Id", otel.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id", otel.UlkeId);
            return View(otel);
        }

        // POST: Otel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OtelYildizi,OtelAdi,SehirId,UlkeId")] Otel otel)
        {
            if (id != otel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtelExists(otel.Id))
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
            ViewData["SehirId"] = new SelectList(_context.Sehir, "Id", "Id", otel.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id", otel.UlkeId);
            return View(otel);
        }

        // GET: Otel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otel = await _context.Otel
                .Include(o => o.Sehir)
                .Include(o => o.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otel == null)
            {
                return NotFound();
            }

            return View(otel);
        }

        // POST: Otel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otel = await _context.Otel.FindAsync(id);
            _context.Otel.Remove(otel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtelExists(int id)
        {
            return _context.Otel.Any(e => e.Id == id);
        }
    }
}
