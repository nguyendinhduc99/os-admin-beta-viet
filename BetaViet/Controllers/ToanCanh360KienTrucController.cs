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
    public class ToanCanh360KienTrucController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public ToanCanh360KienTrucController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: ToanCanh360KienTruc
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToanCanh360KienTruc.OrderByDescending(x => x.CreatedOn).ToListAsync());
        }

        // GET: ToanCanh360KienTruc/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toanCanh360KienTruc = await _context.ToanCanh360KienTruc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toanCanh360KienTruc == null)
            {
                return NotFound();
            }

            return View(toanCanh360KienTruc);
        }

        // GET: ToanCanh360KienTruc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToanCanh360KienTruc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Avatar,Description,Anh360,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] ToanCanh360KienTruc toanCanh360KienTruc)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        toanCanh360KienTruc.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }

                var avatarfile2 = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar2");
                if (avatarfile2 != null)
                {
                    try
                    {
                        toanCanh360KienTruc.Anh360 = await _fileService.SaveFile(avatarfile2);
                    }
                    catch (Exception)
                    {
                    }
                }
                toanCanh360KienTruc.Id = Guid.NewGuid();
                toanCanh360KienTruc.CreatedOn = toanCanh360KienTruc.ModifiedOn = DateTime.Now;
                _context.Add(toanCanh360KienTruc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toanCanh360KienTruc);
        }

        // GET: ToanCanh360KienTruc/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toanCanh360KienTruc = await _context.ToanCanh360KienTruc.FindAsync(id);
            if (toanCanh360KienTruc == null)
            {
                return NotFound();
            }
            return View(toanCanh360KienTruc);
        }

        // POST: ToanCanh360KienTruc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Avatar,Description,Anh360,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] ToanCanh360KienTruc toanCanh360KienTruc)
        {
            if (id != toanCanh360KienTruc.Id)
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
                        toanCanh360KienTruc.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                var avatarfile2 = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar2");
                if (avatarfile2 != null)
                {
                    try
                    {
                        toanCanh360KienTruc.Anh360 = await _fileService.SaveFile(avatarfile2);
                    }
                    catch (Exception)
                    {
                    }
                }

                try
                {
                    _context.Update(toanCanh360KienTruc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToanCanh360KienTrucExists(toanCanh360KienTruc.Id))
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
            return View(toanCanh360KienTruc);
        }

        // GET: ToanCanh360KienTruc/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toanCanh360KienTruc = await _context.ToanCanh360KienTruc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toanCanh360KienTruc == null)
            {
                return NotFound();
            }

            return View(toanCanh360KienTruc);
        }

        // POST: ToanCanh360KienTruc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var toanCanh360KienTruc = await _context.ToanCanh360KienTruc.FindAsync(id);
            _context.ToanCanh360KienTruc.Remove(toanCanh360KienTruc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToanCanh360KienTrucExists(Guid id)
        {
            return _context.ToanCanh360KienTruc.Any(e => e.Id == id);
        }
    }
}
