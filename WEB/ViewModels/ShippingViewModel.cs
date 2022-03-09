using System;
using WEB.Models;

namespace WEB.ViewModels
{
    public class ShippingViewModel
    {
        public ShippingViewModel()
        {

        }
        public ShippingViewModel(Shipping model)
        {

            Name = model.Name;
            InChargeName = model.InChargeName;
            Email = model.Email;
            Lng = model.Lng;
            Lat = model.Lat;
            
        }
        public string Name { get; set; }
        public string InChargeName { get; set; }
        public string Email { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
    }
}