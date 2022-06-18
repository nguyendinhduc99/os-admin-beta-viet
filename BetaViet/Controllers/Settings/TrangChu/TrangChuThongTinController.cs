using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuThongTinController : Controller
    {
        private readonly FileService _fileService;
        public TrangChuThongTinController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            TrangChuThongTin obj2 = new TrangChuThongTin();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuThongTin>(TrangChuThongTin.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuThongTin obj)
        {
            _fileService.SerializeToFile<TrangChuThongTin>(TrangChuThongTin.FileName, obj);

            return View(obj);
        }
    }
}
