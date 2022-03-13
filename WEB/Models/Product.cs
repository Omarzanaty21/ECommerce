
using WEB.ViewModels;

namespace WEB.Models
{
    public class Product : BaseModel
    {
        public Product()
        {
            
        }
        public Product(ProductViewModel model)
        {
            this.Name = model.Name;
            this.Description = model.Description;
            this.Price = model.Price;
            this.OfferPrice = model.OfferPrice;
            this.StartOfferAt = model.StartOfferAt;
            this.EndOfferAt = model.EndOfferAt;
            this.Quantity = model.Quantity;
            this.CategoryId = model.CategoryId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OfferPrice { get; set; }
        public DateTime StartOfferAt { get; set; }
        public DateTime EndOfferAt { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}