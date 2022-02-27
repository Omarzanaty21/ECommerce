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
    public class CountriesController : DashboardBaseController
    {
        private readonly IGenericRepository<Country> _countryRepository;
        public CountriesController(IGenericRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> Index()
        {
            var result = await _countryRepository.GetItemsAsync();
            
            return View(result);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CountryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var country = new Country(model);
                await _countryRepository.AddAsync(country);

                await _countryRepository.Complete();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("update/{id}")]
        public async Task<ActionResult> Update(int id)
        {  
            var country = await _countryRepository.GetItemByIdAsync(id);

            var model = new CountryViewModel(country);

            return View(model);
        }


        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(CountryViewModel model, int id)
        {
            if(ModelState.IsValid)
            {
                var country = await _countryRepository.GetItemByIdAsync(id);
                country.Name = model.Name;

                await _countryRepository.Complete();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        [HttpPost("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {  
            await _countryRepository.RemoveAsync(id);

            await _countryRepository.Complete();

            return RedirectToAction("Index");
        }

    }
}