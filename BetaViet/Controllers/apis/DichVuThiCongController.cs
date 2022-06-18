using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetaViet.Data;
using BetaViet.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BetaViet.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuThiCongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DichVuThiCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DichVuThiCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DichVuThiCong>>> GetDichVuThiCong()
        {
            return await _context.DichVuThiCong.ToListAsync();
        }

        // GET: api/DichVuThiCong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DichVuThiCong>> GetDichVuThiCong(Guid id)
        {
            var dichVuThiCong = await _context.DichVuThiCong.FindAsync(id);

            if (dichVuThiCong == null)
            {
                return NotFound();
            }

            return dichVuThiCong;
        }

        [HttpGet("by-page")]
        public async Task<ActionResult<DichVuThiCong>> GetDichVuThiCongByPage(string page)
        {
            // TODO: hotfix for large Content - remove once image is removed to external source
            var dichVuThiCong = await _context.DichVuThiCong
                .Include(x => x.NhaThietKe)
                .Select(x => new DichVuThiCong
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    SEOTitle = x.SEOTitle,
                    SEODescription = x.SEODescription,
                    SEOText = x.SEOText,
                    SEOTags = x.SEOTags,
                    Slug = x.Slug,
                    Page = x.Page,
                    Title = x.Title,
                    Avatar = x.Avatar,
                    NhaThietKe = x.NhaThietKe,
                    NhaThietKeId = x.NhaThietKeId,
                })
                .SingleOrDefaultAsync(x => x.Page == page);

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM [DichVuThiCong] where Page = @p1";
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 60000;
                var parameter = new SqlParameter("@p1", page);
                command.Parameters.Add(parameter);

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        dichVuThiCong.Description = (result["Description"] == null) ? string.Empty : result["Description"].ToString();
                        dichVuThiCong.Content = (result["Content"] == null) ? string.Empty : result["Content"].ToString();
                    }
                }
            }

            //var dichVuThiCong = await _context.DichVuThiCong
            //    .Include(x => x.NhaThietKe)
            //    .SingleOrDefaultAsync(x => x.Page == page);

            if (dichVuThiCong == null)
            {
                return NotFound();
            }

            return dichVuThiCong;
        }

    }
}
