using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.DAL
{
    public class ProductsDAL : IProductRepository
    {
        private MyAppDbContext _db;
        public ProductsDAL(MyAppDbContext _dbContext)
        {
            _db = _dbContext;

        }


        public List<Products> ProductsList()
        {
            var allProducts = _db.Products.ToList();
            return allProducts;
        }
        public ProductsVM GetProductById(int Id)
        {
            try
            {
                var product = _db.Products
                    .Where(x => x.Id == Id)
                    .Select(x => new ProductsVM
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        SubCategoryId=x.SubCategoryId,
                        Clour = x.Clour,
                        Size = x.Size
                    })
                    .FirstOrDefault();

                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SaveProduct(ProductsVM obj)
        {
            try
            {
                var product = new Products();
                product.ProductName = obj.ProductName;
                product.SubCategoryId = obj.SubCategoryId;

                product.Clour = obj.Clour;
                product.Size = obj.Size;
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateProduct(ProductsVM obj)
        {
            try
            {
                var product = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
                if (product == null)
                {
                    throw new Exception("Category not found.");
                }
                product.ProductName = obj.ProductName;
                product.SubCategoryId = obj.SubCategoryId;
                product.Clour = obj.Clour;
                product.Size = obj.Size;
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public List<SubCategory> SubCategoryList()
        {
            var allCategory = _db.SubCategories.ToList();
            return allCategory;
        }
    }
}
