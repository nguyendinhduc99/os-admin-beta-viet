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
    public class NhaThietKeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly FileService _fileService;

        public NhaThietKeController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        

        // GET: NhaThietKe
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaThietKe.OrderByDescending(x => x.ModifiedOn).ToListAsync());
        }

        // GET: NhaThietKe/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaThietKe = await _context.NhaThietKe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhaThietKe == null)
            {
                return NotFound();
            }

            return View(nhaThietKe);
        }

        // GET: NhaThietKe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaThietKe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Position,Description,Avatar,PropertiesJSON,FiltersJSON,Id,CreatedOn,ModifiedOn,IsDeleted,DonViThanhVienId,DonViThietKeId")] NhaThietKe nhaThietKe)
        {
            if (ModelState.IsValid)
            {
                var avatarfile = Request.Form.Files.FirstOrDefault(x => x.Name == "Avatar1");
                if(avatarfile != null)
                {
                    try
                    {
                        nhaThietKe.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    { 
                    }
                }
                nhaThietKe.Id = Guid.NewGuid();
                nhaThietKe.CreatedOn = nhaThietKe.ModifiedOn = DateTime.Now;
                _context.Add(nhaThietKe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaThietKe);
        }

        // GET: NhaThietKe/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaThietKe = await _context.NhaThietKe.FindAsync(id);
            if (nhaThietKe == null)
            {
                return NotFound();
            }
            return View(nhaThietKe);
        }

        // POST: NhaThietKe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Position,Description,Avatar,PropertiesJSON,FiltersJSON,Id,CreatedOn,ModifiedOn,IsDeleted,DonViThanhVienId,DonViThietKeId")] NhaThietKe nhaThietKe)
        {
            if (id != nhaThietKe.Id)
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
                        nhaThietKe.Avatar = await _fileService.SaveFile(avatarfile);
                    }
                    catch (Exception)
                    {
                    }
                }

                try
                {
                    if(!nhaThietKe.ModifiedOn.HasValue)
                        nhaThietKe.ModifiedOn = DateTime.Now;

                    _context.Update(nhaThietKe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaThietKeExists(nhaThietKe.Id))
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
            return View(nhaThietKe);
        }

        // GET: NhaThietKe/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaThietKe = await _context.NhaThietKe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhaThietKe == null)
            {
                return NotFound();
            }

            return View(nhaThietKe);
        }

        // POST: NhaThietKe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var nhaThietKe = await _context.NhaThietKe.FindAsync(id);
            _context.NhaThietKe.Remove(nhaThietKe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaThietKeExists(Guid id)
        {
            return _context.NhaThietKe.Any(e => e.Id == id);
        }
    }
}
