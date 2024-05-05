using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProject.Models;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.Controllers
{
    public class SubCategoryController : Controller
    {
        private ISubCategoryRepository _subcategory;
        public SubCategoryController(ISubCategoryRepository _Subcategory)
        {
            _subcategory = _Subcategory;
        }
        public IActionResult Index()
        {
            try
            {
                var catList = _subcategory.SubSubCategoryList();
                return View(catList);
            }
            catch (Exception )
            {
                return View();

            }
        }

        public IActionResult GetAllSubCategory()
        {
            try
            {
                var catList = _subcategory.SubSubCategoryList();
                return Json(catList);
            }
            catch (Exception)
            {
                return View();

            }
        }


        public IActionResult Create()
        {
            var catList = _subcategory.CategoryList();
            ViewBag.category = new SelectList(catList, "Id", "CategoryName"); // "Id" is the value field, "Name" is the display field
            return View();
        }

        public IActionResult Edit(int Id)   
        {
            var catList = _subcategory.CategoryList();
            ViewBag.category = new SelectList(catList, "Id", "CategoryName");
            ViewBag.SubCategory = Id;
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> SaveSubCategory(SubCategoryVM obj)
        {
            try
            {
                var success = _subcategory.SaveSubSubCategory(obj);
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
                var catrecord = _subcategory.GetSubCategoryById(id);
                return Json(new { success = true, catrecord });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory(SubCategoryVM obj)
        {
            try
            {
                var success = _subcategory.UpdateSubCategory(obj);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }

        }
    }
}
