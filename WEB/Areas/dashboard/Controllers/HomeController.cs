using System;
using Microsoft.AspNetCore.Mvc;
namespace WEB.Areas.dashboard.Controllers
{
    [Route("/dashboard")]
    public class HomeController : dashboardBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}