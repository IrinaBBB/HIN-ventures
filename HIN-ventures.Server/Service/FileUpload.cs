using System;
using System.IO;
using System.Threading.Tasks;
using HIN_ventures.Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace HIN_ventures.Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            var fileInfo = new FileInfo(file.Name);
            var fileName = Guid.NewGuid() + fileInfo.Extension;
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\code_files";
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "code_files", fileName);

            var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);

            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fs);
            }

            var fullPath = $"code_files/{fileName}";
            return fullPath;
        }


        public bool DeleteFile(string fileName)
        {
            var path = $"{_webHostEnvironment.WebRootPath}\\code_files\\{fileName}";
            if (!File.Exists(path)) return false;
            File.Delete(path);
            return true;
        }
    }
}