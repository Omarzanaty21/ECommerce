using WEB.Dtos;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Interfaces;

public interface IAccountService<T> where T : UserBaseModel
{
    Task<AccountResultResponse> UserPasswordSignInAsync(UserBaseViewModel model, string authenticationType);
    UserHashAndSalt HashPassword(string password);
}
