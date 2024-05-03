using System.ComponentModel.DataAnnotations;

namespace TestProject.ViewModel
{
    public class ProductsVM
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }

        public string? ProductName { get; set; }

        public string? Clour { get; set; }
        public string? Size { get; set; }
    }
}
