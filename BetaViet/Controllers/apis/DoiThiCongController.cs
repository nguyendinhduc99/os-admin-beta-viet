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
    public class DoiThiCongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoiThiCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DoiThiCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoiThiCong>>> GetDoiThiCong()
        {
            var list = await _context.DoiThiCong.Include(x => x.DangThiCong).OrderByDescending(x => x.ModifiedOn).ToListAsync();
            return list;
        }

        // GET: api/DoiThiCong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoiThiCong>> GetDoiThiCong(Guid id)
        {
            var doiThiCong = await _context.DoiThiCong.Include(x => x.DangThiCong).SingleAsync(x => x.Id == id);

            if (doiThiCong == null)
            {
                return NotFound();
            }

            var list2 = await _context.DangThiCong.Where(x => x.DoiThiCongJSON.Contains(doiThiCong.Name)).ToListAsync();

            doiThiCong.DangThiCong = doiThiCong.DangThiCong.Concat(list2).ToList();

            return doiThiCong;
        }
    }
}
