
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers;
public class ProductsController : SiteBaseController
{
    private readonly IGenericRepository<Product> productRepository;

    public ProductsController(IGenericRepository<Product> productRepository)
    {
        this.productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ShowProduct(int id)
    {
        var productToShow = await productRepository.GetItemsQuery()
        .Where(p => p.Id == id)
        .Include(p => p.Category)
        .ToListAsync();

        return View(productToShow);
    }
}