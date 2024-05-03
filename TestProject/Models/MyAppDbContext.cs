using Microsoft.EntityFrameworkCore;


namespace TestProject.Models
{
    public class MyAppDbContext :DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}
