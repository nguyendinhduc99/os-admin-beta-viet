using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetaViet.Controllers.LoiThe
{
    public class LoiTheController : Controller
    {
        private readonly FileService _fileService;
        public LoiTheController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Main()
        {
            LoiThe_Main obj2 = new LoiThe_Main();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_Main>(LoiThe_Main.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/Main.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult Main(LoiThe_Main obj)
        {
            _fileService.SerializeToFile<LoiThe_Main>(LoiThe_Main.FileName, obj);

            return View("~/Views/LoiThe/Main.cshtml", obj);
        }


        public IActionResult QuyMoCongTy()
        {
            LoiThe_QuyMoCongTy obj2 = new LoiThe_QuyMoCongTy();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_QuyMoCongTy>(LoiThe_QuyMoCongTy.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/QuyMoCongTy.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult QuyMoCongTy(LoiThe_QuyMoCongTy obj)
        {
            _fileService.SerializeToFile<LoiThe_QuyMoCongTy>(LoiThe_QuyMoCongTy.FileName, obj);

            return View("~/Views/LoiThe/QuyMoCongTy.cshtml", obj);
        }

        public IActionResult NangLucThietKe()
        {
            LoiThe_NangLucThietKe obj2 = new LoiThe_NangLucThietKe();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_NangLucThietKe>(LoiThe_NangLucThietKe.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/NangLucThietKe.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult NangLucThietKe(LoiThe_NangLucThietKe obj)
        {
            _fileService.SerializeToFile<LoiThe_NangLucThietKe>(LoiThe_NangLucThietKe.FileName, obj);

            return View("~/Views/LoiThe/NangLucThietKe.cshtml", obj);
        }

        public IActionResult NangLucThiCong()
        {
            LoiThe_NangLucThiCong obj2 = new LoiThe_NangLucThiCong();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_NangLucThiCong>(LoiThe_NangLucThiCong.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/NangLucThiCong.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult NangLucThiCong(LoiThe_NangLucThiCong obj)
        {
            _fileService.SerializeToFile<LoiThe_NangLucThiCong>(LoiThe_NangLucThiCong.FileName, obj);

            return View("~/Views/LoiThe/NangLucThiCong.cshtml", obj);
        }

        public IActionResult ShowroomNoiThat()
        {
            LoiThe_ShowroomNoiThat obj2 = new LoiThe_ShowroomNoiThat();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_ShowroomNoiThat>(LoiThe_ShowroomNoiThat.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/ShowroomNoiThat.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult ShowroomNoiThat(LoiThe_ShowroomNoiThat obj)
        {
            _fileService.SerializeToFile<LoiThe_ShowroomNoiThat>(LoiThe_ShowroomNoiThat.FileName, obj);

            return View("~/Views/LoiThe/ShowroomNoiThat.cshtml", obj);
        }

        public IActionResult NhaMaySanXuat()
        {
            LoiThe_NhaMaySanXuat obj2 = new LoiThe_NhaMaySanXuat();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_NhaMaySanXuat>(LoiThe_NhaMaySanXuat.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/NhaMaySanXuat.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult NhaMaySanXuat(LoiThe_NhaMaySanXuat obj)
        {
            _fileService.SerializeToFile<LoiThe_NhaMaySanXuat>(LoiThe_NhaMaySanXuat.FileName, obj);

            return View("~/Views/LoiThe/NhaMaySanXuat.cshtml", obj);
        }

        public IActionResult ChamSocKhachHang()
        {
            LoiThe_ChamSocKhachHang obj2 = new LoiThe_ChamSocKhachHang();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_ChamSocKhachHang>(LoiThe_ChamSocKhachHang.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/ChamSocKhachHang.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult ChamSocKhachHang(LoiThe_ChamSocKhachHang obj)
        {
            _fileService.SerializeToFile<LoiThe_ChamSocKhachHang>(LoiThe_ChamSocKhachHang.FileName, obj);

            return View("~/Views/LoiThe/ChamSocKhachHang.cshtml", obj);
        }

        public IActionResult GiamSatNghiemNhat()
        {
            LoiThe_GiamSatNghiemNhat obj2 = new LoiThe_GiamSatNghiemNhat();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_GiamSatNghiemNhat>(LoiThe_GiamSatNghiemNhat.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/GiamSatNghiemNhat.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult GiamSatNghiemNhat(LoiThe_GiamSatNghiemNhat obj)
        {
            _fileService.SerializeToFile<LoiThe_GiamSatNghiemNhat>(LoiThe_GiamSatNghiemNhat.FileName, obj);

            return View("~/Views/LoiThe/GiamSatNghiemNhat.cshtml", obj);
        }

        public IActionResult BaoHangUyTin()
        {
            LoiThe_BaoHangUyTin obj2 = new LoiThe_BaoHangUyTin();
            try
            {
                obj2 = _fileService.DeserializeToFile<LoiThe_BaoHangUyTin>(LoiThe_BaoHangUyTin.FileName);
            }
            catch (Exception e)
            {

            }

            return View("~/Views/LoiThe/BaoHangUyTin.cshtml", obj2);
        }
        [HttpPost]
        public IActionResult BaoHangUyTin(LoiThe_BaoHangUyTin obj)
        {
            _fileService.SerializeToFile<LoiThe_BaoHangUyTin>(LoiThe_BaoHangUyTin.FileName, obj);

            return View("~/Views/LoiThe/BaoHangUyTin.cshtml", obj);
        }
    }
}
