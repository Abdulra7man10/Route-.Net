using GymManagmentBLL.Service.Interfaces.AttachmentService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace GymManagmentBLL.Service.Classes.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        private readonly string[] allowedExtentions = { ".jpg", ".jpeg", ".png"};
        private readonly long maxAllowedSize = 5 * 1024 * 1024; //5MB
        private readonly IWebHostEnvironment _webHost;

        public AttachmentService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public string? Upload(string folderName, IFormFile file)
        {
            try 
            {
                if (folderName is null || file is null || file.Length == 0)
                    return null;
                //1
                if (file.Length > maxAllowedSize)
                    return null;

                //2
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtentions.Contains(extension))
                    return null;

                //3
                var folderPath = Path.Combine(_webHost.WebRootPath, "images", folderName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //4
                var fileName = Guid.NewGuid().ToString() + extension;

                //5
                var filePath = Path.Combine(folderPath, fileName);

                //6
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //7
                    file.CopyTo(stream);
                }

                //8
                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File Upload Failed = {folderName}: {ex}");
                return null;
            }
        }

        public bool Delete(string fileName, string folderName)
        {
            try 
            {
                if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folderName))
                    return false;

                var FullPath = Path.Combine(_webHost.WebRootPath, "images", folderName, fileName);
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File Delete Failed = {fileName}: {ex}");
                return false;
            }
        }

    }
}
