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
    public class PubtypesController : Controller
    {
        private readonly LibraryContext _context;

        public PubtypesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Pubtypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pubtypes.ToListAsync());
        }

        // GET: Pubtypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pubtype = await _context.Pubtypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pubtype == null)
            {
                return NotFound();
            }

            return View(pubtype);
        }

        // GET: Pubtypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pubtypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Pubtype pubtype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pubtype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pubtype);
        }

        // GET: Pubtypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pubtype = await _context.Pubtypes.FindAsync(id);
            if (pubtype == null)
            {
                return NotFound();
            }
            return View(pubtype);
        }

        // POST: Pubtypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Pubtype pubtype)
        {
            if (id != pubtype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pubtype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PubtypeExists(pubtype.Id))
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
            return View(pubtype);
        }

        // GET: Pubtypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pubtype = await _context.Pubtypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pubtype == null)
            {
                return NotFound();
            }

            return View(pubtype);
        }

        // POST: Pubtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pubtype = await _context.Pubtypes.FindAsync(id);
            _context.Pubtypes.Remove(pubtype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PubtypeExists(int id)
        {
            return _context.Pubtypes.Any(e => e.Id == id);
        }
    }
}
