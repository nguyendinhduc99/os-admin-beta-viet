using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetaViet.Data;
using BetaViet.Models;

namespace BetaViet.Controllers
{
    public class SEOTextsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public SEOTextsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SEOTexts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SEOText.ToListAsync());
        }

        // GET: SEOTexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sEOText = await _context.SEOText
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sEOText == null)
            {
                return NotFound();
            }

            return View(sEOText);
        }

        // GET: SEOTexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SEOTexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Text,Page")] SEOText sEOText)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sEOText);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sEOText);
        }

        // GET: SEOTexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sEOText = await _context.SEOText.FindAsync(id);
            if (sEOText == null)
            {
                return NotFound();
            }
            return View(sEOText);
        }

        // POST: SEOTexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Text,Page")] SEOText sEOText)
        {
            if (id != sEOText.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sEOText);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SEOTextExists(sEOText.Id))
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
            return View(sEOText);
        }

        // GET: SEOTexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sEOText = await _context.SEOText
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sEOText == null)
            {
                return NotFound();
            }

            return View(sEOText);
        }

        // POST: SEOTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sEOText = await _context.SEOText.FindAsync(id);
            _context.SEOText.Remove(sEOText);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SEOTextExists(int id)
        {
            return _context.SEOText.Any(e => e.Id == id);
        }
    }
}
