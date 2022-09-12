using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       

        public Product? GetProductById(int id)
        {
            return _dataContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _dataContext.Products.ToList();
        }

        public void CreateProduct(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existedProduct = GetProductById(product.Id);
            if(existedProduct == null) return;
            existedProduct.Name = product.Name;
            existedProduct.Price = product.Price;
            existedProduct.Slug = product.Slug;
            existedProduct.CategoryId = product.CategoryId;
            existedProduct.Quantity = product.Quantity;
            _dataContext.Products.Update(existedProduct);
            _dataContext.SaveChanges();
        }
        

        public void DeleteProduct(int Id)
        {
            var existedProduct = GetProductById(Id);
            if(existedProduct == null) return;
            _dataContext.Products.Remove(existedProduct);
            _dataContext.SaveChanges();
        }

    }
}