


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Areas.dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = "admin")]
    public class ShippingController : DashboardBaseController
    {
        private readonly Interfaces.IGenericRepository<Shipping> shippingRepository;

        public ShippingController(IGenericRepository<Shipping> shippingRepository)
        {
            this.shippingRepository = shippingRepository;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var result = await shippingRepository.GetItemsAsync();

            return View(result);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ShippingViewModel model)
        {
            if(ModelState.IsValid)
            {
                var shipping = new Shipping(model);

                await shippingRepository.AddAsync(shipping);

                await shippingRepository.Complete();

                return RedirectToAction("Index");

            }

            return View(model);
            
        }
        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var shipping = await shippingRepository.GetItemByIdAsync(id);

            var model = new ShippingViewModel(shipping);

            return View(model);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(int id, ShippingViewModel model)
        {
            if(ModelState.IsValid)
            {
                var shipping = await shippingRepository.GetItemByIdAsync(id);
                shipping.Name = model.Name;
                shipping.InChargeName = model.InChargeName;
                shipping.Email = model.Email;
                shipping.Lat = model.Lat;
                shipping.Lng = model.Lng;

                await shippingRepository.Complete();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await shippingRepository.RemoveAsync(id);

            await shippingRepository.Complete();

            return RedirectToAction("Index");
        }
    }
}