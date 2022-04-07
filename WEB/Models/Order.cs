
namespace WEB.Models
{
    public class Order : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal SubTotal { get; set; }
        public string ShippingCompanyName { get; set; }
        public string ShippingCountryEmail { get; set; }
        public decimal ShippingCompanyPrice { get; set; }
        public decimal Total { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public virtual List<OrderItem> Items { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public OrderStatus OrderStatus {get; set;}
    }
}