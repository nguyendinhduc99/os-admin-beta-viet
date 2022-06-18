using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuShowroomController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuShowroomController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuShowroom obj2 = new TrangChuShowroom();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuShowroom>(TrangChuShowroom.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuShowroom obj)
        {
            try
            {

                _fileService.SerializeToFile<TrangChuShowroom>(TrangChuShowroom.FileName, obj);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }

            return View(obj);
        }
    }
}
