
using System;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;
using WEB.Services;
using WEB.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WEB.Areas.dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = "admin")]
    public class CitiesController : DashboardBaseController
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            var result = cityService.GetAllCities()
            .ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CityCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await cityService.CreateCityAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
      
    }
}