using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers
{
    public class LichSuPhatTrienController : Controller
    {
        private readonly FileService _fileService;

        public LichSuPhatTrienController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            LichSuPhatTrien obj2 = new LichSuPhatTrien();
            try
            {
                obj2 = _fileService.DeserializeToFile<LichSuPhatTrien>(LichSuPhatTrien.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(LichSuPhatTrien obj)
        {
            _fileService.SerializeToFile<LichSuPhatTrien>(LichSuPhatTrien.FileName, obj);

            return View(obj);
        }
    }
}
