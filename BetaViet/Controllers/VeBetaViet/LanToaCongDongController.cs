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
    public class LanToaCongDongController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public LanToaCongDongController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: LanToaCongDong
        public async Task<IActionResult> Index()
        {
            return View(await _context.LanToaCongDong.ToListAsync());
        }

        // GET: LanToaCongDong/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanToaCongDong = await _context.LanToaCongDong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanToaCongDong == null)
            {
                return NotFound();
            }

            return View(lanToaCongDong);
        }

        // GET: LanToaCongDong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LanToaCongDong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Avatar,Description,Content,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] LanToaCongDong lanToaCongDong)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        lanToaCongDong.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                lanToaCongDong.Id = Guid.NewGuid();
                lanToaCongDong.CreatedOn = lanToaCongDong.ModifiedOn = DateTime.Now;
                _context.Add(lanToaCongDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lanToaCongDong);
        }

        // GET: LanToaCongDong/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanToaCongDong = await _context.LanToaCongDong.FindAsync(id);
            if (lanToaCongDong == null)
            {
                return NotFound();
            }
            return View(lanToaCongDong);
        }

        // POST: LanToaCongDong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Avatar,Description,Content,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] LanToaCongDong lanToaCongDong)
        {
            if (id != lanToaCongDong.Id)
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
                        lanToaCongDong.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    _context.Update(lanToaCongDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanToaCongDongExists(lanToaCongDong.Id))
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
            return View(lanToaCongDong);
        }

        // GET: LanToaCongDong/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanToaCongDong = await _context.LanToaCongDong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanToaCongDong == null)
            {
                return NotFound();
            }

            return View(lanToaCongDong);
        }

        // POST: LanToaCongDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lanToaCongDong = await _context.LanToaCongDong.FindAsync(id);
            _context.LanToaCongDong.Remove(lanToaCongDong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanToaCongDongExists(Guid id)
        {
            return _context.LanToaCongDong.Any(e => e.Id == id);
        }
    }
}
