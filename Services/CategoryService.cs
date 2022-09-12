using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;
        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateCatgory(Category category)
        {
            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();
        }
        public void UpdateCatgory(Category category)
        {
            var existedCategory = GetCategoryById(category.Id);
            if (existedCategory == null) return ;
            existedCategory.Name =  category.Name;
            _dataContext.Categories.Update(existedCategory);
            _dataContext.SaveChanges();
        }

        public void DeleteCatgory(int id)
        {
            var existedCategory = GetCategoryById(id);
            if (existedCategory == null) return ;
            _dataContext.Categories.Remove(existedCategory);
            _dataContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _dataContext.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _dataContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        
    }
}