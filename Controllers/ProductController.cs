using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.ProductManage.Services;
using MVC.Services;

namespace MVC.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var product = _productService.OrderBy(p => p.Name).ToList();
            return View(product);
        }
    }
}