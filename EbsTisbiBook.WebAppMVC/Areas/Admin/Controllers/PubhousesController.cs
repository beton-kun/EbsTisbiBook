using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EbsTisbiBook.WebAppMVC.Models;
using EbsTisbiBook.WebAppMVC.Models.Library;
using Microsoft.AspNetCore.Authorization;

namespace EbsTisbiBook.WebAppMVC.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PubhousesController : Controller
    {
        private readonly LibraryContext _context;

        public PubhousesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Pubhouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pubhouses.ToListAsync());
        }

        // GET: Pubhouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pubhouse = await _context.Pubhouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pubhouse == null)
            {
                return NotFound();
            }

            return View(pubhouse);
        }

        // GET: Pubhouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pubhouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Pubhouse pubhouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pubhouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pubhouse);
        }

        // GET: Pubhouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pubhouse = await _context.Pubhouses.FindAsync(id);
            if (pubhouse == null)
            {
                return NotFound();
            }
            return View(pubhouse);
        }

        // POST: Pubhouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Pubhouse pubhouse)
        {
            if (id != pubhouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pubhouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PubhouseExists(pubhouse.Id))
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
            return View(pubhouse);
        }

        // GET: Pubhouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pubhouse = await _context.Pubhouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pubhouse == null)
            {
                return NotFound();
            }

            return View(pubhouse);
        }

        // POST: Pubhouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pubhouse = await _context.Pubhouses.FindAsync(id);
            _context.Pubhouses.Remove(pubhouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PubhouseExists(int id)
        {
            return _context.Pubhouses.Any(e => e.Id == id);
        }
    }
}
