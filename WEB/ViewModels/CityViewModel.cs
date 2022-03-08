using System;
using WEB.Models;

namespace WEB.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel()
        {
        }

        public CityViewModel(City model)
        {
            Name = model.Name;
        }

        public string Name { get; set; }
        public int CountryId {get; set;}
    }
}