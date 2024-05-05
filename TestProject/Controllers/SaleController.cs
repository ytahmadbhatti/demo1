using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestProject.Models;
using TestProject.Repository;

namespace TestProject.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository _saleRepo;
        public SaleController(ISaleRepository _SaleRepo)
        {
            _saleRepo = _SaleRepo;
        }
        public IActionResult ViewRecord()
        {
            //List<Category> listCategory = _saleRepo.CategoryList();
            //ViewData["GetAllCategory"] = listCategory;
            return View();
        }

        [HttpGet]
        public IActionResult GetCategoryList()
        {
            try
            {
                var catList = _saleRepo.CategoryList();
                return Json(new { success=true, catList });
            }
            catch (Exception)
            {
                return Json(new { success = false });

            }
        }

        public IActionResult GetSubSubCategoryListByCategoryId(int SubcategoryId)
        {
            try
            {
                try
                {
                    var subCategoryList = _saleRepo.GetSubSubCategoryListByCategoryId(SubcategoryId);
                    return Json(new { success = true, subCategoryList });
                }
                catch (Exception)
                {
                    return Json(new { success = false });

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult GetProductAgaintSubCategoryId(int SubcategoryId)
        {
            try
            {
                var productList = _saleRepo.GetProductAgaintSubCategoryId(SubcategoryId);
                return Json(new { success = true, productList });
            }
            catch (Exception)
            {
                return Json(new { success = false });

            }
        }
    }
}
