using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuMoTaDichVuController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuMoTaDichVuController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuMoTaDichVu obj2 = new TrangChuMoTaDichVu();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuMoTaDichVu>(TrangChuMoTaDichVu.FileName);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuMoTaDichVu obj)
        {
            try
            {
            
                _fileService.SerializeToFile<TrangChuMoTaDichVu>(TrangChuMoTaDichVu.FileName, obj);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }

            return View(obj);
        }
    }
}
