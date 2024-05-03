using Microsoft.AspNetCore.Mvc;
using TestProject.Repository;
using TestProject.ViewModel;

namespace TestProject.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _catgory;
        public CategoryController(ICategoryRepository _Catgory)
        {
            _catgory = _Catgory;
        }
        public IActionResult Index()
        {
            try
            {
                
                var catList = _catgory.CategoryList();
                return View(catList);
            }
            catch (Exception)
            {
                return View();

            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int Id)   //ID to Id by Ahmad
        {
            ViewBag.id = Id;
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryVM obj)
        {
            try
            {
                var success = _catgory.SaveCategory(obj);
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
                var catrecord = _catgory.GetCategoryById(id);
                return Json(new { success = true, catrecord });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryVM obj)
        {
            try
            {
                var success = _catgory.UpdateCategory(obj);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = true, response = ex.Message });
            }

        }
    }
}
