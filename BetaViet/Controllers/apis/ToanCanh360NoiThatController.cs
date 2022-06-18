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
    public class ToanCanh360NoiThatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToanCanh360NoiThatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ToanCanh360NoiThat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToanCanh360NoiThat>>> GetToanCanh360NoiThat()
        {
            return await _context.ToanCanh360NoiThat.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

    }
}
