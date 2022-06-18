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
    public class DanhMucBaiVietController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public DanhMucBaiVietController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhMucBaiViet
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMucBaiViet.OrderBy(x => x.Order).ToListAsync());
        }

        // GET: DanhMucBaiViet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucBaiViet = await _context.DanhMucBaiViet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhMucBaiViet == null)
            {
                return NotFound();
            }

            return View(danhMucBaiViet);
        }

        // GET: DanhMucBaiViet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhMucBaiViet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order,Name,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DanhMucBaiViet danhMucBaiViet)
        {
            if (ModelState.IsValid)
            {
                danhMucBaiViet.Id = Guid.NewGuid();
                danhMucBaiViet.CreatedOn = danhMucBaiViet.ModifiedOn = DateTime.Now;
                _context.Add(danhMucBaiViet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucBaiViet);
        }

        // GET: DanhMucBaiViet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucBaiViet = await _context.DanhMucBaiViet.FindAsync(id);
            if (danhMucBaiViet == null)
            {
                return NotFound();
            }
            return View(danhMucBaiViet);
        }

        // POST: DanhMucBaiViet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Order,Name,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DanhMucBaiViet danhMucBaiViet)
        {
            if (id != danhMucBaiViet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    danhMucBaiViet.ModifiedOn = DateTime.Now;
                    _context.Update(danhMucBaiViet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucBaiVietExists(danhMucBaiViet.Id))
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
            return View(danhMucBaiViet);
        }

        // GET: DanhMucBaiViet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucBaiViet = await _context.DanhMucBaiViet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhMucBaiViet == null)
            {
                return NotFound();
            }

            return View(danhMucBaiViet);
        }

        // POST: DanhMucBaiViet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var danhMucBaiViet = await _context.DanhMucBaiViet.FindAsync(id);
            _context.DanhMucBaiViet.Remove(danhMucBaiViet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucBaiVietExists(Guid id)
        {
            return _context.DanhMucBaiViet.Any(e => e.Id == id);
        }
    }
}
