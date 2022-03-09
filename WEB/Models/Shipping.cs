using System.ComponentModel.DataAnnotations;
using WEB.ViewModels;

namespace WEB.Models
{
    public class Shipping : BaseModel
    {
        public Shipping()
        {
            
        }
        public Shipping(ShippingViewModel model)
        {

            this.Name = model.Name;
            this.InChargeName = model.InChargeName;
            this.Email = model.Email;
            this.Lng = model.Lng;
            this.Lat = model.Lat;
            
        }


        public string Name { get; set;}
        public string InChargeName { get; set; }
        public string Email { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
    }
}
