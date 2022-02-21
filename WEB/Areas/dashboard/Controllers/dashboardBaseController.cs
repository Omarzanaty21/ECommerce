using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WEB.Areas.dashboard.Controllers
{
    //[Authorize]
    [Area("dashboard")]
    public class dashboardBaseController : Controller
    {
        
    }
}