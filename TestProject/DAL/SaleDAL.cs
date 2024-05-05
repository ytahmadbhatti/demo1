using TestProject.Models;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.DAL
{
    public class SaleDAL:ISaleRepository
    {
        private MyAppDbContext _db;
        public SaleDAL(MyAppDbContext _dbContext)
        {
            _db = _dbContext;

        }
        public List<Category> CategoryList()
        {
            var allCategory = _db.Categories.ToList();
            return allCategory;
        }

        public List<ProductsVM> GetProductAgaintSubCategoryId(int subCategoryId)
        {
            try
            {
                var subCategory = _db.Products
                    .Where(x => x.SubCategoryId == subCategoryId)
                    .Select(x => new ProductsVM
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        Clour = x.Clour,
                        Size=x.Size
                    })
                    .ToList();

                return subCategory;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<SubCategoryVM> GetSubSubCategoryListByCategoryId(int CategoryId)
        {
            try
            {
                var subCategory = _db.SubCategories
                    .Where(x => x.CategoryId == CategoryId)
                    .Select(x => new SubCategoryVM
                    {
                        Id = x.Id,
                        SubCategoryName = x.SubCategoryName,
                        CategoryId = x.CategoryId
                    })
                    .ToList();

                return subCategory;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
