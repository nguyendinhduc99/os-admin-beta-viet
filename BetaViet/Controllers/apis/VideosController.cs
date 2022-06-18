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
    public class VideosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideo()
        {
            return await _context.Video.ToListAsync();
        }

        [HttpGet("top-5-latest")]
        public async Task<ActionResult<IEnumerable<Video>>> Get5Latest()
        {
            return await _context.Video
                .Include(x => x.DanhMucVideo)
                .OrderByDescending(x => x.ModifiedOn)
                .Take(5)
                .ToListAsync();
        }

        [HttpGet("top-5-latest-by-slug/{slug}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetListBySlug(string slug)
        {
            var duAnNoiThat = await _context.Video.Include(x => x.DanhMucVideo).Where(x => x.DanhMucVideo.Slug == slug).OrderByDescending(x => x.ModifiedOn).Take(5).ToListAsync();

            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return duAnNoiThat;
        }

        [HttpGet("list-by-slug/{slug}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetListBySlug(string slug, string id)
        {
            var duAnNoiThat = await _context.Video.Include(x => x.DanhMucVideo).Where(x => x.DanhMucVideo.Slug == slug).OrderByDescending(x => x.ModifiedOn).ToListAsync();
            var guidId = Guid.Empty;

            if (duAnNoiThat.Count == 0 && !string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id, out guidId))
                {
                    duAnNoiThat = await _context.Video.Include(x => x.DanhMucVideo).Where(x => x.DanhMucVideoId == guidId).OrderByDescending(x => x.ModifiedOn).ToListAsync();
                }

            }

            if (duAnNoiThat == null)
            {
                return NotFound();
            }

            return duAnNoiThat;
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(Guid id)
        {
            var video = await _context.Video.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }


    }
}
