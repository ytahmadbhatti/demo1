using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using TestProject.ViewModel;

namespace TestProject.Repository
{
    public interface ICategoryRepository
    {
        List<Category> CategoryList();
        Task SaveCategory(CategoryVM obj);
        Task UpdateCategory(CategoryVM obj);
       CategoryVM GetCategoryById(int Id);
    }
}
