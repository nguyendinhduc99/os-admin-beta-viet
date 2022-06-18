using BetaViet.Data;
using BetaViet.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Services
{
    public class DuAnService
    {
        private readonly ApplicationDbContext _context;

        public DuAnService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetSlug(string name = "")
        {
            if (string.IsNullOrEmpty(name)) return "";

            var slug = name.Replace("-", "").ToSlug();
            var existing = await CheckSlugExists(slug);
            //var kientruc = await _context.DuAnKienTruc.AnyAsync(x => x.Slug == slug);
            //var noithat = await _context.DuAnNoiThat.AnyAsync(x => x.Slug == slug);
            if (!existing)
            {
                return slug;
            }
            return $"{slug}-{StringHelper.UniqueNumber(6)}";
        }

        public async Task<bool> CheckSlugExists(string slug)
        {
            var kientruc = await _context.DuAnKienTruc.AnyAsync(x => x.Slug == slug);
            var noithat = await _context.DuAnNoiThat.AnyAsync(x => x.Slug == slug);
            if (kientruc || noithat)
            {
                return true;
            }
            return false;
        }
    }
}
