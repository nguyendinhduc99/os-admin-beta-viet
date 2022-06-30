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
    public class DuAnKienTrucController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly DuAnService _duAnService;

        public DuAnKienTrucController(ApplicationDbContext context, DuAnService duAnService)
        {
            _context = context;
            _duAnService = duAnService;
        }

        // GET: DuAnKienTruc
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DuAnKienTruc.Include(d => d.NhaThietKe).OrderByDescending(x => x.CreatedOn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DuAnKienTruc/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnKienTruc = await _context.DuAnKienTruc
                .Include(d => d.NhaThietKe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duAnKienTruc == null)
            {
                return NotFound();
            }

            return View(duAnKienTruc);
        }

        // GET: DuAnKienTruc/Create
        public IActionResult Create()
        {
            //ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name");
            return View();
        }

        // POST: DuAnKienTruc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrangThaiDuAn,TienDoThiCong,NhaThietKeId,Title,Slug,ProjectInfo,IdeaDescription,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,Id,CreatedOn,ModifiedOn,IsDeleted,SEOTitle,SEODescription,SEOText,SEOTags,KhuDoThi,SoLuotTruyCap")] DuAnKienTruc duAnKienTruc)
        {
            if (ModelState.IsValid)
            {
                duAnKienTruc.Id = Guid.NewGuid();
                duAnKienTruc.CreatedOn = duAnKienTruc.ModifiedOn = DateTime.Now;
                _context.Add(duAnKienTruc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", duAnKienTruc.NhaThietKeId);
            return View(duAnKienTruc);
        }

        // GET: DuAnKienTruc/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnKienTruc = await _context.DuAnKienTruc.FindAsync(id);
            if (duAnKienTruc == null)
            {
                return NotFound();
            }
            //ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", duAnKienTruc.NhaThietKeId);
            return View(duAnKienTruc);
        }

        // POST: DuAnKienTruc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrangThaiDuAn,TienDoThiCong,NhaThietKeId,Title,Slug,ProjectInfo,IdeaDescription,AvatarsJSON,PropertiesJSON,FiltersJSON,ImageSectionsJSON,Id,CreatedOn,ModifiedOn,IsDeleted,SEOTitle,SEODescription,SEOText,SEOTags,KhuDoThi,SoLuotTruyCap")] DuAnKienTruc duAnKienTruc)
        {
            if (id != duAnKienTruc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //duAnKienTruc.ModifiedOn = DateTime.Now;
                    _context.Update(duAnKienTruc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuAnKienTrucExists(duAnKienTruc.Id))
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
            //ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", duAnKienTruc.NhaThietKeId);
            return View(duAnKienTruc);
        }

        // GET: DuAnKienTruc/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duAnKienTruc = await _context.DuAnKienTruc
                .Include(d => d.NhaThietKe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duAnKienTruc == null)
            {
                return NotFound();
            }

            return View(duAnKienTruc);
        }

        // POST: DuAnKienTruc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var duAnKienTruc = await _context.DuAnKienTruc.FindAsync(id);
            _context.DuAnKienTruc.Remove(duAnKienTruc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuAnKienTrucExists(Guid id)
        {
            return _context.DuAnKienTruc.Any(e => e.Id == id);
        }

        public async Task<IActionResult> _ChangeImageLinks()
        {
           //var prefix = "https://localhost:44308/";
           var prefix = "https://betaviet.com.vn:8082/";

           var message = "";
            
           foreach (var item in await _context.DuAnKienTruc.ToListAsync())
           {
               try
               {
               var avatars = item.Avatars;
               for (var i = 0; i < avatars.Length; i++)
               {
                   var link = avatars[i];
                   var splits = link.Replace(prefix, "")
                       .Split("/");
                   var path = Path.Combine(splits[0..(splits.Length - 1)]);
                   var fileName = splits.Last();
                   var name = fileName.Split('.').First();
                   var extension = fileName.Split('.').Last();

                   var newName = item.Slug + "-anh-dai-dien-" + i + "." + extension;

                   Guid nameGuid;
                   if (Guid.TryParse(name, out nameGuid))
                   {
                       var (oldPath, newPath) = FileService.RenameUploadFile(path, fileName, newName);

                       avatars[i] = $"{prefix}{newPath.Replace("\\", "/").Replace("wwwroot/", "")}";
                   }
               }
               item.Avatars = avatars;

               var imageSections = item.ImageSections;
               for (var i = 0; i < imageSections.Length; i++)
               {
                   var images = imageSections[i].Images;

                   for (var j = 0; j < images.Length; j++)
                   {
                       var link = images[j].Url;
                       var splits = link.Replace(prefix, "")
                           .Split("/");
                       var path = Path.Combine(splits[0..(splits.Length - 1)]);
                       var fileName = splits.Last();
                       var name = fileName.Split('.').First();
                       var extension = fileName.Split('.').Last();

                       var newName = item.Slug + $"-{imageSections[i].Name.ToSlug()}-" + j + "." + extension;

                       Guid nameGuid;
                       if (Guid.TryParse(name, out nameGuid))
                       {
                           var (oldPath, newPath) = FileService.RenameUploadFile(path, fileName, newName);

                           images[j].Url = $"{prefix}{newPath.Replace("\\", "/").Replace("wwwroot/", "")}";
                       }
                   }
               }
               item.ImageSections = imageSections;

               _context.DuAnKienTruc.Update(item);

               await _context.SaveChangesAsync();
               }
               catch (Exception e)
               {

                   message += e.Message + "\n" + e.StackTrace + "\n" + item.Id;
               }
           }
           return Ok(message);
        }

        public async Task<IActionResult> UpdateAllSlugs()
        {
           var list = await _context.DuAnKienTruc.ToListAsync();
           foreach (var item in list)
           {
               item.Slug = await _duAnService.GetSlug(item.Title);

           }
           _context.DuAnKienTruc.UpdateRange(list);
           await _context.SaveChangesAsync();
           return View();
        }

        public async Task<IActionResult> RemoveRedundantDashInSlugs()
        {
           var list = await _context.DuAnKienTruc.ToListAsync();
           foreach (var item in list)
           {
               item.Slug = item.Slug.Replace("--", "-");

           }
           _context.DuAnKienTruc.UpdateRange(list);
           await _context.SaveChangesAsync();
           return View();
        }
    }
}
