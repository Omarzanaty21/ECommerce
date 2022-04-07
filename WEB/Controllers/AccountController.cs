
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class AccountController : SiteBaseController
    {
        private readonly IAccountService<User> accountService;
        private readonly IGenericRepository<User> userRepository;

        public AccountController(IAccountService<User> accountService, IGenericRepository<User> userRepository)
        {
            this.accountService = accountService;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserBaseViewModel model)
        {
            if(ModelState.IsValid)
            {
                
                User user = new User(model);

                if(!string.IsNullOrEmpty(model.Password))
                {
                    var userHashAndSaLT = accountService.HashPassword(model.Password);
                    user.PasswordHash = userHashAndSaLT.PasswordHash;
                    user.PasswordSalt = userHashAndSaLT.PasswordSalt;
                }
                else
                {
                    TempData["Fail"] = "Enter all required fields";
                    return RedirectToAction("SignUp");
                }
                
                await userRepository.AddAsync(user);
                await userRepository.Complete();

                TempData["Success"] = "Please login to access denied features!";
                return RedirectToAction("SignIn");
            }
            else
            {
                TempData["Fail"] = "Please enter suitable information!";
            }   
            // todo return to fix this redirection after doing sign in
            return RedirectToAction("SignUp");
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserBaseViewModel model)
        {
            var result = await accountService.UserPasswordSignInAsync(model, "user");
            if(result.Succeeded)
            {
               await  HttpContext.SignInAsync("user", result.ClaimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Fail"] = "Please enter suitable info!";
                
                return RedirectToAction("SignIn", model);
            }
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync("user");

            return RedirectToAction("Index", "Home");
        }
    }
}