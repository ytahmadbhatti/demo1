using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string? SubCategoryName { get; set; }

    }
}
