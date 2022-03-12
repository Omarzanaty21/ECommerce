
using WEB.ViewModels;

namespace WEB.Models
{
    public class User : BaseModel
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}