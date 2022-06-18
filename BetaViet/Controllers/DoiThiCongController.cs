using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetaViet.Data;
using BetaViet.Models;
using BetaViet.Services;

namespace BetaViet.Controllers
{
    public class DoiThiCongController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public DoiThiCongController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: DoiThiCong
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoiThiCong.ToListAsync());
        }

        // GET: DoiThiCong/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiThiCong = await _context.DoiThiCong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doiThiCong == null)
            {
                return NotFound();
            }

            return View(doiThiCong);
        }

        // GET: DoiThiCong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoiThiCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Address,Description,Avatar,PropertiesJSON,FiltersJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DoiThiCong doiThiCong)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        doiThiCong.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                doiThiCong.Id = Guid.NewGuid();
                doiThiCong.CreatedOn = doiThiCong.ModifiedOn = DateTime.Now;
                _context.Add(doiThiCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doiThiCong);
        }

        // GET: DoiThiCong/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiThiCong = await _context.DoiThiCong.FindAsync(id);
            if (doiThiCong == null)
            {
                return NotFound();
            }
            return View(doiThiCong);
        }

        // POST: DoiThiCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Phone,Address,Description,Avatar,PropertiesJSON,FiltersJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DoiThiCong doiThiCong)
        {
            if (id != doiThiCong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        doiThiCong.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    if (!doiThiCong.ModifiedOn.HasValue)
                        doiThiCong.ModifiedOn = DateTime.Now;
                    
                    _context.Update(doiThiCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoiThiCongExists(doiThiCong.Id))
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
            return View(doiThiCong);
        }

        // GET: DoiThiCong/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiThiCong = await _context.DoiThiCong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doiThiCong == null)
            {
                return NotFound();
            }

            return View(doiThiCong);
        }

        // POST: DoiThiCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var doiThiCong = await _context.DoiThiCong.FindAsync(id);
            _context.DoiThiCong.Remove(doiThiCong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoiThiCongExists(Guid id)
        {
            return _context.DoiThiCong.Any(e => e.Id == id);
        }
    }
}
