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
    public class AnhTrangChuController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public AnhTrangChuController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: AnhTrangChu
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnhTrangChu.ToListAsync());
        }

        // GET: AnhTrangChu/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anhTrangChu = await _context.AnhTrangChu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anhTrangChu == null)
            {
                return NotFound();
            }

            return View(anhTrangChu);
        }

        // GET: AnhTrangChu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnhTrangChu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Avatar,Description,Id,CreatedOn,ModifiedOn,IsDeleted")] AnhTrangChu anhTrangChu)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        anhTrangChu.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                anhTrangChu.Id = Guid.NewGuid();
                anhTrangChu.CreatedOn = anhTrangChu.ModifiedOn = DateTime.Now;
                _context.Add(anhTrangChu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anhTrangChu);
        }

        // GET: AnhTrangChu/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anhTrangChu = await _context.AnhTrangChu.FindAsync(id);
            if (anhTrangChu == null)
            {
                return NotFound();
            }
            return View(anhTrangChu);
        }

        // POST: AnhTrangChu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Avatar,Description,Id,CreatedOn,ModifiedOn,IsDeleted")] AnhTrangChu anhTrangChu)
        {
            if (id != anhTrangChu.Id)
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
                        anhTrangChu.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    anhTrangChu.ModifiedOn = DateTime.Now;
                    _context.Update(anhTrangChu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnhTrangChuExists(anhTrangChu.Id))
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
            return View(anhTrangChu);
        }

        // GET: AnhTrangChu/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anhTrangChu = await _context.AnhTrangChu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anhTrangChu == null)
            {
                return NotFound();
            }

            return View(anhTrangChu);
        }

        // POST: AnhTrangChu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var anhTrangChu = await _context.AnhTrangChu.FindAsync(id);
            _context.AnhTrangChu.Remove(anhTrangChu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnhTrangChuExists(Guid id)
        {
            return _context.AnhTrangChu.Any(e => e.Id == id);
        }
    }
}
