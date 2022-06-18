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
    public class BaiVietController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BaiVietController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BaiViet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaiViet>>> GetBaiViet()
        {
            return await _context.BaiViet.ToListAsync();
        }

        [HttpGet("top-5-latest")]
        public async Task<ActionResult<IEnumerable<BaiViet>>> Get5Latest()
        {
            return await _context.BaiViet
                .Include(x => x.DanhMucBaiViet)
                .Where(x => x.DanhMucBaiViet.Slug != "cau-hoi-thuong-gap")
                .OrderByDescending(x => x.ModifiedOn)
                .Take(5)
                .ToListAsync();
        }

        [HttpGet("list-by-slug/{slug}")]
        public async Task<ActionResult<IEnumerable<BaiViet>>> GetListBySlug(string slug, string id)
        {
            var duAnNoiThat = await _context.BaiViet.Include(x => x.DanhMucBaiViet).Where(x => x.DanhMucBaiViet.Slug == slug).OrderByDescending(x => x.ModifiedOn).ToListAsync();
            var guidId = Guid.Empty;

            if (duAnNoiThat.Count == 0 && !string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id, out guidId))
                {
                    duAnNoiThat = await _context.BaiViet.Include(x => x.DanhMucBaiViet).Where(x => x.DanhMucBaiVietId == guidId).OrderByDescending(x => x.ModifiedOn).ToListAsync();
                }

            }

            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return duAnNoiThat;
        }

        // GET: api/BaiViet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaiViet>> GetBaiViet(Guid id)
        {
            var baiViet = await _context.BaiViet.FindAsync(id);

            if (baiViet == null)
            {
                return NotFound();
            }

            return baiViet;
        }

        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<BaiViet>> GetBaiVietBySlug(string slug, string id)
        {
            var duAnNoiThat = await _context.BaiViet.Include(x => x.DanhMucBaiViet).SingleOrDefaultAsync(x => x.Slug == slug);
            var guidId = Guid.Empty;

            if (duAnNoiThat == null && !string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id, out guidId))
                {
                    duAnNoiThat = await _context.BaiViet.Include(x => x.DanhMucBaiViet).SingleOrDefaultAsync(x => x.Id == guidId);
                }

            }

            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return duAnNoiThat;
        }

    }
}
