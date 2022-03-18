
namespace WEB.Interfaces
{
    public interface IPictureService
    {
        public Task<ProductPictureFields> UploadPictureAsync( string productName, IFormFile file);
    }
}