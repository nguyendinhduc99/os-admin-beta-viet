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
    public class DonViThanhVienController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public DonViThanhVienController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: DonViThanhVien
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonViThanhVien.ToListAsync());
        }

        // GET: DonViThanhVien/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViThanhVien = await _context.DonViThanhVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donViThanhVien == null)
            {
                return NotFound();
            }

            return View(donViThanhVien);
        }

        // GET: DonViThanhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonViThanhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Logo,Avatar,PropertiesJSON,Id,CreatedOn,ModifiedOn,IsDeleted,SEOTitle,SEODescription,SEOText,SEOTags")] DonViThanhVien donViThanhVien)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        donViThanhVien.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                var logofile = Request.Form.Files.FirstOrDefault(x => x.Name == "Logo1");
                if (logofile != null)
                {
                    try
                    {
                        donViThanhVien.Logo = await _fileService.SaveFile(logofile);
                    }
                    catch (Exception)
                    {
                    }
                }

                donViThanhVien.Id = Guid.NewGuid();
                donViThanhVien.CreatedOn = donViThanhVien.ModifiedOn = DateTime.Now;
                _context.Add(donViThanhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donViThanhVien);
        }

        // GET: DonViThanhVien/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViThanhVien = await _context.DonViThanhVien.FindAsync(id);
            if (donViThanhVien == null)
            {
                return NotFound();
            }
            return View(donViThanhVien);
        }

        // POST: DonViThanhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Logo,Avatar,PropertiesJSON,Id,CreatedOn,ModifiedOn,IsDeleted,SEOTitle,SEODescription,SEOText,SEOTags")] DonViThanhVien donViThanhVien)
        {
            if (id != donViThanhVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                    if (avatarfile != null)
                    {
                        try
                        {
                            donViThanhVien.Avatar = await _fileService.SaveFile(avatarfile);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var logofile = Request.Form.Files.FirstOrDefault(x => x.Name == "Logo1");
                    if (logofile != null)
                    {
                        try
                        {
                            donViThanhVien.Logo = await _fileService.SaveFile(logofile);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    donViThanhVien.ModifiedOn = DateTime.Now;
                    _context.Update(donViThanhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonViThanhVienExists(donViThanhVien.Id))
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
            return View(donViThanhVien);
        }

        // GET: DonViThanhVien/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViThanhVien = await _context.DonViThanhVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donViThanhVien == null)
            {
                return NotFound();
            }

            return View(donViThanhVien);
        }

        // POST: DonViThanhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var donViThanhVien = await _context.DonViThanhVien.FindAsync(id);
            _context.DonViThanhVien.Remove(donViThanhVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonViThanhVienExists(Guid id)
        {
            return _context.DonViThanhVien.Any(e => e.Id == id);
        }
    }
}
