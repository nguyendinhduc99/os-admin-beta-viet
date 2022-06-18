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
    public class KhuDoThiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KhuDoThiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KhuDoThi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuDoThi>>> GetKhuDoThi()
        {
            return await _context.KhuDoThi.ToListAsync();
        }

        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<KhuDoThi>> GetKhuDoThiBySlug(string slug)
        {
            var duAnKienTruc = await _context.KhuDoThi.SingleOrDefaultAsync(x => x.Slug == slug);
            var guidId = Guid.Empty;

            if (duAnKienTruc == null)
            {
                return NotFound();
            }

            return duAnKienTruc;
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<KhuDoThi>> GetKhuDoThiByName(string name)
        {
            var duAnKienTruc = await _context.KhuDoThi.SingleOrDefaultAsync(x => x.Name == name);
            var guidId = Guid.Empty;

            if (duAnKienTruc == null)
            {
                return NotFound();
            }

            return duAnKienTruc;
        }

    }
}
