

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Areas.dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = "admin")]
    public class CategoriesController : DashboardBaseController
    {
        private readonly Interfaces.IGenericRepository<Category> categoriesRepository;

        public CategoriesController(IGenericRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var model = await categoriesRepository.GetItemsAsync();

            return View(model);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var category = new Category(model);

                await categoriesRepository.AddAsync(category);

                await categoriesRepository.Complete();

                return RedirectToAction("Index");
            }
           return View(model);
        }
        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var requestedCategory = await categoriesRepository.GetItemByIdAsync(id);

            var model = new CategoryViewModel(requestedCategory);

            return View(model);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(int id, CategoryViewModel model)
        {
            var requestedCategory = await categoriesRepository.GetItemByIdAsync(id);
            requestedCategory.Name = model.Name;
            requestedCategory.ParentId = model.ParentId;
            
            await categoriesRepository.Complete();

            return RedirectToAction("Index");
        }
        [HttpPost("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await categoriesRepository.RemoveAsync(id);

            await categoriesRepository.Complete();

            return RedirectToAction("Index");
        }
    }
}