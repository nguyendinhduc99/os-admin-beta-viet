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
    public class ToanCanh360KienTrucController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToanCanh360KienTrucController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ToanCanh360KienTruc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToanCanh360KienTruc>>> GetToanCanh360KienTruc()
        {
            return await _context.ToanCanh360KienTruc.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

    }
}
