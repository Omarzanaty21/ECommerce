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

        public string ReturnPictureLocationName{get; set;}
        

        public async Task<ProductPictureFields> UploadPictureAsync( string productName, IFormFile file)
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
            ProductPictureFields productFields = new ProductPictureFields();
            productFields.SavePath = savePath;
            productFields.PictureLocationName = pictureFullName;

            // var renderPath = $"~/Uploads/ProductPictures/{pictureFullName}";
            return productFields;
        }
    }
}