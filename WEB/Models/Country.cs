
namespace WEB.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public virtual List<City> Cities {get; set;}
    }
}