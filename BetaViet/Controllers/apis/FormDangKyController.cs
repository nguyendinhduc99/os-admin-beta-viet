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
    public class FormDangKyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FormDangKyController(ApplicationDbContext context)
        {
            _context = context;
        }


        // POST: api/FormDangKy
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FormDangKy>> PostFormDangKy(FormDangKy formDangKy)
        {
            formDangKy.Id = Guid.NewGuid();
            formDangKy.CreatedOn = formDangKy.ModifiedOn = DateTime.Now;
            _context.FormDangKy.Add(formDangKy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormDangKy", new { id = formDangKy.Id }, formDangKy);
        }

    }
}
