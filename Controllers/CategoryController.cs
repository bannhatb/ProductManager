using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index() 
        {
            List<Category> categories = _categoryService.GetCategories();
            return View(categories);
        }

        public IActionResult Create(Category category) 
        {
            List<Category> categories = _categoryService.GetCategories();
            return View(categories);
        }
        public IActionResult Update(int id)
        {
            Category? category = _categoryService.GetCategoryById(id);
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCatgory(id);
            return RedirectToAction("Index");
        }
        public IActionResult SaveCategory(Category category)
        {
            var existedCategory = _categoryService.GetCategoryById(category.Id);
            if(existedCategory == null) 
            {
                _categoryService.CreateCatgory(category);
            }
            else
            {
                _categoryService.UpdateCatgory(category);
            }
            return RedirectToAction("Index");
        }
    }
}