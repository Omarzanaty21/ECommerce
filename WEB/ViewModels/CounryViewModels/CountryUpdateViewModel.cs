using System;
using System.ComponentModel.DataAnnotations;
namespace WEB.ViewModels
{
    public class CountryUpdateViewModel
    {
        public string Name { get; set; }
        [Compare("Name")]
        public string ConfirmName {get; set;}
        public int Id { get; set; }
    }
}