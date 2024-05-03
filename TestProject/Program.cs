using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestProject.DAL;
using TestProject.Models;
using TestProject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configure Autofac as the DI container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        // Register types with Autofac
        containerBuilder.RegisterType<CategoryDAL>().As<ICategoryRepository>().SingleInstance();
        containerBuilder.RegisterType<ProductsDAL>().As<IProductRepository>().SingleInstance();
        containerBuilder.RegisterType<SubCategoryDAL>().As<ISubCategoryRepository>().SingleInstance();

    });

// Add services to the DI container
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddControllersWithViews();

// Build the app and configure the middleware pipeline
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}





app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
