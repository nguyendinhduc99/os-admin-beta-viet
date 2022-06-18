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
    public class KhuyenmaiNoiThatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KhuyenmaiNoiThatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KhuyenmaiNoiThat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuyenmaiNoiThat>>> GetKhuyenmaiNoiThat()
        {
            return await _context.KhuyenmaiNoiThat.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

    }
}
