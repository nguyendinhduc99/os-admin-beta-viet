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
using System.IO;

namespace BetaViet.Controllers
{
    public class DuAnNoiThatController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly TienDoThiCongService _tienDoThiCongService;
        private readonly DuAnService _duAnService;

        public DuAnNoiThatController(ApplicationDbContext context, TienDoThiCongService tienDoThiCongService, DuAnService duAnService)
        {
            _context = context;
            _tienDoThiCongService = tienDoThiCongService;
            _duAnService = duAnService;
        }

        // GET: DuAnNoiThat
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DuAnNoiThat.Include(d => d.NhaThietKe).OrderByDescending(x => x.CreatedOn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DuAnNoiThat/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnNoiThat = await _context.DuAnNoiThat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return View(duAnNoiThat);
        }

        // GET: DuAnNoiThat/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.DuAnNoiThat);
            return View();
        }

        // POST: DuAnNoiThat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,ProjectInfo,IdeaDescription,TrangThaiDuAn,TienDoThiCong,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,NhaThietKeId,SEOTitle,SEODescription,SEOText,SEOTags,KhuDoThi,SoLuotTruyCap")] DuAnNoiThat duAnNoiThat)
        {
            if (ModelState.IsValid)
            {
                duAnNoiThat.Id = Guid.NewGuid();
                duAnNoiThat.CreatedOn = duAnNoiThat.ModifiedOn = DateTime.Now;
                _context.Add(duAnNoiThat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.DuAnNoiThat);
            return View(duAnNoiThat);
        }

        // GET: DuAnNoiThat/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnNoiThat = await _context.DuAnNoiThat.FindAsync(id);
            if (duAnNoiThat == null)
            {
                return NotFound();
            }
            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.DuAnNoiThat);
            return View(duAnNoiThat);
        }

        // POST: DuAnNoiThat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedOn,ModifiedOn,Title,Slug,ProjectInfo,IdeaDescription,TrangThaiDuAn,TienDoThiCong,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,NhaThietKeId,SEOTitle,SEODescription,SEOText,SEOTags,KhuDoThi,SoLuotTruyCap")] DuAnNoiThat duAnNoiThat)
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
                    if (!DuAnNoiThatExists(duAnNoiThat.Id))
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
            //ViewData["tienDoThiCongList"] = await _tienDoThiCongService.getTienDoThiCongThiFor(TrangBoLoc.DuAnNoiThat);
            return View(duAnNoiThat);
        }

        // GET: DuAnNoiThat/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnNoiThat = await _context.DuAnNoiThat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return View(duAnNoiThat);
        }

        // POST: DuAnNoiThat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var duAnNoiThat = await _context.DuAnNoiThat.FindAsync(id);
            _context.DuAnNoiThat.Remove(duAnNoiThat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuAnNoiThatExists(Guid id)
        {
            return _context.DuAnNoiThat.Any(e => e.Id == id);
        }

        //public async Task<IActionResult> _ChangeImageLinks()
        //{
        //    //var prefix = "https://localhost:44308/";
        //    var prefix = "https://betaviet.com.vn:8082/";

        //    foreach(var item in await _context.DuAnNoiThat.ToListAsync()) 
        //    { 
    
        //        var avatars = item.Avatars;
        //        for(var i = 0; i < avatars.Length; i++)
        //        {                    
        //            var link = avatars[i];
        //            var splits = link.Replace(prefix, "")
        //                .Split("/");
        //            var path = Path.Combine(splits[0..(splits.Length - 1)]);
        //            var fileName = splits.Last();
        //            var name = fileName.Split('.').First();
        //            var extension = fileName.Split('.').Last();

        //            var newName = item.Slug + "-anh-dai-dien-" + i + "." + extension;

        //            Guid nameGuid;
        //            if(Guid.TryParse(name, out nameGuid)) { 
        //                var (oldPath, newPath) = FileService.RenameUploadFile(path, fileName, newName);

        //                avatars[i] = $"{prefix}{newPath.Replace("\\", "/").Replace("wwwroot/", "")}";
        //            }
        //        }
        //        item.Avatars = avatars;

        //        var imageSections = item.ImageSections;
        //        for (var i = 0; i < imageSections.Length; i++)
        //        {
        //            var images = imageSections[i].Images;

        //            for(var j = 0; j < images.Length; j++) { 
        //                var link = images[j].Url;
        //                var splits = link.Replace(prefix, "")
        //                    .Split("/");
        //                var path = Path.Combine(splits[0..(splits.Length - 1)]);
        //                var fileName = splits.Last();
        //                var name = fileName.Split('.').First();
        //                var extension = fileName.Split('.').Last();

        //                var newName = item.Slug + $"-{imageSections[i].Name.ToSlug()}-" + j + "." + extension;

        //                Guid nameGuid;
        //                if (Guid.TryParse(name, out nameGuid))
        //                {
        //                    var (oldPath, newPath) = FileService.RenameUploadFile(path, fileName, newName);

        //                    images[j].Url = $"{prefix}{newPath.Replace("\\", "/").Replace("wwwroot/", "")}";
        //                }
        //            }
        //        }
        //        item.ImageSections = imageSections;
            
        //        _context.DuAnNoiThat.Update(item);

        //        await _context.SaveChangesAsync();
        //    }
        //    return Ok();
        //}

        //public async Task<IActionResult> UpdateAllSlugs()
        //{
        //    var list = await _context.DuAnNoiThat.ToListAsync();
        //    foreach(var item in list)
        //    {
        //        item.Slug = await _duAnService.GetSlug(item.Title);

        //    }
        //    _context.DuAnNoiThat.UpdateRange(list);
        //    await _context.SaveChangesAsync();
        //    return View();
        //}

        //public async Task<IActionResult> RemoveRedundantDashInSlugs()
        //{
        //    var list = await _context.DuAnNoiThat.ToListAsync();
        //    foreach (var item in list)
        //    {
        //        item.Slug = item.Slug.Replace("--", "-");

        //    }
        //    _context.DuAnNoiThat.UpdateRange(list);
        //    await _context.SaveChangesAsync();
        //    return View();
        //}
    }
}
