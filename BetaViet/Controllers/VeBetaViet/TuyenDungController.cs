using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.VeBetaViet
{
    public class TuyenDungController : Controller
    {
        private readonly FileService _fileService;

        public TuyenDungController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            TuyenDung obj2 = new TuyenDung();
            try
            {
                obj2 = _fileService.DeserializeToFile<TuyenDung>(TuyenDung.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TuyenDung obj)
        {
            _fileService.SerializeToFile<TuyenDung>(TuyenDung.FileName, obj);

            return View(obj);
        }
    }
}
