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
    public class DonViThietKeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public DonViThietKeController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: DonViThietKe
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonViThietKe.ToListAsync());
        }

        // GET: DonViThietKe/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViThietKe = await _context.DonViThietKe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donViThietKe == null)
            {
                return NotFound();
            }

            return View(donViThietKe);
        }

        // GET: DonViThietKe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonViThietKe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Address,Description,Avatar,PropertiesJSON,FiltersJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DonViThietKe donViThietKe)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        donViThietKe.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                donViThietKe.Id = Guid.NewGuid();
                donViThietKe.CreatedOn = DateTime.Now;
                _context.Add(donViThietKe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donViThietKe);
        }

        // GET: DonViThietKe/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViThietKe = await _context.DonViThietKe.FindAsync(id);
            if (donViThietKe == null)
            {
                return NotFound();
            }
            return View(donViThietKe);
        }

        // POST: DonViThietKe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Phone,Address,Description,Avatar,PropertiesJSON,FiltersJSON,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DonViThietKe donViThietKe)
        {
            if (id != donViThietKe.Id)
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
                        donViThietKe.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    donViThietKe.ModifiedOn = DateTime.Now;
                    _context.Update(donViThietKe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonViThietKeExists(donViThietKe.Id))
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
            return View(donViThietKe);
        }

        // GET: DonViThietKe/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViThietKe = await _context.DonViThietKe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donViThietKe == null)
            {
                return NotFound();
            }

            return View(donViThietKe);
        }

        // POST: DonViThietKe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var donViThietKe = await _context.DonViThietKe.FindAsync(id);
            _context.DonViThietKe.Remove(donViThietKe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonViThietKeExists(Guid id)
        {
            return _context.DonViThietKe.Any(e => e.Id == id);
        }
    }
}
