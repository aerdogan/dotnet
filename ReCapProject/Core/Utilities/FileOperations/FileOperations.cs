using Microsoft.AspNetCore.Http;
using System.IO;

namespace Core.Utilities.FileOperations
{
    public static class FileOperations
    {

        public static bool WriteImageFile(IFormFile Imagefile, string filePath, string imageNewName)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), filePath, imageNewName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Imagefile.CopyTo(stream);
                }
                return true;
            }
            catch { }
            return false;
        }

        public static bool CheckImageFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
        }

        public static bool DeleteImageFile(string filePath, string fileName)
        {
            string fullPath = filePath + fileName;
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }
    }
}