using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers;
[Authorize]
[AllowAnonymous]
public class HomeController : SiteBaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGenericRepository<Product> productRepository;

    public HomeController(ILogger<HomeController> logger, IGenericRepository<Product> productRepository)
    {
        _logger = logger;
        this.productRepository = productRepository;
    }
    public async Task<IActionResult> Index()
    {
        var model = await productRepository.GetItemsQuery()
        .Take(9)
        .ToListAsync();

        return View(model);
    }
 
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
