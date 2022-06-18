using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.VeBetaViet
{
    public class GiaTriNiemTinController : Controller
    {
        private readonly FileService _fileService;

        public GiaTriNiemTinController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            GiaTriNiemTin obj2 = new GiaTriNiemTin();
            try
            {
                obj2 = _fileService.DeserializeToFile<GiaTriNiemTin>(GiaTriNiemTin.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(GiaTriNiemTin obj)
        {
            _fileService.SerializeToFile<GiaTriNiemTin>(GiaTriNiemTin.FileName, obj);

            return View(obj);
        }
    }
}
