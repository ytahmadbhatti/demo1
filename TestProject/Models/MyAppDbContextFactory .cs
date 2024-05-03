using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public class MyAppDbContextFactory : IDesignTimeDbContextFactory<MyAppDbContext>
    {
        public MyAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyAppDbContext>();
            optionsBuilder.UseSqlServer("Server=AHMAD-BHATTI;Database=DynamicNavigationSystemDBNew;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MyAppDbContext(optionsBuilder.Options);
        }
    }

}
