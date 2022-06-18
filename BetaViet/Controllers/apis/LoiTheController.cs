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
    public class LoiTheController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly ApplicationDbContext _context;

        public LoiTheController(ApplicationDbContext context, FileService fileService)
        {
            _fileService = fileService;
            _context = context;
        }


        [HttpGet("showroom/bo-suu-tap")]
        public async Task<ActionResult<IEnumerable<LoiThe_ShowRoom_BoSuuTap>>> GetShowroomBoSuuTap(int skip = 0, int take = 1000)
        {
            var list = await _context.LoiThe_ShowRoom_BoSuuTap
                .OrderByDescending(x => x.ModifiedOn)
                .Include(x => x.NhaThietKe)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return list;
        }

        [HttpGet("main")]
        public ActionResult<LoiThe_Main> GetLoiTheMain()
        {
            LoiThe_Main obj2 = new LoiThe_Main();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_Main>(LoiThe_Main.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("quy-mo-cong-ty")]
        public ActionResult<LoiThe_QuyMoCongTy> GetLoiTheQuyMoCongTy()
        {
            LoiThe_QuyMoCongTy obj2 = new LoiThe_QuyMoCongTy();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_QuyMoCongTy>(LoiThe_QuyMoCongTy.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("nang-luc-thiet-ke")]
        public ActionResult<LoiThe_NangLucThietKe> GetLoiTheNangLucThietKe()
        {
            LoiThe_NangLucThietKe obj2 = new LoiThe_NangLucThietKe();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_NangLucThietKe>(LoiThe_NangLucThietKe.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("nang-luc-thi-cong")]
        public ActionResult<LoiThe_NangLucThiCong> GetLoiTheNangLucThiCong()
        {
            LoiThe_NangLucThiCong obj2 = new LoiThe_NangLucThiCong();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_NangLucThiCong>(LoiThe_NangLucThiCong.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("showroom-noi-that")]
        public ActionResult<LoiThe_ShowroomNoiThat> GetLoiTheShowroomNoiThat()
        {
            LoiThe_ShowroomNoiThat obj2 = new LoiThe_ShowroomNoiThat();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_ShowroomNoiThat>(LoiThe_ShowroomNoiThat.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("nha-may-san-xuat")]
        public ActionResult<LoiThe_NhaMaySanXuat> GetLoiTheNhaMaySanXuat()
        {
            LoiThe_NhaMaySanXuat obj2 = new LoiThe_NhaMaySanXuat();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_NhaMaySanXuat>(LoiThe_NhaMaySanXuat.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("cham-soc-khach-hang")]
        public ActionResult<LoiThe_ChamSocKhachHang> GetLoiTheChamSocKhachHang()
        {
            LoiThe_ChamSocKhachHang obj2 = new LoiThe_ChamSocKhachHang();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_ChamSocKhachHang>(LoiThe_ChamSocKhachHang.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("giam-sat-nghiem-ngat")]
        public ActionResult<LoiThe_GiamSatNghiemNhat> GetLoiTheGiamSatNghiemNhat()
        {
            LoiThe_GiamSatNghiemNhat obj2 = new LoiThe_GiamSatNghiemNhat();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_GiamSatNghiemNhat>(LoiThe_GiamSatNghiemNhat.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

        [HttpGet("bao-hang-uy-tin")]
        public ActionResult<LoiThe_BaoHangUyTin> GetLoiTheBaoHangUyTin()
        {
            LoiThe_BaoHangUyTin obj2 = new LoiThe_BaoHangUyTin();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_BaoHangUyTin>(LoiThe_BaoHangUyTin.FileName);
            }
            catch (Exception e)
            {
            }
            return obj2;
        }

    }
}
