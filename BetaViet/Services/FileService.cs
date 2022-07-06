using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace BetaViet.Services
{
    public class FileService
    {
        private readonly IConfiguration _configuration;
        const long MAXIMUM_FILE_SIZE = 400000;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string filePath;
            string fileName;
            string folderBase;
                
            var dir = GetCreateMyFolder("wwwroot/uploads", out folderBase);
            System.Diagnostics.Debug.WriteLine(dir);


            //var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            //fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
            //for the file due to security reasons.
            fileName = file.FileName;
            filePath = Path.Combine(folderBase, fileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            using (var bits = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(bits);
            }

            if(file.Length > MAXIMUM_FILE_SIZE) {
                try
                {
                    ResizeImage(path);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }


            return $"{_configuration["BaseURL"]}/{folderBase.Replace("wwwroot/", "")}/{fileName}";
        }

        public void SerializeToFile<T>(string fileName, T obj)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText($@"wwwroot/vebetaviet/{fileName}"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }
        public T DeserializeToFile<T>(string fileName)
        {  
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText($@"wwwroot/vebetaviet/{fileName}"));
        }

        public static DirectoryInfo GetCreateMyFolder(string baseFolder, out string basePath)
        {
            var now = DateTime.Now;
            var yearName = now.ToString("yyyy");
            var monthName = now.ToString("MM");
            var dayName = now.ToString("dd");

            var folder = Path.Combine(baseFolder,
                           Path.Combine(yearName,
                             Path.Combine(monthName,
                               dayName)));

            basePath = folder.Replace('\\', '/');

            return Directory.CreateDirectory(folder);
        }

        public static Tuple<string, string> RenameUploadFile(string path, string oldName, string newName)
        {
            var oldPath = Path.Combine("wwwroot", path, oldName);
            var newPath = Path.Combine("wwwroot", path, newName);
            if(System.IO.File.Exists(oldPath)) { 
                System.IO.File.Move(oldPath, newPath);
                return new Tuple<string, string>(oldPath, oldPath);
            }

            return new Tuple<string, string>(oldPath, newPath);
        }

        public void ResizeImage(string path)
        {
            const int MAXIMUM_HEIGHT = 900;
            const int ESTIMATED_MINIMUM_WIDTH = 300;
            const int ESTIMATED_MAXIMUM_WIDTH = 900;
            // Load original image
            using Image image = Image.Load(path);

            // Configure encoder
            //var imageEncoder = new JpegEncoder
            //{
            //    Quality = 95,
            //    Subsample = JpegSubsample.Ratio420
            //};

            // Resize image, until it fits the desired file size and bounds
            int min = ESTIMATED_MINIMUM_WIDTH;
            int max = ESTIMATED_MAXIMUM_WIDTH;
            int bestWidth = min;
            using var tmpStream = new MemoryStream();
            while (min <= max)
            {
                // Resize image
                int width = (min + max) / 2;
                using var resizedImage = image.Clone(op =>
                {
                    op.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(width, MAXIMUM_HEIGHT)
                    });
                });

                // Compress image
                tmpStream.SetLength(0);
                resizedImage.Save(path);

                // Check file size of resized image
                if (tmpStream.Position < MAXIMUM_FILE_SIZE)
                {
                    // The current width satisfies the size constraint
                    bestWidth = width;

                    // Try to make image bigger again
                    min = width + 1;
                }
                else
                {
                    // Image is still too large, continue shrinking
                    max = width - 1;
                }
            }

            // Resize and store final image
            image.Mutate(op =>
            {
                op.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Max,
                    Size = new Size(bestWidth, MAXIMUM_HEIGHT)
                });
            });

            // Store resized image
            image.Save(path);//, imageEncoder);
        }
    }
}
