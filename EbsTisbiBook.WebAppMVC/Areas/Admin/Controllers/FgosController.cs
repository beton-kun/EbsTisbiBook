using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EbsTisbiBook.WebAppMVC.Models;
using EbsTisbiBook.WebAppMVC.Models.Library;

namespace EbsTisbiBook.WebAppMVC.Controllers.Admin
{
    [Area("Admin")]
    public class FgosController : Controller
    {
        private readonly LibraryContext _context;

        public FgosController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Fgos
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Fgos.Include(f => f.Ugnp);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Fgos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fgos = await _context.Fgos
                .Include(f => f.Ugnp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fgos == null)
            {
                return NotFound();
            }

            return View(fgos);
        }

        // GET: Fgos/Create
        public IActionResult Create()
        {
            ViewData["UgnpId"] = new SelectList(_context.Ugnps, "Id", "Name");
            return View();
        }

        // POST: Fgos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UgnpId")] Fgos fgos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fgos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UgnpId"] = new SelectList(_context.Ugnps, "Id", "Name", fgos.UgnpId);
            return View(fgos);
        }

        // GET: Fgos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fgos = await _context.Fgos.FindAsync(id);
            if (fgos == null)
            {
                return NotFound();
            }
            ViewData["UgnpId"] = new SelectList(_context.Ugnps, "Id", "Name", fgos.UgnpId);
            return View(fgos);
        }

        // POST: Fgos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UgnpId")] Fgos fgos)
        {
            if (id != fgos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fgos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FgosExists(fgos.Id))
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
            ViewData["UgnpId"] = new SelectList(_context.Ugnps, "Id", "Name", fgos.UgnpId);
            return View(fgos);
        }

        // GET: Fgos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fgos = await _context.Fgos
                .Include(f => f.Ugnp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fgos == null)
            {
                return NotFound();
            }

            return View(fgos);
        }

        // POST: Fgos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fgos = await _context.Fgos.FindAsync(id);
            _context.Fgos.Remove(fgos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FgosExists(int id)
        {
            return _context.Fgos.Any(e => e.Id == id);
        }
    }
}
