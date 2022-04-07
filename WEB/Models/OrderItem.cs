
namespace WEB.Models
{
    public class OrderItem : BaseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId {get; set;}
        public virtual Order Order {get; set;}
    
    }
}