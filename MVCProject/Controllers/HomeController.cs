using Microsoft.AspNetCore.Mvc;
using MVCProject.ApiServices;
using MVCProject.Models.ApiModel;
using Newtonsoft.Json;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductApiService productApiService;

        public HomeController(ProductApiService productApiService)
        {
            this.productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
         
            
            return View(await this.productApiService.GetListAsync());

        }

        public async Task<IActionResult> Update(int id)
        {
           var updatedProduct =  await this.productApiService.GetByIdAsync(id);
            return View(updatedProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}