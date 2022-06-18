using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuLoiTheNoiBatController : Controller
    {
        private readonly FileService _fileService;

        public TrangChuLoiTheNoiBatController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            TrangChuLoiTheNoiBat obj2 = new TrangChuLoiTheNoiBat();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuLoiTheNoiBat>(TrangChuLoiTheNoiBat.FileName);
            }
            catch (Exception e)
            {
                
            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuLoiTheNoiBat obj)
        {
            try
            {

                _fileService.SerializeToFile<TrangChuLoiTheNoiBat>(TrangChuLoiTheNoiBat.FileName, obj);
            }
            catch (Exception e)
            {
                return Ok(e.Message + e.StackTrace);
            }

            return View(obj);
        }
    }
}
