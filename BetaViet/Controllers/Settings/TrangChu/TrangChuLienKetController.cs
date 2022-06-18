using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuLienKetController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuLienKetController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuLienKet obj2 = new TrangChuLienKet();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuLienKet>(TrangChuLienKet.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuLienKet obj)
        {
            try
            {

                _fileService.SerializeToFile<TrangChuLienKet>(TrangChuLienKet.FileName, obj);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }

            return View(obj);
        }
    }
}
