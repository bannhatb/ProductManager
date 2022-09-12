//ef-db-context: gợi ý

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category? GetCategoryById(int id);

        void CreateCatgory(Category category);
        void UpdateCatgory(Category category);
        void DeleteCatgory(int id);
    }
}