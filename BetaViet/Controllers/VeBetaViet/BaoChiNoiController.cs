using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers.VeBetaViet
{
    public class BaoChiNoiController : Controller
    {
        private readonly FileService _fileService;
        public BaoChiNoiController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            BaoChiNoi obj2 = new BaoChiNoi();
            try
            {
                obj2 = _fileService.DeserializeToFile<BaoChiNoi>(BaoChiNoi.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(BaoChiNoi obj)
        {
            _fileService.SerializeToFile<BaoChiNoi>(BaoChiNoi.FileName, obj);

            return View(obj);
        }
    }
}
