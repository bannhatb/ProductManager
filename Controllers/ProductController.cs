using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService
        )
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index() 
        {
            var products = _productService.GetProducts();
            ViewBag.categories = _categoryService;
            return View(products);
        }

        public IActionResult Create()
        {
            List<Category> categories = _categoryService.GetCategories();
            return View(categories);
        }
        public IActionResult Update(int id) 
        {
            Product? product = _productService.GetProductById(id);
            ViewBag.Categories = _categoryService.GetCategories();
            return View(product);
        }

        public IActionResult Save(Product product) 
        {
            var existedProduct = _productService.GetProductById(product.Id);
            if(existedProduct == null)
            {
                _productService.CreateProduct(product);
            }
            else
            {
                _productService.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}