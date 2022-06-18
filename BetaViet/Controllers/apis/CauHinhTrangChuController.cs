using BetaViet.Data;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauHinhTrangChuController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly ApplicationDbContext _context;

        public CauHinhTrangChuController(ApplicationDbContext context, FileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [HttpGet("banner")]
        public async Task<ActionResult<IEnumerable<AnhTrangChu>>> GetAnhTrangChu()
        {
            return await _context.AnhTrangChu.OrderByDescending(x => x.ModifiedOn).ToListAsync();
        }

        [HttpGet("thong-tin")]
        public ActionResult<TrangChuThongTin> GetTrangChuThongTin()
        {
            TrangChuThongTin obj2 = new TrangChuThongTin();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuThongTin>(TrangChuThongTin.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("mo-ta-dich-vu")]
        public ActionResult<TrangChuMoTaDichVu> GetMoTaDichVu()
        {
            TrangChuMoTaDichVu obj2 = new TrangChuMoTaDichVu();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuMoTaDichVu>(TrangChuMoTaDichVu.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("mo-ta-thi-cong")]
        public ActionResult<TrangChuMoTaThiCong> GetMoTaThiCong()
        {
            TrangChuMoTaThiCong obj2 = new TrangChuMoTaThiCong();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuMoTaThiCong>(TrangChuMoTaThiCong.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("tham-khao-thiet-ke")]
        public ActionResult<TrangChuThamKhaoThietKe> GetTrangChuThamKhaoThietKe()
        {
            TrangChuThamKhaoThietKe obj2 = new TrangChuThamKhaoThietKe();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuThamKhaoThietKe>(TrangChuThamKhaoThietKe.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("de-xuat-thiet-ke")]
        public ActionResult<TrangChuDeXuatThietKe> GetTrangChuDeXuatThietKe()
        {
            TrangChuDeXuatThietKe obj2 = new TrangChuDeXuatThietKe();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuDeXuatThietKe>(TrangChuDeXuatThietKe.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("he-thong-beta")]
        public ActionResult<TrangChuHeThongBeta> GetHeThongBeta()
        {
            TrangChuHeThongBeta obj2 = new TrangChuHeThongBeta();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuHeThongBeta>(TrangChuHeThongBeta.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("tham-quan-cong-trinh")]
        public ActionResult<TrangChuThamQuanCongTrinh> GetTrangChuThamQuanCongTrinh()
        {
            TrangChuThamQuanCongTrinh obj2 = new TrangChuThamQuanCongTrinh();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuThamQuanCongTrinh>(TrangChuThamQuanCongTrinh.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("cong-ty-thanh-vien")]
        public ActionResult<TrangChuCongTyThanhVien> GetTrangChuCongTyThanhVien()
        {
            TrangChuCongTyThanhVien obj2 = new TrangChuCongTyThanhVien();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuCongTyThanhVien>(TrangChuCongTyThanhVien.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("video-du-an")]
        public ActionResult<TrangChuVideoDuAn> GetTrangChuVideoDuAn()
        {
            TrangChuVideoDuAn obj2 = new TrangChuVideoDuAn();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuVideoDuAn>(TrangChuVideoDuAn.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("loi-the-noi-bat")]
        public ActionResult<TrangChuLoiTheNoiBat> GetTrangChuLoiTheNoiBat()
        {
            TrangChuLoiTheNoiBat obj2 = new TrangChuLoiTheNoiBat();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuLoiTheNoiBat>(TrangChuLoiTheNoiBat.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("quy-trinh-thuc-hien")]
        public ActionResult<TrangChuQuyTrinhThucHien> GetTrangChuQuyTrinhThucHien()
        {
            TrangChuQuyTrinhThucHien obj2 = new TrangChuQuyTrinhThucHien();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuQuyTrinhThucHien>(TrangChuQuyTrinhThucHien.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("showroom")]
        public ActionResult<TrangChuShowroom> GetTrangChuShowroom()
        {
            TrangChuShowroom obj2 = new TrangChuShowroom();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuShowroom>(TrangChuShowroom.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("kien-thuc")]
        public ActionResult<TrangChuKienThuc> GetTrangChuKienThuc()
        {
            TrangChuKienThuc obj2 = new TrangChuKienThuc();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuKienThuc>(TrangChuKienThuc.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        [HttpGet("lien-ket")]
        public ActionResult<TrangChuLienKet> GetTrangChuLienKet()
        {
            TrangChuLienKet obj2 = new TrangChuLienKet();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuLienKet>(TrangChuLienKet.FileName);
            }
            catch (Exception e)
            {

            }
            return obj2;
        }

        

    }
}
