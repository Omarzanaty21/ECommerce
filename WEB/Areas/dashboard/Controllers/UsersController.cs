
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Areas.dashboard.Controllers
{
    public class UsersController : DashboardBaseController
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IAccountService accountService;

        public UsersController(IGenericRepository<User> userRepository, IAccountService accountService)
        {
            this.userRepository = userRepository;
            this.accountService = accountService;
        }
        
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var model = await userRepository.GetItemsAsync();

            return View(model);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            var user = accountService.CreateUser(model);
            
            await userRepository.AddAsync(user);
            await userRepository.Complete();

            return RedirectToAction("Index");
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var user = await userRepository.GetItemByIdAsync(id);
            
            var model = new UserViewModel(user);
         
            return View(model);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(UserViewModel model, int id)
        {
            if(ModelState.IsValid)
            {
                User user = await userRepository.GetItemByIdAsync(id);
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
              

                await userRepository.Complete();

                return RedirectToAction("Index");
            }
           return View(model);
        }
        [HttpPost("remove")]
        public async Task<IActionResult> Remove(int id)
        {
            await userRepository.RemoveAsync(id);

            await userRepository.Complete();

            return RedirectToAction("Index");
        }
        
        
    }
}