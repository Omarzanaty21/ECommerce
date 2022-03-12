
using System.ComponentModel.DataAnnotations;
using WEB.Models;

namespace WEB.ViewModels
{
    public class UserViewModel
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}