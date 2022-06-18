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
    public class DonViThietKeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonViThietKeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonViThietKe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViThietKe>>> GetDonViThietKe()
        {
            return await _context.DonViThietKe.ToListAsync();
        }

        // GET: api/DonViThietKe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonViThietKe>> GetDonViThietKe(Guid id)
        {
            var donViThietKe = await _context.DonViThietKe.FindAsync(id);

            if (donViThietKe == null)
            {
                return NotFound();
            }

            return donViThietKe;
        }

        [HttpGet("{id}/du-an-tieu-bieu")]
        public async Task<ActionResult<IEnumerable<DuAnCommon>>> GetNhaThietKeDuAnTieuBieu(Guid id)
        {
            IEnumerable<DuAnNoiThat> list = await _context.DuAnNoiThat
                .Include(x => x.NhaThietKe)
                .Where(x => x.NhaThietKe != null && x.NhaThietKe.DonViThietKeId == id)
                .Take(5).ToListAsync();

            IEnumerable<DuAnKienTruc> list1 = await _context.DuAnKienTruc
                .Include(x => x.NhaThietKe)
                .Where(x => x.NhaThietKe != null && x.NhaThietKe.DonViThietKeId == id)
                .Take(5).ToListAsync();

            var doiThiCong = await _context.DonViThietKe.SingleAsync(x => x.Id == id);
            var list2 = await _context.DangThiCong.Where(x => x.ThietKeJSON.Contains(doiThiCong.Name)).ToListAsync();

            return Ok(new { noiThat = list, kienTruc = list1, dangThiCong = list2 });
        }

    }
}
