using WEB.Models;
namespace WEB.Models
{
    public class CartItem
    {
        public CartItem()
        {
            
        }
        public CartItem(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.pictureLocationName = product.pictureLocationName;
            this.PicturePath = product.PicturePath;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string pictureLocationName { get; set; }
        public string PicturePath { get; set; }
        public int Quantity { get; set; } = 1;
    }
}