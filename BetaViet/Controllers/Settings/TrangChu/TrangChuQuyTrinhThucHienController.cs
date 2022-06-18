using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuQuyTrinhThucHienController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuQuyTrinhThucHienController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuQuyTrinhThucHien obj2 = new TrangChuQuyTrinhThucHien();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuQuyTrinhThucHien>(TrangChuQuyTrinhThucHien.FileName);
            }
            catch (Exception e)
            {
                
            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuQuyTrinhThucHien obj)
        {
            try
            {

                _fileService.SerializeToFile<TrangChuQuyTrinhThucHien>(TrangChuQuyTrinhThucHien.FileName, obj);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }

            return View(obj);
        }
    
    }
}
