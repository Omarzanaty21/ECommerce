using System;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;
using WEB.Services;
using WEB.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using WEB.Models;


namespace WEB.Areas.dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = "admin")]
    public class CountryController : DashboardBaseController
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            var result = countryService.GetAllCountries()
            .ToList();
            return View(result);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CountryCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await countryService.CreateCountryAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet("update")]
        public IActionResult Update()
        {  
           return View();
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(CountryUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await countryService.UpdateCountryAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet("remove")]
        public async Task<IActionResult> Remove(int id)
        {  
           Country requestedCountry = await countryService.FindCountryAsync(id);
           
            var model = new CountryRemoveViewModel{
            Id = requestedCountry.Id,
            Name = requestedCountry.Name
            };
           return View(model);
        }
        [HttpPost("remove")]
        public async Task<IActionResult> Remove(CountryRemoveViewModel model)
        {  
            await countryService.RemoveCountryAsync(model);
            return RedirectToAction("Index");
        }

    }
}