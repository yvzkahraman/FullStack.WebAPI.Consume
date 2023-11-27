using Microsoft.AspNetCore.Mvc;
using MVCProject.Models.ApiModel;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        // TPL
        public async Task<IActionResult> Index()
        {
            // HttpClientFactory,
            //  MULTITASKING MULTITHREADING

            // Veritabanı işlemlerinde, dosya işlemlerinde, s2s call, loglama,
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5246/");
           var responseMessage =  await client.GetAsync("api/Products");


            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var data = await responseMessage.Content.ReadAsStringAsync();
            //}

            return View();


        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}