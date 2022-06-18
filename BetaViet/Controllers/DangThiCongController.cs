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
    public class DangThiCongController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public DangThiCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DangThiCong
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DangThiCong;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DangThiCong/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangThiCong = await _context.DangThiCong
                .Include(d => d.NhaThietKe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dangThiCong == null)
            {
                return NotFound();
            }

            return View(dangThiCong);
        }

        // GET: DangThiCong/Create
        public IActionResult Create()
        {
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name");
            return View();
        }

        // POST: DangThiCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThietKeJSON,DoiThiCongJSON,Title,ProjectInfo,IdeaDescription,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted,KhuDoThi,SoLuotTruyCap")] DangThiCong dangThiCong)
        {
            if (ModelState.IsValid)
            {
                dangThiCong.Id = Guid.NewGuid();
                dangThiCong.CreatedOn = dangThiCong.ModifiedOn = DateTime.Now;
                _context.Add(dangThiCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", dangThiCong.NhaThietKeId);
            return View(dangThiCong);
        }

        // GET: DangThiCong/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangThiCong = await _context.DangThiCong.FindAsync(id);
            if (dangThiCong == null)
            {
                return NotFound();
            }
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", dangThiCong.NhaThietKeId);
            return View(dangThiCong);
        }

        // POST: DangThiCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ThietKeJSON,DoiThiCongJSON,Title,ProjectInfo,IdeaDescription,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted,KhuDoThi,SoLuotTruyCap")] DangThiCong dangThiCong)
        {
            if (id != dangThiCong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangThiCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangThiCongExists(dangThiCong.Id))
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
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", dangThiCong.NhaThietKeId);
            return View(dangThiCong);
        }

        // GET: DangThiCong/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangThiCong = await _context.DangThiCong
                .Include(d => d.NhaThietKe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dangThiCong == null)
            {
                return NotFound();
            }

            return View(dangThiCong);
        }

        // POST: DangThiCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dangThiCong = await _context.DangThiCong.FindAsync(id);
            _context.DangThiCong.Remove(dangThiCong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangThiCongExists(Guid id)
        {
            return _context.DangThiCong.Any(e => e.Id == id);
        }
    }
}
