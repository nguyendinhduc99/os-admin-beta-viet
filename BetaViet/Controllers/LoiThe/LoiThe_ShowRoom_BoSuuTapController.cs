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
    public class LoiThe_ShowRoom_BoSuuTapController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TienDoThiCongService _tienDoThiCongService;
        private readonly DuAnService _duAnService;

        public LoiThe_ShowRoom_BoSuuTapController(ApplicationDbContext context, TienDoThiCongService tienDoThiCongService, DuAnService duAnService)
        {
            _context = context;
            _tienDoThiCongService = tienDoThiCongService;
            _duAnService = duAnService;
        }

        // GET: LoiThe_ShowRoom_BoSuuTap
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LoiThe_ShowRoom_BoSuuTap.Include(d => d.NhaThietKe).OrderByDescending(x => x.CreatedOn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LoiThe_ShowRoom_BoSuuTap/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnNoiThat = await _context.LoiThe_ShowRoom_BoSuuTap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return View(duAnNoiThat);
        }

        // GET: LoiThe_ShowRoom_BoSuuTap/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.LoiThe_ShowRoom_BoSuuTap);
            return View();
        }

        // POST: LoiThe_ShowRoom_BoSuuTap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,ProjectInfo,IdeaDescription,TrangThaiDuAn,TienDoThiCong,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,NhaThietKeId,SEOTitle,SEODescription,SEOText,SEOTags")] LoiThe_ShowRoom_BoSuuTap duAnNoiThat)
        {
            if (ModelState.IsValid)
            {
                duAnNoiThat.Id = Guid.NewGuid();
                duAnNoiThat.CreatedOn = duAnNoiThat.ModifiedOn = DateTime.Now;
                _context.Add(duAnNoiThat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.LoiThe_ShowRoom_BoSuuTap);
            return View(duAnNoiThat);
        }

        // GET: LoiThe_ShowRoom_BoSuuTap/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnNoiThat = await _context.LoiThe_ShowRoom_BoSuuTap.FindAsync(id);
            if (duAnNoiThat == null)
            {
                return NotFound();
            }
            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.LoiThe_ShowRoom_BoSuuTap);
            return View(duAnNoiThat);
        }

        // POST: LoiThe_ShowRoom_BoSuuTap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedOn,ModifiedOn,Title,Slug,ProjectInfo,IdeaDescription,TrangThaiDuAn,TienDoThiCong,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,NhaThietKeId,SEOTitle,SEODescription,SEOText,SEOTags")] LoiThe_ShowRoom_BoSuuTap duAnNoiThat)
        {
            if (id != duAnNoiThat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //duAnNoiThat.ModifiedOn = DateTime.Now;
                    _context.Update(duAnNoiThat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoiThe_ShowRoom_BoSuuTapExists(duAnNoiThat.Id))
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
            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.LoiThe_ShowRoom_BoSuuTap);
            return View(duAnNoiThat);
        }

        // GET: LoiThe_ShowRoom_BoSuuTap/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnNoiThat = await _context.LoiThe_ShowRoom_BoSuuTap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return View(duAnNoiThat);
        }

        // POST: LoiThe_ShowRoom_BoSuuTap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var duAnNoiThat = await _context.LoiThe_ShowRoom_BoSuuTap.FindAsync(id);
            _context.LoiThe_ShowRoom_BoSuuTap.Remove(duAnNoiThat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoiThe_ShowRoom_BoSuuTapExists(Guid id)
        {
            return _context.LoiThe_ShowRoom_BoSuuTap.Any(e => e.Id == id);
        }
    }
}
