using System;
using System.ComponentModel.DataAnnotations;
namespace WEB.ViewModels
{
    public class CityRemoveViewModel
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}