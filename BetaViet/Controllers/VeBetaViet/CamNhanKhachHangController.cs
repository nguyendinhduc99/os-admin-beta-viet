using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.VeBetaViet
{
    public class CamNhanKhachHangController : Controller
    {
        private readonly FileService _fileService;
        public CamNhanKhachHangController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            CamNhanKhachHang obj2 = new CamNhanKhachHang();
            try
            {
                obj2 = _fileService.DeserializeToFile<CamNhanKhachHang>(CamNhanKhachHang.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(CamNhanKhachHang obj)
        {
            _fileService.SerializeToFile<CamNhanKhachHang>(CamNhanKhachHang.FileName, obj);

            return View(obj);
        }
    }
}
