using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProject.Models;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _product;
        public ProductController(IProductRepository _Product)
        {
            _product = _Product;
        }
        public IActionResult Index()
        {
            try
            {
                var productList = _product.ProductsList();                
                    return View(productList);
           
            }
            catch (Exception )
            {
                return View();

            }
        }

        public IActionResult GetAllProducts()  //CRETED BY AHMAD
        {
            try
            {
                var productList = _product.ProductsList();
                return Json(productList);
            }
            catch (Exception)
            {
                return View();

            }
        }
        public IActionResult Create()
        {
            var catList = _product.SubCategoryList();
            ViewBag.category = new SelectList(catList, "Id", "SubCategoryName");
            return View();
        }

        public IActionResult Edit(int Id)   
        {
            var catList = _product.SubCategoryList();
            ViewBag.category = new SelectList(catList, "Id", "SubCategoryName");
            ViewBag.id = Id;
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductsVM obj)
        {
            try
            {
                var success = _product.SaveProduct(obj);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }

        }
        [HttpGet]
        public JsonResult GetRecord(int id)
        {
            try
            {
                var catrecord = _product.GetProductById(id);
                return Json(new { success = true, catrecord });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductsVM obj)
        {
            try
            {
                var success =  _product.UpdateProduct(obj);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }

        }
    }
}
