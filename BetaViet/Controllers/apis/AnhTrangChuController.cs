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
    public class AnhTrangChuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnhTrangChuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AnhTrangChu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnhTrangChu>>> GetAnhTrangChu()
        {
            return await _context.AnhTrangChu.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

    }
}
