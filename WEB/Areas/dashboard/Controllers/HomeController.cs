using System;
using Microsoft.AspNetCore.Mvc;
namespace WEB.Areas.dashboard.Controllers
{
    [Route("/dashboard")]
    public class HomeController : DashboardBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}