using BetaViet.Data;
using BetaViet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Services
{
    public class TienDoThiCongService
    {
        private readonly ApplicationDbContext _context;

        public TienDoThiCongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TienDoThiCong>> getTienDoThiCongThiFor(TrangBoLoc Page)
        {
            return await _context.TienDoThiCong.Where(x => x.Page == Page).OrderBy(x => x.Order).ToListAsync();
        }
    }
}
