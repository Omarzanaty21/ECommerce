using System.IO;
using WEB.Interfaces;

namespace WEB.Services
{
    public class PictureService : IPictureService
    {
        private readonly IWebHostEnvironment env;

        public PictureService(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public async Task<string> UploadPictureAsync( string productName, IFormFile file)
        {
            var newName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);
            var pictureFullName = string.Concat(productName, newName, extension);
            var rootPath = env.WebRootPath;
            var savePath = Path.Combine(rootPath, "Uploads", "ProductPictures", pictureFullName);
            
            using (var fs = File.Create(savePath))
            {
                await file.CopyToAsync(fs);
            }

            return savePath;
        }
    }
}