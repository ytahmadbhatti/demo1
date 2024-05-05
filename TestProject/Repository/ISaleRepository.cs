using TestProject.Models;
using TestProject.ViewModel;

namespace TestProject.Repository
{
    public interface ISaleRepository
    {
        List<Category> CategoryList();
        List<SubCategoryVM> GetSubSubCategoryListByCategoryId(int CategoryId);

        List<ProductsVM> GetProductAgaintSubCategoryId(int subCategoryId);

    }
}
