using TestProject.Models;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.DAL
{
    public class SubCategoryDAL: ISubCategoryRepository
    {
        private MyAppDbContext _db;
        public SubCategoryDAL(MyAppDbContext _dbContext)
        {
            _db = _dbContext;

        }
        public List<Category> CategoryList()
        {
            var allCategory = _db.Categories.ToList();
            return allCategory;
        }
        public SubCategoryVM GetSubCategoryById(int Id)
        {
            try
            {
                var category = _db.SubCategories
                    .Where(x => x.Id == Id)
                    .Select(x => new SubCategoryVM
                    {
                        Id = x.Id,
                        SubCategoryName = x.SubCategoryName,
                        CategoryId=x.CategoryId
                    })
                    .FirstOrDefault();

                return category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public  async Task SaveSubSubCategory(SubCategoryVM obj)
        {
            try
            {
                var category = new SubCategory();
                category.CategoryId = obj.CategoryId;
                category.SubCategoryName = obj.SubCategoryName;

                _db.SubCategories.Add(category);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

      

        public List<SubCategoryVM> SubSubCategoryList()
        {
            var allCategory = _db.SubCategories.Select(x=> new SubCategoryVM
            {
                Id=x.Id,
                CategoryId=x.CategoryId,
                SubCategoryName=x.SubCategoryName
            }).ToList();
            return allCategory;
        }

        public  async Task UpdateSubCategory(SubCategoryVM obj)
        {
            try
            {
                var subCategory = _db.SubCategories.FirstOrDefault(x => x.Id == obj.Id);
                if (subCategory == null)
                {
                    throw new Exception("Category not found.");
                }
                subCategory.CategoryId = obj.CategoryId;
                subCategory.SubCategoryName = obj.SubCategoryName;
                _db.SubCategories.Update(subCategory);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
