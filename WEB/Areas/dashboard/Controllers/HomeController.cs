using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WEB.Areas.dashboard.Controllers
{
    [Route("/dashboard")]
    [Authorize(AuthenticationSchemes = "admin")]
    public class HomeController : DashboardBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}