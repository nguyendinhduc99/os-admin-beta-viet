using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetaViet.Data;
using BetaViet.Models;
using BetaViet.Services;

namespace BetaViet.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class SEOTextsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DuAnService _duAnService;

        public SEOTextsController(ApplicationDbContext context, DuAnService duAnService)
        {
            _context = context;
            _duAnService = duAnService;
        }

        // GET: api/SEOTexts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SEOText>>> GetSEOText()
        {
            return await _context.SEOText.ToListAsync();
        }

        [HttpGet("theo-trang")]
        public async Task<ActionResult<SEOText>> GetSEOTextByPage([FromQuery]string page)
        {
            return await _context.SEOText.SingleOrDefaultAsync(x => x.Page == page);
        }

        [HttpGet("get-slug")]
        public async Task<ActionResult<string>> GetSlug([FromQuery] string title)
        {
            return await _duAnService.GetSlug(title);
        }
        [HttpGet("check-slug")]
        public async Task<ActionResult<bool>> CheckSlug([FromQuery] string slug)
        {
            return await _duAnService.CheckSlugExists(slug);
        }
    }
}
