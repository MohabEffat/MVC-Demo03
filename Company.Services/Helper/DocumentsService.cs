using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public class DocumentsService
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            var foldetPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", folderName);

            var fileName = $"{Guid.NewGuid()}-{file.FileName}";

            var filePath = Path.Combine(foldetPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }

    }
}
 