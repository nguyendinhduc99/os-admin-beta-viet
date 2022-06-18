using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetaViet.Data;
using BetaViet.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace BetaViet.Controllers
{
    public class DichVuThiCongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DichVuThiCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DichVuThiCong
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DichVuThiCong.Include(d => d.NhaThietKe)
                    .Select(x => new DichVuThiCong {
                        Id = x.Id,
                        CreatedOn = x.CreatedOn,
                        ModifiedOn = x.ModifiedOn,
                        Page = x.Page,
                        Title = x.Title,
                        NhaThietKe = x.NhaThietKe,
                        NhaThietKeId = x.NhaThietKeId,
                    });
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DichVuThiCong/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVuThiCong = await _context.DichVuThiCong
                .Include(d => d.NhaThietKe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dichVuThiCong == null)
            {
                return NotFound();
            }

            return View(dichVuThiCong);
        }

        // GET: DichVuThiCong/Create
        public IActionResult Create()
        {
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name");
            return View();
        }

        // POST: DichVuThiCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Page,Title,Avatar,Description,Content,NhaThietKeId,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DichVuThiCong dichVuThiCong)
        {
            if (ModelState.IsValid)
            {
                dichVuThiCong.CreatedOn = dichVuThiCong.ModifiedOn = DateTime.Now;
                dichVuThiCong.Id = Guid.NewGuid();
                _context.Add(dichVuThiCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", dichVuThiCong.NhaThietKeId);
            return View(dichVuThiCong);
        }

        // GET: DichVuThiCong/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // TODO: hotfix for large Content - remove once image is removed to external source
            var dichVuThiCong = await _context.DichVuThiCong
                .Select(x => new DichVuThiCong
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    SEOTitle = x.SEOTitle,
                    SEODescription = x.SEODescription,
                    SEOText = x.SEOText,
                    SEOTags = x.SEOTags,
                    Slug = x.Slug,
                    Page = x.Page,
                    Title = x.Title,
                    Avatar = x.Avatar,
                    NhaThietKe = x.NhaThietKe,
                    NhaThietKeId = x.NhaThietKeId,
                })
                .SingleOrDefaultAsync(x => x.Id == id);
            //var dichVuThiCong = new DichVuThiCong(); //_context.DichVuThiCong.FromSqlRaw($"SELECT * FROM [DichVuThiCong] where Id = '{id}'").FirstOrDefault();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM [DichVuThiCong] where Id = @p1";
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 60000;
                var parameter = new SqlParameter("@p1", id);
                command.Parameters.Add(parameter);

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        //dichVuThiCong.Id = (Guid)result["Id"];
                        //dichVuThiCong.CreatedOn = (DateTime)result["CreatedOn"];
                        //dichVuThiCong.ModifiedOn = (DateTime)result["ModifiedOn"];
                        //dichVuThiCong.IsDeleted = (bool)result["IsDeleted"];
                        //dichVuThiCong.SEOTitle = (result["SEOTitle"] == null) ? string.Empty : result["SEOTitle"].ToString();
                        //dichVuThiCong.SEODescription = (result["SEODescription"] == null) ? string.Empty : result["SEODescription"].ToString();
                        //dichVuThiCong.SEOText = (result["SEOText"] == null) ? string.Empty : result["SEOText"].ToString();
                        //dichVuThiCong.SEOTags = (result["SEOTags"] == null) ? string.Empty : result["SEOTags"].ToString();
                        //dichVuThiCong.Slug = (result["Slug"] == null) ? string.Empty : result["Slug"].ToString();
                        //dichVuThiCong.Page = (result["Page"] == null) ? string.Empty : result["Page"].ToString();
                        //dichVuThiCong.Title = (result["Title"] == null) ? string.Empty : result["Title"].ToString();
                        //dichVuThiCong.Avatar = (result["Avatar"] == null) ? string.Empty : result["Avatar"].ToString();
                        dichVuThiCong.Description = (result["Description"] == null) ? string.Empty : result["Description"].ToString();
                        dichVuThiCong.Content = (result["Content"] == null) ? string.Empty : result["Content"].ToString();
                        //dichVuThiCong.NhaThietKeId = (result["NhaThietKeId"] == null) ? null : (Guid?)result["NhaThietKeId"];
                    }
                }
            }

            if (dichVuThiCong == null)
            {
                return NotFound();
            }
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", dichVuThiCong.NhaThietKeId);
            return View(dichVuThiCong);
        }

        // POST: DichVuThiCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Page,Title,Avatar,Description,Content,NhaThietKeId,SEOTitle,SEODescription,SEOText,SEOTags,Slug,Id,CreatedOn,ModifiedOn,IsDeleted")] DichVuThiCong dichVuThiCong)
        {
            if (id != dichVuThiCong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichVuThiCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichVuThiCongExists(dichVuThiCong.Id))
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
            ViewData["NhaThietKeId"] = new SelectList(_context.NhaThietKe, "Id", "Name", dichVuThiCong.NhaThietKeId);
            return View(dichVuThiCong);
        }

        // GET: DichVuThiCong/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVuThiCong = await _context.DichVuThiCong
                .Include(d => d.NhaThietKe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dichVuThiCong == null)
            {
                return NotFound();
            }

            return View(dichVuThiCong);
        }

        // POST: DichVuThiCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dichVuThiCong = await _context.DichVuThiCong.FindAsync(id);
            _context.DichVuThiCong.Remove(dichVuThiCong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DichVuThiCongExists(Guid id)
        {
            return _context.DichVuThiCong.Any(e => e.Id == id);
        }
    }
}
