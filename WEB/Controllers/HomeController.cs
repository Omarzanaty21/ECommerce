using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGenericRepository<Product> productRepository;

    public HomeController(ILogger<HomeController> logger, IGenericRepository<Product> productRepository)
    {
        _logger = logger;
        this.productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await productRepository.GetItemsAsync();

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
