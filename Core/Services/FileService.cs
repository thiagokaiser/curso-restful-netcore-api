using System.IO;

namespace Core.Services
{
    public class FileService
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path + "\\Files\\teste.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}
