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
    public class TurGorevlisiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurGorevlisiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TurGorevlisi
        public async Task<IActionResult> Index()
        {
            return View(await _context.TurGorevlisi.ToListAsync());
        }

        // GET: TurGorevlisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turGorevlisi = await _context.TurGorevlisi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turGorevlisi == null)
            {
                return NotFound();
            }

            return View(turGorevlisi);
        }

        // GET: TurGorevlisi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TurGorevlisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GorevliAdi")] TurGorevlisi turGorevlisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turGorevlisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turGorevlisi);
        }

        // GET: TurGorevlisi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turGorevlisi = await _context.TurGorevlisi.FindAsync(id);
            if (turGorevlisi == null)
            {
                return NotFound();
            }
            return View(turGorevlisi);
        }

        // POST: TurGorevlisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GorevliAdi")] TurGorevlisi turGorevlisi)
        {
            if (id != turGorevlisi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turGorevlisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurGorevlisiExists(turGorevlisi.Id))
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
            return View(turGorevlisi);
        }

        // GET: TurGorevlisi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turGorevlisi = await _context.TurGorevlisi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turGorevlisi == null)
            {
                return NotFound();
            }

            return View(turGorevlisi);
        }

        // POST: TurGorevlisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turGorevlisi = await _context.TurGorevlisi.FindAsync(id);
            _context.TurGorevlisi.Remove(turGorevlisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurGorevlisiExists(int id)
        {
            return _context.TurGorevlisi.Any(e => e.Id == id);
        }
    }
}
