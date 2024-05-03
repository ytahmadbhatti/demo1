using TestProject.Models;
using TestProject.ViewModel;
namespace TestProject.Repository
{
    public interface IProductRepository
    {
        List<Products> ProductsList();
        List<SubCategory> SubCategoryList();

        Task SaveProduct(ProductsVM obj);
        Task UpdateProduct(ProductsVM obj);
        ProductsVM GetProductById(int Id);
    }
}
