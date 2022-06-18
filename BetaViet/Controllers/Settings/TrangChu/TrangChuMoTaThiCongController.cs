using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuMoTaThiCongController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuMoTaThiCongController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuMoTaThiCong obj2 = new TrangChuMoTaThiCong();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuMoTaThiCong>(TrangChuMoTaThiCong.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuMoTaThiCong obj)
        {
            _fileService.SerializeToFile<TrangChuMoTaThiCong>(TrangChuMoTaThiCong.FileName, obj);

            return View(obj);
        }
    }
}
