using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuCongTyThanhVienController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuCongTyThanhVienController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuCongTyThanhVien obj2 = new TrangChuCongTyThanhVien();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuCongTyThanhVien>(TrangChuCongTyThanhVien.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuCongTyThanhVien obj)
        {
            _fileService.SerializeToFile<TrangChuCongTyThanhVien>(TrangChuCongTyThanhVien.FileName, obj);

            return View(obj);
        }
    }
}
