using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.Settings.TrangChu
{
    public class TrangChuThamQuanCongTrinhController : Controller
    {
        private readonly FileService _fileService;
        public TrangChuThamQuanCongTrinhController(FileService fileService)
        {
            _fileService = fileService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            TrangChuThamQuanCongTrinh obj2 = new TrangChuThamQuanCongTrinh();
            try
            {
                obj2 = _fileService.DeserializeToFile<TrangChuThamQuanCongTrinh>(TrangChuThamQuanCongTrinh.FileName);
            }
            catch (Exception e)
            {

            }


            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(TrangChuThamQuanCongTrinh obj)
        {
            _fileService.SerializeToFile<TrangChuThamQuanCongTrinh>(TrangChuThamQuanCongTrinh.FileName, obj);

            return View(obj);
        }
    }
}
