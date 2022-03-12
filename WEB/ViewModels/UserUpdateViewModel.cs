
using WEB.Models;

namespace WEB.ViewModels
{
    public class UserUpdateViewModel
    {
        public UserUpdateViewModel()
        {
            
        }
        public UserUpdateViewModel(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}