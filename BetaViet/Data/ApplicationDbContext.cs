using System;
using System.Collections.Generic;
using System.Text;
using BetaViet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetaViet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BoLoc> BoLoc { get; set; }
        public DbSet<TienDoThiCong> TienDoThiCong { get; set; }
        public DbSet<DuAnNoiThat> DuAnNoiThat { get; set; }
        public DbSet<DuAnKienTruc> DuAnKienTruc { get; set; }
        public DbSet<DangThiCong> DangThiCong { get; set; }
        public DbSet<NhaThietKe> NhaThietKe { get; set; }
        public DbSet<DonViThietKe> DonViThietKe { get; set; }
        public DbSet<DoiThiCong> DoiThiCong { get; set; }
        public DbSet<DonViThanhVien> DonViThanhVien { get; set; }

        public DbSet<DanhMucBaiViet> DanhMucBaiViet { get; set; }
        public DbSet<BaiViet> BaiViet { get; set; }
        public DbSet<LanToaCongDong> LanToaCongDong { get; set; }

        public DbSet<DanhMucVideo> DanhMucVideo { get; set; }
        public DbSet<Video> Video { get; set; }

        public DbSet<KhuyenmaiNoiThat> KhuyenmaiNoiThat { get; set; }
        public DbSet<KhuyenmaiKienTruc> KhuyenmaiKienTruc { get; set; }
        public DbSet<BetaViet.Models.ToanCanh360NoiThat> ToanCanh360NoiThat { get; set; }
        public DbSet<BetaViet.Models.ToanCanh360KienTruc> ToanCanh360KienTruc { get; set; }

        public DbSet<SEOText> SEOText { get; set; }
        public DbSet<AnhTrangChu> AnhTrangChu { get; set; }
        public DbSet<FormDangKy> FormDangKy { get; set; }

        public DbSet<LoiThe_ShowRoom_BoSuuTap> LoiThe_ShowRoom_BoSuuTap { get; set; }

        public DbSet<KhuDoThi> KhuDoThi { get; set; }

        public DbSet<DichVuThiCong> DichVuThiCong { get; set; }

    }
}
