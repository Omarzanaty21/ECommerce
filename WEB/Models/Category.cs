
using WEB.ViewModels;

namespace WEB.Models
{
   public class Category : BaseModel
   {
       public Category()
       {
           
       }
       public Category(CategoryViewModel model)
       {
           this.Name = model.Name;

           this.ParentId = model.ParentId;
       }
       public string Name {get; set;}

       public int ParentId {get; set;}
   } 
}