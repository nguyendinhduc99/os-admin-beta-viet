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
    public class TienDoThiCongController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public TienDoThiCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TienDoThiCong
        public async Task<IActionResult> Index()
        {
            return View(await _context.TienDoThiCong.OrderBy(x => x.Page).ThenBy(x => x.Order).ToListAsync());
        }

        // GET: TienDoThiCong/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienDoThiCong = await _context.TienDoThiCong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tienDoThiCong == null)
            {
                return NotFound();
            }

            return View(tienDoThiCong);
        }

        // GET: TienDoThiCong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TienDoThiCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,Order,Page,Id")] TienDoThiCong tienDoThiCong)
        {
            if (ModelState.IsValid)
            {
                tienDoThiCong.Id = Guid.NewGuid();
                tienDoThiCong.CreatedOn = DateTime.Now;
                _context.Add(tienDoThiCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienDoThiCong);
        }

        // GET: TienDoThiCong/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienDoThiCong = await _context.TienDoThiCong.FindAsync(id);
            if (tienDoThiCong == null)
            {
                return NotFound();
            }
            return View(tienDoThiCong);
        }

        // POST: TienDoThiCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Value,Order,Page,Id,CreatedOn")] TienDoThiCong tienDoThiCong)
        {
            if (id != tienDoThiCong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tienDoThiCong.ModifiedOn = DateTime.Now;
                    _context.Update(tienDoThiCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TienDoThiCongExists(tienDoThiCong.Id))
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
            return View(tienDoThiCong);
        }

        // GET: TienDoThiCong/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienDoThiCong = await _context.TienDoThiCong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tienDoThiCong == null)
            {
                return NotFound();
            }

            return View(tienDoThiCong);
        }

        // POST: TienDoThiCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tienDoThiCong = await _context.TienDoThiCong.FindAsync(id);
            _context.TienDoThiCong.Remove(tienDoThiCong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TienDoThiCongExists(Guid id)
        {
            return _context.TienDoThiCong.Any(e => e.Id == id);
        }
    }
}
