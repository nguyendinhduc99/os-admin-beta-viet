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
    public class TienDoThiCongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TienDoThiCongService _tienDoThiCongService;

        public TienDoThiCongController(ApplicationDbContext context, TienDoThiCongService tienDoThiCongService)
        {
            _context = context;
            _tienDoThiCongService = tienDoThiCongService;
        }

        // GET: api/TienDoThiCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TienDoThiCong>>> GetTienDoThiCong(TrangBoLoc boloc = TrangBoLoc.DuAnNoiThat)
        {
            return await _tienDoThiCongService.getTienDoThiCongThiFor(boloc);
        }

    }
}
