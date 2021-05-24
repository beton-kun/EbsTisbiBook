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
    public class UgnpController : Controller
    {
        private readonly LibraryContext _context;

        public UgnpController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Ugnps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ugnp.ToListAsync());
        }

        // GET: Ugnps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugnp = await _context.Ugnp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ugnp == null)
            {
                return NotFound();
            }

            return View(ugnp);
        }

        // GET: Ugnps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ugnps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Ugnp ugnp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ugnp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ugnp);
        }

        // GET: Ugnps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugnp = await _context.Ugnp.FindAsync(id);
            if (ugnp == null)
            {
                return NotFound();
            }
            return View(ugnp);
        }

        // POST: Ugnps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Ugnp ugnp)
        {
            if (id != ugnp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ugnp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UgnpExists(ugnp.Id))
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
            return View(ugnp);
        }

        // GET: Ugnps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugnp = await _context.Ugnp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ugnp == null)
            {
                return NotFound();
            }

            return View(ugnp);
        }

        // POST: Ugnps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ugnp = await _context.Ugnp.FindAsync(id);
            _context.Ugnp.Remove(ugnp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UgnpExists(int id)
        {
            return _context.Ugnp.Any(e => e.Id == id);
        }
    }
}
