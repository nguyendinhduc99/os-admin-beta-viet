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
    public class DanhMucVideoController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public DanhMucVideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhMucVideo
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMucVideo.OrderBy(x => x.Order).ToListAsync());
        }

        // GET: DanhMucVideo/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucVideo = await _context.DanhMucVideo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhMucVideo == null)
            {
                return NotFound();
            }

            return View(danhMucVideo);
        }

        // GET: DanhMucVideo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhMucVideo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order,Name,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DanhMucVideo danhMucVideo)
        {
            if (ModelState.IsValid)
            {
                danhMucVideo.Id = Guid.NewGuid();
                danhMucVideo.CreatedOn = danhMucVideo.ModifiedOn = DateTime.Now;
                _context.Add(danhMucVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucVideo);
        }

        // GET: DanhMucVideo/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucVideo = await _context.DanhMucVideo.FindAsync(id);
            if (danhMucVideo == null)
            {
                return NotFound();
            }
            return View(danhMucVideo);
        }

        // POST: DanhMucVideo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Order,Name,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DanhMucVideo danhMucVideo)
        {
            if (id != danhMucVideo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    danhMucVideo.ModifiedOn = DateTime.Now;
                    _context.Update(danhMucVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucVideoExists(danhMucVideo.Id))
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
            return View(danhMucVideo);
        }

        // GET: DanhMucVideo/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucVideo = await _context.DanhMucVideo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhMucVideo == null)
            {
                return NotFound();
            }

            return View(danhMucVideo);
        }

        // POST: DanhMucVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var danhMucVideo = await _context.DanhMucVideo.FindAsync(id);
            _context.DanhMucVideo.Remove(danhMucVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucVideoExists(Guid id)
        {
            return _context.DanhMucVideo.Any(e => e.Id == id);
        }
    }
}
