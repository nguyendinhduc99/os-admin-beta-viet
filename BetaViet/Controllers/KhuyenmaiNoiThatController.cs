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
    public class KhuyenmaiNoiThatController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public KhuyenmaiNoiThatController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: KhuyenmaiNoiThat
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhuyenmaiNoiThat.OrderByDescending(x => x.CreatedOn).ToListAsync());
        }

        // GET: KhuyenmaiNoiThat/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmaiNoiThat = await _context.KhuyenmaiNoiThat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuyenmaiNoiThat == null)
            {
                return NotFound();
            }

            return View(khuyenmaiNoiThat);
        }

        // GET: KhuyenmaiNoiThat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhuyenmaiNoiThat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Avatar,Description,Link,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] KhuyenmaiNoiThat khuyenmaiNoiThat)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        khuyenmaiNoiThat.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                khuyenmaiNoiThat.Id = Guid.NewGuid();
                khuyenmaiNoiThat.CreatedOn = khuyenmaiNoiThat.ModifiedOn = DateTime.Now;
                _context.Add(khuyenmaiNoiThat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khuyenmaiNoiThat);
        }

        // GET: KhuyenmaiNoiThat/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmaiNoiThat = await _context.KhuyenmaiNoiThat.FindAsync(id);
            if (khuyenmaiNoiThat == null)
            {
                return NotFound();
            }
            return View(khuyenmaiNoiThat);
        }

        // POST: KhuyenmaiNoiThat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Avatar,Description,Link,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] KhuyenmaiNoiThat khuyenmaiNoiThat)
        {
            if (id != khuyenmaiNoiThat.Id)
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
                        khuyenmaiNoiThat.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    khuyenmaiNoiThat.ModifiedOn = DateTime.Now;
                    _context.Update(khuyenmaiNoiThat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenmaiNoiThatExists(khuyenmaiNoiThat.Id))
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
            return View(khuyenmaiNoiThat);
        }

        // GET: KhuyenmaiNoiThat/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmaiNoiThat = await _context.KhuyenmaiNoiThat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuyenmaiNoiThat == null)
            {
                return NotFound();
            }

            return View(khuyenmaiNoiThat);
        }

        // POST: KhuyenmaiNoiThat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var khuyenmaiNoiThat = await _context.KhuyenmaiNoiThat.FindAsync(id);
            _context.KhuyenmaiNoiThat.Remove(khuyenmaiNoiThat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenmaiNoiThatExists(Guid id)
        {
            return _context.KhuyenmaiNoiThat.Any(e => e.Id == id);
        }
    }
}
