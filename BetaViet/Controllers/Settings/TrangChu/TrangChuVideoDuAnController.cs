using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuVideoDuAnController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuVideoDuAnController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuVideoDuAn obj2 = new TrangChuVideoDuAn();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuVideoDuAn>(TrangChuVideoDuAn.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuVideoDuAn obj)
        {
            _fileService.SerializeToFile<TrangChuVideoDuAn>(TrangChuVideoDuAn.FileName, obj);

            return View(obj);
        }
    }
}
