using System;
using WEB.Models;

namespace WEB.ViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
        }

        public CountryViewModel(Country model)
        {
            Name = model.Name;
        }

        public string Name { get; set; }
    }
}