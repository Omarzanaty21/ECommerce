
namespace WEB.Interfaces
{
    public interface IPictureService
    {
        public Task<string> UploadPictureAsync( string productName, IFormFile file);
    }
}