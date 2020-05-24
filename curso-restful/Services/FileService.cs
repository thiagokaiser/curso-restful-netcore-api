using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace curso_restful.Services
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
