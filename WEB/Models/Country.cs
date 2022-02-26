
using WEB.ViewModels;

namespace WEB.Models
{
    public class Country : BaseModel
    {
        public Country()
        {
        }

        public Country(CountryViewModel model)
        {
            Name = model.Name;
        }

        public string Name { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}