using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.AttachementService
{
    public class AttachementService : IAttachementService
    {
        List<String> allowedExtensions = [ ".png", ".jpg", ".jpeg" ];
        const int maxSize = 5242880;

        public bool Delete(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }

        public string? Upload(IFormFile file, string FolderName)
        {
            string? extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension)) return null;

            if (file.Length == 0 || file.Length > maxSize) return null;

            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\{FolderName}";
            string? folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", FolderName);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(folderPath, fileName);

            using FileStream fs = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fs);

            return fileName;
        }
    }
}
