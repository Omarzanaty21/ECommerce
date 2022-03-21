

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class CategoriesController : SiteBaseController
    {
        private readonly IGenericRepository<Category> categoryRepository;

        public CategoriesController(IGenericRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ShowCategory(int id)
        {
            var category = await categoryRepository.
            GetItemsQuery()
            .Where(c => c.Id == id)
            .Include(c => c.Products)
            .ToListAsync();

            return View(category);
        }
    }
}