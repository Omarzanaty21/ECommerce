using WEB.Dtos;
using WEB.ViewModels;

namespace WEB.Interfaces;

public interface IAccountService
{
    Task<AccountResultResponse> AdminPasswordSignInAsync(AdminViewModel model);
}
