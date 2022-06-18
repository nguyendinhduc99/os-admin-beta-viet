using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuHeThongBetaController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuHeThongBetaController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuHeThongBeta obj2 = new TrangChuHeThongBeta();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuHeThongBeta>(TrangChuHeThongBeta.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuHeThongBeta obj)
        {
            _fileService.SerializeToFile<TrangChuHeThongBeta>(TrangChuHeThongBeta.FileName, obj);

            return View(obj);
        }
    }
}
