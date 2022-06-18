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
    public class DuAnNoiThatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DuAnNoiThatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DuAnNoiThat
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DuAnNoiThat>>> GetDuAnNoiThat(int skip = 0, int take = 1000)
        {
            var list = await _context.DuAnNoiThat
                .OrderByDescending(x => x.ModifiedOn)
                .Include(x => x.NhaThietKe)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return list;
        }

        [HttpGet("random")]
        public async Task<ActionResult<IEnumerable<DuAnNoiThat>>> GetRandomDuAnNoiThat(int total = 4)
        {
            var list = await _context.DuAnNoiThat
                .OrderBy(r => Guid.NewGuid())
                .Include(x => x.NhaThietKe)
                .Take(total)
                .ToListAsync();

            return list;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetDuAnNoiThatCount()
        {
            return await _context.DuAnNoiThat
                .CountAsync();
        }

        // GET: api/DuAnNoiThat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuAnNoiThat>> GetDuAnNoiThat(Guid id)
        {
            var duAnNoiThat = await _context.DuAnNoiThat.Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe).SingleOrDefaultAsync(x => x.Id == id);

            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return duAnNoiThat;
        }

        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<DuAnNoiThat>> GetDuAnNoiThatBySlug(string slug, string id)
        {
            var duAnNoiThat = await _context.DuAnNoiThat.Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe).SingleOrDefaultAsync(x => x.Slug == slug);
            var guidId = Guid.Empty;
            
            if(duAnNoiThat == null && !string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id, out guidId))
                {
                    duAnNoiThat = await _context.DuAnNoiThat.Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe).SingleOrDefaultAsync(x => x.Id == guidId);
                }
                
            }

            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return duAnNoiThat;
        }

        [HttpGet("khu-do-thi")]
        public async Task<ActionResult<IEnumerable<DuAnNoiThat>>> GetDangThiCongTheoKhuDoThi(string s)
        {
            return await _context.DuAnNoiThat
                .Where(x => x.KhuDoThi == s)
                .OrderByDescending(x => x.ModifiedOn)
                .Include(x => x.NhaThietKe).ThenInclude(x => x.DonViThietKe)
                .ToListAsync();
        }

    }
}
