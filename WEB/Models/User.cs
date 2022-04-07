
using WEB.ViewModels;

namespace WEB.Models
{
    public class User :  UserBaseModel
    {
        public User()
        {
            
        }
       public User(UserViewModel model)
       {
           this.FirstName = model.FirstName;
           this.LastName = model.LastName;
           this.Email = model.Email;
       }
       public User(UserBaseViewModel model)
       {
           this.FirstName = model.FirstName;
           this.LastName = model.LastName;
           this.Email = model.Email;
       }
    }
}