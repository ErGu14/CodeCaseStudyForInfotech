using Commercium.Service.Interfaces;
using Commercium.Shared.Other.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class FileService : IFileService
    {
        private readonly string _baseFolderPath;

        public FileService()
        {
            _baseFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(_baseFolderPath))
            {
                Directory.CreateDirectory(_baseFolderPath);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file, FileType fileType)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentNullException("Geçersiz dosya.");
            }

            
            var extension = Path.GetExtension(file.FileName).ToLower();
            string subFolder = fileType switch
            {
                FileType.Image => "images",
                FileType.Video => "videos",
                FileType.Document => "documents",
                _ => "other"
            };

            string folderPath = Path.Combine(_baseFolderPath, subFolder);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/uploads/{subFolder}/{fileName}";
        }
    }

}
