using System;
using Microsoft.AspNetCore.Mvc;
namespace WEB.Areas.dashboard.Controllers
{
    public class HomeController : dashboardBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}