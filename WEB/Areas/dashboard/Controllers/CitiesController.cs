
using System;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;
using WEB.Services;
using WEB.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using WEB.Models;

namespace WEB.Areas.dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = "admin")]
    public class CitiesController : DashboardBaseController
    {
        private readonly IGenericRepository<City> _cityRepository;

        public CitiesController(IGenericRepository<City> cityRepository)
        {
            this._cityRepository = cityRepository;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var result =await _cityRepository.GetItemsAsync();

            return View(result);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CityViewModel model)
        {
            if(ModelState.IsValid)
            {
                var city = new City(model);

                await _cityRepository.AddAsync(city);

                await _cityRepository.Complete();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var result =await _cityRepository.GetItemByIdAsync(id);

            var model = new CityViewModel(result);

            return View(model);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(CityViewModel model ,int id)
        {
            if(ModelState.IsValid)
            {
                var city =await _cityRepository.GetItemByIdAsync(id);
                city.Name = model.Name;

                await _cityRepository.Complete();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _cityRepository.RemoveAsync(id);
            
            await _cityRepository.Complete();
            
            return RedirectToAction("Index");
        } 

    }
}