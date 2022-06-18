using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BetaViet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetaViet.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;

        public FilesController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> PostFile(IFormFile file)
        {
            string filePath;
            //string fileName;
            
            try
            {
                //var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                //fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                //                                                         //for the file due to security reasons.
                //filePath = Path.Combine("uploads", fileName);
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

                //using (var bits = new FileStream(path, FileMode.Create))
                //{
                //    await file.CopyToAsync(bits);
                //}
                filePath = await _fileService.SaveFile(file);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //return Ok($"/uploads/{fileName}");
            return Ok(filePath);
        }
    }
}
