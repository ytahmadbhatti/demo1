using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.DAL
{
    public class CategoryDAL : ICategoryRepository
    {
        private MyAppDbContext _db;
        public CategoryDAL(MyAppDbContext _dbContext)
        {
            _db = _dbContext;

        }
        public List<Category> CategoryList()
        {
            var allCategory = _db.Categories.ToList();
            return allCategory;
        }

        public CategoryVM GetCategoryById(int Id)
        {
            try
            {
                var category =  _db.Categories
                    .Where(x => x.Id == Id)
                    .Select(x => new CategoryVM
                    {
                        Id = x.Id,
                        CategoryName = x.CategoryName
                    })
                    .FirstOrDefault();

                return category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SaveCategory(CategoryVM obj)
        {
            try
            {
                var category = new Category();
                category.CategoryName = obj.CategoryName;
                 _db.Categories.Add(category);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;           
            }
        }

        public async Task UpdateCategory(CategoryVM obj)
        {
            try
            {
                var category =  _db.Categories.FirstOrDefault(x => x.Id == obj.Id);
                if (category == null)
                {
                    throw new Exception( "Category not found." );
                }
                category.CategoryName = obj.CategoryName;
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
