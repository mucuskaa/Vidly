﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace Vidly.Controllers
{
    public class ChairsController : Controller
    {
        private readonly UniDbContext _context;

        public ChairsController(UniDbContext context)
        {
            _context = context;
        }

        // GET: Chairs
        public async Task<IActionResult> Index(int? id)
        {
            IEnumerable<Chair> chairs = (id.HasValue) ?
                await _context.Chairs
                .Where(c => c.Faculty != null && c.Faculty.Id == id)
                .ToListAsync() :
                await _context.Chairs.ToListAsync();

            return View(chairs);
        }

        // GET: Chairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // GET: Chairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chair);
        }

        // GET: Chairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chairs.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Chair chair)
        {
            if (id != chair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChairExists(chair.Id))
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
            return View(chair);
        }

        // GET: Chairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chair = await _context.Chairs.FindAsync(id);
            if (chair != null)
            {
                _context.Chairs.Remove(chair);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChairExists(int id)
        {
            return _context.Chairs.Any(e => e.Id == id);
        }
    }
}
