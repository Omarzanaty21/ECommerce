using WEB.Dtos;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Interfaces;

public interface IAccountService
{
    Task<AccountResultResponse> AdminPasswordSignInAsync(AdminViewModel model);
    UserHashAndSalt HashPassword(UserViewModel model);
}
