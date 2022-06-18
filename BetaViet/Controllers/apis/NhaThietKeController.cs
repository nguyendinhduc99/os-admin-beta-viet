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
    public class NhaThietKeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NhaThietKeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NhaThietKe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaThietKe>>> GetNhaThietKe()
        {
            return await _context.NhaThietKe.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

        [HttpGet("random")]
        public async Task<ActionResult<IEnumerable<NhaThietKe>>> GetRandomDuAnNoiThat(int total = 4)
        {
            var list = await _context.NhaThietKe
                .OrderBy(r => Guid.NewGuid())
                .Take(total)
                .ToListAsync();

            return list;
        }

        [HttpGet("{id}/theo-don-vi")]
        public async Task<ActionResult<IEnumerable<NhaThietKe>>> GetNhaThietKeTheoDonVi(Guid id)
        {
            return await _context.NhaThietKe.Include(x => x.DonViThanhVien).Include(x => x.DonViThietKe)
                .Where(x => x.DonViThanhVienId == id || x.DonViThietKeId == id).ToListAsync();
        }

        // GET: api/NhaThietKe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaThietKe>> GetNhaThietKe(Guid id)
        {
            var nhaThietKe = await _context.NhaThietKe
                .Include(x => x.DonViThanhVien)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (nhaThietKe == null)
            {
                return NotFound();
            }

            return nhaThietKe;
        }

        [HttpGet("{id}/du-an-tieu-bieu")]
        public async Task<ActionResult<IEnumerable<DuAnCommon>>> GetNhaThietKeDuAnTieuBieu(Guid id)
        {

            IEnumerable<DuAnNoiThat> list = await _context.DuAnNoiThat.Where(x => x.NhaThietKeId == id).Include(x => x.NhaThietKe).Take(5).ToListAsync();
            IEnumerable<DuAnKienTruc> list1 = await _context.DuAnKienTruc.Where(x => x.NhaThietKeId == id).Include(x => x.NhaThietKe).Take(5).ToListAsync();
            
            return Ok(new { noiThat = list, kienTruc = list1 });
        }

       
    }
}
