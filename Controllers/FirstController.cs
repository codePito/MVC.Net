using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        private readonly string _contentRootPath;

        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, IHostEnvironment env, ProductService productService)
        {
            _logger = logger;
            _contentRootPath = env.ContentRootPath;
            _productService = productService;
        }
        public string Index()
        {
            _logger.LogWarning("Thong bao");
            _logger.LogInformation("Index Action");
            _logger.LogDebug("Thong bao");
            return "Toi la Index cua First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }
        public object Anything() => DateTime.Now;
        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban,
            cac ban dang hoc ve ASP.NET MVC

            
            AT
            ";
            return Content(content, "text/plain");
        }
        public IActionResult Cat()
        {
            string filePath = Path.Combine(_contentRootPath, "Files", "Cat.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }
        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Iphone",
                    Price = 1000
                }
                );
        }
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url);
        }
        public IActionResult Google()
        {
            var url = Url.Action("https://Google.com");
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url);
        }
        public IActionResult HelloView(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                userName = "Khach";

            //return View("/MyViews/xinchao1.cshtml", userName);
            //return View("xinchao2", userName);

            return View((object)userName);
        }
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(x => x.Id == id).FirstOrDefault();

            if (product == null)
            {
                TempData["thongbao"] = "San pham khong tim thay";
                return Redirect(Url.Action("Index", "Home"));
            }

            //Model
            //return View(product);

            //View Data
            this.ViewData["product"] = product;
            ViewData["Title"] = product;

            return View("ViewProduct2");
        }
    }
}
