using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuThamKhaoThietKeController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuThamKhaoThietKeController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuThamKhaoThietKe obj2 = new TrangChuThamKhaoThietKe();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuThamKhaoThietKe>(TrangChuThamKhaoThietKe.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuThamKhaoThietKe obj)
        {
            _fileService.SerializeToFile<TrangChuThamKhaoThietKe>(TrangChuThamKhaoThietKe.FileName, obj);

            return View(obj);
        }
    }
}
