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
    public class FormDangKyController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public FormDangKyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormDangKy
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormDangKy.ToListAsync());
        }

        //// GET: FormDangKy/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var formDangKy = await _context.FormDangKy
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (formDangKy == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(formDangKy);
        //}

        //// GET: FormDangKy/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: FormDangKy/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Email,Phone,Id,CreatedOn,ModifiedOn,IsDeleted")] FormDangKy formDangKy)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        formDangKy.Id = Guid.NewGuid();
        //        _context.Add(formDangKy);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(formDangKy);
        //}

        //// GET: FormDangKy/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var formDangKy = await _context.FormDangKy.FindAsync(id);
        //    if (formDangKy == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(formDangKy);
        //}

        //// POST: FormDangKy/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Name,Email,Phone,Id,CreatedOn,ModifiedOn,IsDeleted")] FormDangKy formDangKy)
        //{
        //    if (id != formDangKy.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(formDangKy);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FormDangKyExists(formDangKy.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(formDangKy);
        //}

        // GET: FormDangKy/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDangKy = await _context.FormDangKy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formDangKy == null)
            {
                return NotFound();
            }

            return View(formDangKy);
        }

        // POST: FormDangKy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var formDangKy = await _context.FormDangKy.FindAsync(id);
            _context.FormDangKy.Remove(formDangKy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool FormDangKyExists(Guid id)
        //{
        //    return _context.FormDangKy.Any(e => e.Id == id);
        //}
    }
}
