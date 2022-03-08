using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB.ViewModels;

namespace WEB.Models
{
    public class City : BaseModel
    {
        public City()
        {
        }
        public City(CityViewModel model)
        {
            Name = model.Name;
            CountryId = model.CountryId;
        }
        public string Name {get; set;}
        [ForeignKey("Country")]
        public int CountryId {get; set;}
        public virtual Country Country {get; set;}
    }
}