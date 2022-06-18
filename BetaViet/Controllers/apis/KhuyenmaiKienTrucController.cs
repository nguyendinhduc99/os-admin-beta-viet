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
    public class KhuyenmaiKienTrucController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KhuyenmaiKienTrucController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KhuyenmaiKienTruc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuyenmaiKienTruc>>> GetKhuyenmaiKienTruc()
        {
            return await _context.KhuyenmaiKienTruc.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

    }
}
