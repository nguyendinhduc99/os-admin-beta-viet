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
    public class ToanCanh360NoiThatController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public ToanCanh360NoiThatController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: ToanCanh360NoiThat
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToanCanh360NoiThat.OrderByDescending(x => x.CreatedOn).ToListAsync());
        }

        // GET: ToanCanh360NoiThat/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toanCanh360NoiThat = await _context.ToanCanh360NoiThat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toanCanh360NoiThat == null)
            {
                return NotFound();
            }

            return View(toanCanh360NoiThat);
        }

        // GET: ToanCanh360NoiThat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToanCanh360NoiThat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Avatar,Description,Anh360,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] ToanCanh360NoiThat toanCanh360NoiThat)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if (avatarfile != null)
                {
                    try
                    {
                        toanCanh360NoiThat.Avatar = await _fileService.SaveFile(avatarfile);
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
                        toanCanh360NoiThat.Anh360 = await _fileService.SaveFile(avatarfile2);
                    }
                    catch (Exception)
                    {
                    }
                }
                toanCanh360NoiThat.Id = Guid.NewGuid();
                toanCanh360NoiThat.CreatedOn = toanCanh360NoiThat.ModifiedOn = DateTime.Now;
                _context.Add(toanCanh360NoiThat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toanCanh360NoiThat);
        }

        // GET: ToanCanh360NoiThat/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toanCanh360NoiThat = await _context.ToanCanh360NoiThat.FindAsync(id);
            if (toanCanh360NoiThat == null)
            {
                return NotFound();
            }
            return View(toanCanh360NoiThat);
        }

        // POST: ToanCanh360NoiThat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Avatar,Description,Anh360,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] ToanCanh360NoiThat toanCanh360NoiThat)
        {
            if (id != toanCanh360NoiThat.Id)
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
                        toanCanh360NoiThat.Avatar = await _fileService.SaveFile(avatarfile);
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
                        toanCanh360NoiThat.Anh360 = await _fileService.SaveFile(avatarfile2);
                    }
                    catch (Exception)
                    {
                    }
                }

                try
                {
                    _context.Update(toanCanh360NoiThat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToanCanh360NoiThatExists(toanCanh360NoiThat.Id))
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
            return View(toanCanh360NoiThat);
        }

        // GET: ToanCanh360NoiThat/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toanCanh360NoiThat = await _context.ToanCanh360NoiThat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toanCanh360NoiThat == null)
            {
                return NotFound();
            }

            return View(toanCanh360NoiThat);
        }

        // POST: ToanCanh360NoiThat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var toanCanh360NoiThat = await _context.ToanCanh360NoiThat.FindAsync(id);
            _context.ToanCanh360NoiThat.Remove(toanCanh360NoiThat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToanCanh360NoiThatExists(Guid id)
        {
            return _context.ToanCanh360NoiThat.Any(e => e.Id == id);
        }
    }
}
