using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Data;
using BetaViet.Models;
using BetaViet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetaViet.Controllers
{
    public class VeChungToiController : Controller
    {
        private readonly FileService _fileService;
        private readonly ApplicationDbContext _context;

        public VeChungToiController(ApplicationDbContext context, FileService fileService)
        {
            _fileService = fileService;
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            VeChungToi obj2 = new VeChungToi();
            try
            {
                obj2 = _fileService.DeserializeToFile<VeChungToi>(VeChungToi.FileName);
            }
            catch(Exception e)
            {
                
            }
            

            return View(obj2);
        }

        [HttpPost]
        public IActionResult Index(VeChungToi obj)
        {
            _fileService.SerializeToFile<VeChungToi>(VeChungToi.FileName, obj);
            
            return View(obj);
        }
    }
}
