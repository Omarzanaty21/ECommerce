
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Areas.dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = "admin")]
    public class ProductsController : DashboardBaseController
    {
        private readonly IGenericRepository<Product> productRepository;
        private readonly IPictureService pictureService;

        public ProductsController(IGenericRepository<Product> productRepository
        , IPictureService pictureService)
        {
            this.productRepository = productRepository;
            this.pictureService = pictureService;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var model = await productRepository.GetItemsAsync();

            return View(model);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                var product = new Product(model);
                var productPictureFields = await pictureService.UploadPictureAsync(model.Name, model.File);

                product.PicturePath = productPictureFields.SavePath;
                product.pictureLocationName = productPictureFields.PictureLocationName;

                await productRepository.AddAsync(product);

                await productRepository.Complete();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            
            var product = await productRepository.GetItemByIdAsync(id);

            var model = new ProductViewModel(product);

            return View(model);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(int id, ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                var product = await productRepository.GetItemByIdAsync(id);
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.OfferPrice = model.OfferPrice;
                product.StartOfferAt = model.StartOfferAt;
                product.EndOfferAt = model.EndOfferAt;
                product.Quantity = model.Quantity;
                product.CategoryId = model.CategoryId;

                if(model.File != null)
                {
                    System.IO.File.Delete(product.PicturePath);
                    var productPictureFields = await pictureService.UploadPictureAsync(product.Name,
                    model.File);  
                    product.PicturePath = productPictureFields.SavePath;
                    product.pictureLocationName = productPictureFields.PictureLocationName;
                } 

                await productRepository.Complete();

                return RedirectToAction("Index");
            }
           return View(model); 
        }
        [HttpPost("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            Product item =await productRepository.GetItemByIdAsync(id);
            if(item.PicturePath != null)
            {
                System.IO.File.Delete(item.PicturePath);
            }
            
            await productRepository.RemoveAsync(id);

            await productRepository.Complete();

            return RedirectToAction("Index");
        }

    }
}