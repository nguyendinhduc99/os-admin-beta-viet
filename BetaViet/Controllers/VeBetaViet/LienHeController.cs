using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.VeBetaViet
{
    public class LienHeController : Controller
    {
        private readonly FileService _fileService;

        public LienHeController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            LienHe obj2 = new LienHe();
            try
            {
                obj2 = _fileService.DeserializeToFile<LienHe>(LienHe.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(LienHe obj)
        {
            _fileService.SerializeToFile<LienHe>(LienHe.FileName, obj);

            return View(obj);
        }
    }
}
