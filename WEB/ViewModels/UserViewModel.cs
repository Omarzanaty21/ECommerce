
using System.ComponentModel.DataAnnotations;
using WEB.Models;

namespace WEB.ViewModels
{
    public class UserViewModel : UserBaseViewModel
    {
        public UserViewModel()
        {
            
        }
        public UserViewModel(User model)
        {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Email = model.Email;
        }
    }
}