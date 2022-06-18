using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Controllers
{
    public class CoCauToChucController : Controller
    {
        private readonly FileService _fileService;

        public CoCauToChucController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            CoCauToChuc obj2 = new CoCauToChuc();
            try
            {
                obj2 = _fileService.DeserializeToFile<CoCauToChuc>(CoCauToChuc.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(CoCauToChuc obj)
        {
            _fileService.SerializeToFile<CoCauToChuc>(CoCauToChuc.FileName, obj);

            return View(obj);
        }
    }
}
