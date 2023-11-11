using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILanguageService _languageService;
        private readonly ICart _cart;

        public ProductController(IProductService productService, ILanguageService languageService, ICart pCart)
        {
            _cart = pCart;
            _productService = productService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetAllProducts();
            _productService.UpdateProductQuantities(_cart as Cart);
            return View(products);
        }
    }
}