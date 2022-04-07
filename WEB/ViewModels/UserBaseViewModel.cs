
using System.ComponentModel.DataAnnotations;

namespace WEB.ViewModels
{
    public class UserBaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}