using WEB.Models;
namespace WEB.Models
{
    public class CartItem
    {
        public CartItem()
        {
            
        }
        public CartItem(Product product, int quantity = 1)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
        public Product Product {get; set;}
        public int Quantity { get; set; }
    }
}