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
    public class DangThiCongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DangThiCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DangThiCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DangThiCong>>> GetDangThiCong()
        {
            return await _context.DangThiCong
                .OrderByDescending(x => x.ModifiedOn)
                .ToListAsync();
        }

        [HttpGet("random")]
        public async Task<ActionResult<IEnumerable<DangThiCong>>> GetRandomDuAnNoiThat(int total = 4)
        {
            var list = await _context.DangThiCong
                .OrderBy(r => Guid.NewGuid())
                .Include(x => x.NhaThietKe)
                .Take(total)
                .ToListAsync();

            return list;
        }

        // GET: api/DangThiCong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DangThiCong>> GetDangThiCong(Guid id)
        {
            var dangThiCong = await _context.DangThiCong.SingleOrDefaultAsync(x => x.Id == id);

            if (dangThiCong == null)
            {
                return NotFound();
            }

            dangThiCong.DoiThiCongDTO = await _context.DoiThiCong.Where(x => dangThiCong.DoiThiCong.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            var donViThietKeDic = await _context.DonViThietKe.Where(x => dangThiCong.ThietKe.Select(y => y.DonViThietKeId).Contains(x.Id)).AsNoTracking().ToDictionaryAsync(x => x.Id, x => x);
            var nhaThietKeDic = await _context.NhaThietKe.Where(x => dangThiCong.ThietKe.Select(y => y.NhaThietKeId).Contains(x.Id)).AsNoTracking().ToDictionaryAsync(x => x.Id, x => x);
            dangThiCong.ThietKeDTO = dangThiCong.ThietKe.ToList();
            for (int i = 0; i < dangThiCong.ThietKeDTO.Count; i++)
            {
                dangThiCong.ThietKeDTO[i].DonViThietKe = donViThietKeDic[dangThiCong.ThietKeDTO[i].DonViThietKeId];
                dangThiCong.ThietKeDTO[i].NhaThietKe = nhaThietKeDic[dangThiCong.ThietKeDTO[i].NhaThietKeId];
            }

            return dangThiCong;
        }

        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<DangThiCong>> GetDangThiCongBySlug(string slug, string id)
        {
            var dangThiCong = await _context.DangThiCong.SingleOrDefaultAsync(x => x.Slug == slug);
            var guidId = Guid.Empty;

            if (dangThiCong == null && !string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id, out guidId))
                {
                    dangThiCong = await _context.DangThiCong.SingleOrDefaultAsync(x => x.Id == guidId);
                }
            }

            if (dangThiCong == null)
            {
                return NotFound();
            }

            dangThiCong.DoiThiCongDTO = await _context.DoiThiCong.Where(x => dangThiCong.DoiThiCong.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            var donViThietKeDic = await _context.DonViThietKe.Where(x => dangThiCong.ThietKe.Select(y => y.DonViThietKeId).Contains(x.Id)).AsNoTracking().ToDictionaryAsync(x => x.Id, x => x);
            var nhaThietKeDic = await _context.NhaThietKe.Where(x => dangThiCong.ThietKe.Select(y => y.NhaThietKeId).Contains(x.Id)).AsNoTracking().ToDictionaryAsync(x => x.Id, x => x);
            dangThiCong.ThietKeDTO = dangThiCong.ThietKe.ToList();
            for (int i = 0; i < dangThiCong.ThietKeDTO.Count; i++)
            {
                dangThiCong.ThietKeDTO[i].DonViThietKe = donViThietKeDic[dangThiCong.ThietKeDTO[i].DonViThietKeId];
                dangThiCong.ThietKeDTO[i].NhaThietKe = nhaThietKeDic[dangThiCong.ThietKeDTO[i].NhaThietKeId];
            }

            return dangThiCong;
        }

        [HttpGet("khu-do-thi")]
        public async Task<ActionResult<IEnumerable<DangThiCong>>> GetDangThiCongTheoKhuDoThi(string s)
        {
            return await _context.DangThiCong
                .Where(x => x.KhuDoThi == s)
                .OrderByDescending(x => x.ModifiedOn)
                .ToListAsync();
        }

    }
}
