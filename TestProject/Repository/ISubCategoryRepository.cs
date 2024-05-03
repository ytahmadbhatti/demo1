using TestProject.Models;
using TestProject.ViewModel;

namespace TestProject.Repository
{
    public interface ISubCategoryRepository
    {
        List<Category> CategoryList();

        List<SubCategoryVM> SubSubCategoryList();
        Task SaveSubSubCategory(SubCategoryVM obj);
        Task UpdateSubCategory(SubCategoryVM obj);
        SubCategoryVM GetSubCategoryById(int Id);

    }
}
