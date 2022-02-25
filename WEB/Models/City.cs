using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class City : BaseModel
    {
        public string Name {get; set;}
        public int CountryId {get; set;}
        public virtual Country Country {get; set;}
    }
}