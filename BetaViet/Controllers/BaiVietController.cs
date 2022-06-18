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
    public class BaiVietController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public BaiVietController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: BaiViet
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BaiViet.Include(b => b.DanhMucBaiViet).OrderByDescending(x => x.CreatedOn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BaiViet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet = await _context.BaiViet
                .Include(b => b.DanhMucBaiViet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baiViet == null)
            {
                return NotFound();
            }

            return View(baiViet);
        }

        // GET: BaiViet/Create
        public IActionResult Create()
        {
            ViewData["DanhMucBaiVietId"] = new SelectList(_context.DanhMucBaiViet.OrderBy(x => x.Order), "Id", "Name");
            return View();
        }

        // POST: BaiViet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhMucBaiVietId,Title,Avatar,Description,Content,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        baiViet.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                baiViet.Id = Guid.NewGuid();
                baiViet.CreatedOn = baiViet.ModifiedOn = DateTime.Now;
                _context.Add(baiViet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucBaiVietId"] = new SelectList(_context.DanhMucBaiViet.OrderBy(x => x.Order), "Id", "Name", baiViet.DanhMucBaiVietId);
            return View(baiViet);
        }

        // GET: BaiViet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet = await _context.BaiViet.FindAsync(id);
            if (baiViet == null)
            {
                return NotFound();
            }
            ViewData["DanhMucBaiVietId"] = new SelectList(_context.DanhMucBaiViet.OrderBy(x => x.Order), "Id", "Name", baiViet.DanhMucBaiVietId);
            return View(baiViet);
        }

        // POST: BaiViet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DanhMucBaiVietId,Title,Avatar,Description,Content,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] BaiViet baiViet)
        {
            if (id != baiViet.Id)
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
                        baiViet.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }

                try
                {
                    
                    _context.Update(baiViet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiVietExists(baiViet.Id))
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
            ViewData["DanhMucBaiVietId"] = new SelectList(_context.DanhMucBaiViet.OrderBy(x => x.Order), "Id", "Name", baiViet.DanhMucBaiVietId);
            return View(baiViet);
        }

        // GET: BaiViet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet = await _context.BaiViet
                .Include(b => b.DanhMucBaiViet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baiViet == null)
            {
                return NotFound();
            }

            return View(baiViet);
        }

        // POST: BaiViet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var baiViet = await _context.BaiViet.FindAsync(id);
            _context.BaiViet.Remove(baiViet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaiVietExists(Guid id)
        {
            return _context.BaiViet.Any(e => e.Id == id);
        }
    }
}
