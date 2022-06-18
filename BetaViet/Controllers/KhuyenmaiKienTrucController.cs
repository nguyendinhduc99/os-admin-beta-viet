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
    public class KhuyenmaiKienTrucController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public KhuyenmaiKienTrucController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: KhuyenmaiKienTruc
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhuyenmaiKienTruc.OrderByDescending(x => x.CreatedOn).ToListAsync());
        }

        // GET: KhuyenmaiKienTruc/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmaiKienTruc = await _context.KhuyenmaiKienTruc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuyenmaiKienTruc == null)
            {
                return NotFound();
            }

            return View(khuyenmaiKienTruc);
        }

        // GET: KhuyenmaiKienTruc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhuyenmaiKienTruc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Avatar,Description,Link,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] KhuyenmaiKienTruc khuyenmaiKienTruc)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        khuyenmaiKienTruc.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                khuyenmaiKienTruc.Id = Guid.NewGuid();
                khuyenmaiKienTruc.CreatedOn = khuyenmaiKienTruc.ModifiedOn = DateTime.Now;
                _context.Add(khuyenmaiKienTruc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khuyenmaiKienTruc);
        }

        // GET: KhuyenmaiKienTruc/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmaiKienTruc = await _context.KhuyenmaiKienTruc.FindAsync(id);
            if (khuyenmaiKienTruc == null)
            {
                return NotFound();
            }
            return View(khuyenmaiKienTruc);
        }

        // POST: KhuyenmaiKienTruc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Avatar,Description,Link,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] KhuyenmaiKienTruc khuyenmaiKienTruc)
        {
            if (id != khuyenmaiKienTruc.Id)
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
                        khuyenmaiKienTruc.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    khuyenmaiKienTruc.ModifiedOn = DateTime.Now;
                    _context.Update(khuyenmaiKienTruc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenmaiKienTrucExists(khuyenmaiKienTruc.Id))
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
            return View(khuyenmaiKienTruc);
        }

        // GET: KhuyenmaiKienTruc/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmaiKienTruc = await _context.KhuyenmaiKienTruc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuyenmaiKienTruc == null)
            {
                return NotFound();
            }

            return View(khuyenmaiKienTruc);
        }

        // POST: KhuyenmaiKienTruc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var khuyenmaiKienTruc = await _context.KhuyenmaiKienTruc.FindAsync(id);
            _context.KhuyenmaiKienTruc.Remove(khuyenmaiKienTruc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenmaiKienTrucExists(Guid id)
        {
            return _context.KhuyenmaiKienTruc.Any(e => e.Id == id);
        }
    }
}
