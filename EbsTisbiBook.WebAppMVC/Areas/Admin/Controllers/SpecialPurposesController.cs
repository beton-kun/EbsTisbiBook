﻿using System;
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
    public class SpecialPurposesController : Controller
    {
        private readonly LibraryContext _context;

        public SpecialPurposesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: SpecialPurposes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecialPurposes.ToListAsync());
        }

        // GET: SpecialPurposes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPurpose = await _context.SpecialPurposes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialPurpose == null)
            {
                return NotFound();
            }

            return View(specialPurpose);
        }

        // GET: SpecialPurposes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialPurposes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SpecialPurpose specialPurpose)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialPurpose);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialPurpose);
        }

        // GET: SpecialPurposes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPurpose = await _context.SpecialPurposes.FindAsync(id);
            if (specialPurpose == null)
            {
                return NotFound();
            }
            return View(specialPurpose);
        }

        // POST: SpecialPurposes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SpecialPurpose specialPurpose)
        {
            if (id != specialPurpose.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialPurpose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialPurposeExists(specialPurpose.Id))
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
            return View(specialPurpose);
        }

        // GET: SpecialPurposes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPurpose = await _context.SpecialPurposes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialPurpose == null)
            {
                return NotFound();
            }

            return View(specialPurpose);
        }

        // POST: SpecialPurposes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialPurpose = await _context.SpecialPurposes.FindAsync(id);
            _context.SpecialPurposes.Remove(specialPurpose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialPurposeExists(int id)
        {
            return _context.SpecialPurposes.Any(e => e.Id == id);
        }
    }
}
