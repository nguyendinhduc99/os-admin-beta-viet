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
    public class BoLocController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BoLocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BoLoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoLoc>>> GetBoLoc(TrangBoLoc? page)
        {
            IQueryable<BoLoc> query = _context.BoLoc.OrderBy(x => x.Order);
            if(page.HasValue)
            {
                query = query.Where(x => x.Page == page);
            }
            return await query.ToListAsync();
        }

        
    }
}
