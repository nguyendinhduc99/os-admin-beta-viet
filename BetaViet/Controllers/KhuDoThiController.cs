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
    public class KhuDoThiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public KhuDoThiController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: KhuDoThi
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhuDoThi.ToListAsync());
        }

        // GET: KhuDoThi/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuDoThi = await _context.KhuDoThi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuDoThi == null)
            {
                return NotFound();
            }

            return View(khuDoThi);
        }

        // GET: KhuDoThi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhuDoThi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedOn,ModifiedOn,IsDeleted,Avatar,Description,PropertiesJSON,FiltersJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug")] KhuDoThi khuDoThi)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        khuDoThi.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }

                khuDoThi.Id = Guid.NewGuid();
                _context.Add(khuDoThi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khuDoThi);
        }

        // GET: KhuDoThi/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuDoThi = await _context.KhuDoThi.FindAsync(id);
            if (khuDoThi == null)
            {
                return NotFound();
            }
            return View(khuDoThi);
        }

        // POST: KhuDoThi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,CreatedOn,ModifiedOn,IsDeleted,Avatar,Description,PropertiesJSON,FiltersJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug")] KhuDoThi khuDoThi)
        {
            if (id != khuDoThi.Id)
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
                        khuDoThi.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }

                try
                {
                    _context.Update(khuDoThi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuDoThiExists(khuDoThi.Id))
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
            return View(khuDoThi);
        }

        // GET: KhuDoThi/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuDoThi = await _context.KhuDoThi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuDoThi == null)
            {
                return NotFound();
            }

            return View(khuDoThi);
        }

        // POST: KhuDoThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var khuDoThi = await _context.KhuDoThi.FindAsync(id);
            _context.KhuDoThi.Remove(khuDoThi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuDoThiExists(Guid id)
        {
            return _context.KhuDoThi.Any(e => e.Id == id);
        }
    }
}
