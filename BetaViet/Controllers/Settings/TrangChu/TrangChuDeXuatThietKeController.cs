using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuDeXuatThietKeController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuDeXuatThietKeController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuDeXuatThietKe obj2 = new TrangChuDeXuatThietKe();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuDeXuatThietKe>(TrangChuDeXuatThietKe.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuDeXuatThietKe obj)
        {
            _fileService.SerializeToFile<TrangChuDeXuatThietKe>(TrangChuDeXuatThietKe.FileName, obj);

            return View(obj);
        }
    }
}
