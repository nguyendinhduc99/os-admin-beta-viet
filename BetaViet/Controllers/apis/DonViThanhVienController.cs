using BetaViet.Data;
using BetaViet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonViThanhVienController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonViThanhVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViThanhVien>>> GetList()
        {
            return await _context.DonViThanhVien.ToListAsync();
        }

        
    }
}
