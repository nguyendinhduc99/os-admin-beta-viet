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
    public class VeBetaVietController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly ApplicationDbContext _context;

        public VeBetaVietController(ApplicationDbContext context, FileService fileService)
        {
            _fileService = fileService;
            _context = context;
        }

        [HttpGet("ve-chung-toi")]
        public ActionResult<VeChungToi> GetVeChungToi()
        {
            VeChungToi obj2 = new VeChungToi();
            try
            {
                obj2 = _fileService.DeserializeToFile<VeChungToi>(VeChungToi.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("gia-tri-niem-tin")]
        public ActionResult<GiaTriNiemTin> GetGiaTriNiemTin()
        {
            GiaTriNiemTin obj2 = new GiaTriNiemTin();
            try
            {
                obj2 = _fileService.DeserializeToFile<GiaTriNiemTin>(GiaTriNiemTin.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("lich-su-phat-trien")]
        public ActionResult<LichSuPhatTrien> GetLichSuPhatTrien()
        {
            LichSuPhatTrien obj2 = new LichSuPhatTrien();
            try
            {
                obj2 = _fileService.DeserializeToFile<LichSuPhatTrien>(LichSuPhatTrien.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("co-cau-to-chuc")]
        public ActionResult<CoCauToChuc> GetCoCauToChuc()
        {
            CoCauToChuc obj2 = new CoCauToChuc();
            try
            {
                obj2 = _fileService.DeserializeToFile<CoCauToChuc>(CoCauToChuc.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("cam-nhan-khach-hang")]
        public ActionResult<CamNhanKhachHang> GetCamNhanKhachHang()
        {
            CamNhanKhachHang obj2 = new CamNhanKhachHang();
            try
            {
                obj2 = _fileService.DeserializeToFile<CamNhanKhachHang>(CamNhanKhachHang.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("bao-chi-noi")]
        public ActionResult<BaoChiNoi> GetBaoChiNoi()
        {
            BaoChiNoi obj2 = new BaoChiNoi();
            try
            {
                obj2 = _fileService.DeserializeToFile<BaoChiNoi>(BaoChiNoi.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("lan-toa-cong-dong")]
        public async Task<ActionResult<List<LanToaCongDong>>> GetLanToaCongDong()
        {
            return await _context.LanToaCongDong.ToListAsync();
        }

        [HttpGet("tuyen-dung")]
        public ActionResult<TuyenDung> GetTuyenDung()
        {
            TuyenDung obj2 = new TuyenDung();
            try
            {
                obj2 = _fileService.DeserializeToFile<TuyenDung>(TuyenDung.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("lien-he")]
        public ActionResult<LienHe> GetLienHe()
        {
            LienHe obj2 = new LienHe();
            try
            {
                obj2 = _fileService.DeserializeToFile<LienHe>(LienHe.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }
    }
}
