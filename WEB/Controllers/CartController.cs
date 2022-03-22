
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Services;
using WEB.Interfaces;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class CartController : SiteBaseController
    {
        private readonly IGenericRepository<Product> productRepsoitory;

        public CartController(IGenericRepository<Product> productRepsoitory)
        {
            this.productRepsoitory = productRepsoitory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var cartToView = SessionService.GetCartFromJson<CartItem>(HttpContext.Session, "cart");
            // ViewBag.CartView = cartToView;
            // ViewBag.CartTotalItems = cartToView.Count();

            var cartViewModel = new CartViewModel();
            cartViewModel.CartItems = cartToView;

            return View(cartViewModel);
        }
    
        [HttpGet]
        public async Task<IActionResult> AddToCart(int id)
        {
            var currentCart = SessionService.GetCartFromJson<CartItem>(HttpContext.Session, "cart");

            if(currentCart == null)
            {
                List<CartItem> cart = new List<CartItem>();

                Product selectedProduct = await productRepsoitory.GetItemByIdAsync(id);

                CartItem cartItem = new CartItem(selectedProduct);

                cart.Add(cartItem);
                
                SessionService.SetCartAsJson<CartItem>(HttpContext.Session, "cart", cart);

            }
            else
            {
                var cart = SessionService.GetCartFromJson<CartItem>(HttpContext.Session, "cart");

                bool foundElementResult = false;
                foreach(var cartItem in cart.ToList<CartItem>())
                {
                    if(cartItem.Product.Id == id)
                    {
                        cartItem.Quantity += 1;

                        foundElementResult = true;
                    }
                }

                if(foundElementResult == false)
                {
                
                    var selectedProduct = await productRepsoitory.GetItemByIdAsync(id);
                    var addedCartItem = new CartItem(selectedProduct);

                    cart.Add(addedCartItem);
                   
                }

                SessionService.SetCartAsJson<CartItem>(HttpContext.Session, "cart", cart);

            }

            return RedirectToAction("Index");   
        }
        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cart = SessionService.GetCartFromJson<CartItem>(HttpContext.Session, "cart");

            foreach(var cartItem in cart.ToList<CartItem>())
            {
                if(cartItem.Product.Id == id)
                {
                    cart.Remove(cartItem);
                }
            }

            SessionService.SetCartAsJson<CartItem>(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult IncrementCartItemQuantity(int id, int value)
        {
            var cart = SessionService.GetCartFromJson<CartItem>(HttpContext.Session, "cart");

            foreach(var cartItem in cart.ToList<CartItem>())
            {
                if(cartItem.Product.Id == id)
                {
                    cartItem.Quantity = value;
                }
            }

            SessionService.SetCartAsJson<CartItem>(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }
    }
}