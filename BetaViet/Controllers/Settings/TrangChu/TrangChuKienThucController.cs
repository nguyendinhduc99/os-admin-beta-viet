using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuKienThucController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuKienThucController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuKienThuc obj2 = new TrangChuKienThuc();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuKienThuc>(TrangChuKienThuc.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuKienThuc obj)
        {
            try
            {

                _fileService.SerializeToFile<TrangChuKienThuc>(TrangChuKienThuc.FileName, obj);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }

            return View(obj);
        }
    }
}
