using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetaViet.Data;
using BetaViet.Models;

namespace BetaViet.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnKienTrucController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DuAnKienTrucController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DuAnKienTruc
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DuAnKienTruc>>> GetDuAnKienTruc(int skip = 0, int take = 1000)
        {
            var list = await _context.DuAnKienTruc
                .OrderByDescending(x => x.ModifiedOn)
                .Include(x => x.NhaThietKe)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return list;
        }

        [HttpGet("random")]
        public async Task<ActionResult<IEnumerable<DuAnKienTruc>>> GetRandomDuAnNoiThat(int total = 4)
        {
            var list = await _context.DuAnKienTruc
                .OrderBy(r => Guid.NewGuid())
                .Include(x => x.NhaThietKe)
                .Take(total)
                .ToListAsync();

            return list;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetDuAnNoiThatCount()
        {
            return await _context.DuAnKienTruc
                .CountAsync();
        }

        // GET: api/DuAnKienTruc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuAnKienTruc>> GetDuAnKienTruc(Guid id)
        {
            var duAnKienTruc = await _context.DuAnKienTruc.Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe).SingleOrDefaultAsync(x => x.Id == id);

            if (duAnKienTruc == null)
            {
                return NotFound();
            }

            return duAnKienTruc;
        }

        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<DuAnKienTruc>> GetDuAnKienTrucBySlug(string slug, string id)
        {
            var duAnKienTruc = await _context.DuAnKienTruc.Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe).SingleOrDefaultAsync(x => x.Slug == slug);
            var guidId = Guid.Empty;

            if (duAnKienTruc == null && !string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id, out guidId))
                {
                    duAnKienTruc = await _context.DuAnKienTruc.Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe).SingleOrDefaultAsync(x => x.Id == guidId);
                }
            }

            if (duAnKienTruc == null)
            {
                return NotFound();
            }

            return duAnKienTruc;
        }

        [HttpGet("khu-do-thi")]
        public async Task<ActionResult<IEnumerable<DuAnKienTruc>>> GetDangThiCongTheoKhuDoThi(string s)
        {
            return await _context.DuAnKienTruc
                .Where(x => x.KhuDoThi == s)
                .OrderByDescending(x => x.ModifiedOn)
                .Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe)
                .ToListAsync();
        }

    }
}
