using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.FileOperations
{
    public static class FileOperations
    {
        public static string SaveImageFile(IFormFile imageFile)
        {
            string newImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var fullPath = Path.Combine(@"wwwroot\images", newImageName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return newImageName;
        }

        public static bool DeleteImageFile(string fileName)
        {
            string fullPath = Path.Combine(@"wwwroot\images", fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }
    }
}