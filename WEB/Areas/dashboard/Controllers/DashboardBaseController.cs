using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WEB.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Route("/dashboard/[controller]")]
    public class DashboardBaseController : Controller
    {
        
    }
}