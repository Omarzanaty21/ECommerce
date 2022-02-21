using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.ViewModels;

namespace WEB.Areas.dashboard.Controllers
{
    [Route("/dashboard")]
    [Authorize(AuthenticationSchemes = "admin")]
    public class AccountController : DashboardBaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home", new {area = "dashboard"});
            }
            return View();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(AdminViewModel model)
        {
            var result = await _accountService.AdminPasswordSignInAsync(model);

            if (result.Succeeded)
            {
                await HttpContext.SignInAsync("admin",result.ClaimsPrincipal,
                new AuthenticationProperties{IsPersistent = model.RememberMe});
                    
                if (!string.IsNullOrEmpty(model.ReturnUrl)) return Redirect(model.ReturnUrl);
                return RedirectToAction("Index","Home", new {area = "dashboard"});
            }

            ViewData["msg"] = "Invalid Email or Password";
            return View(model);
        }
    }
}