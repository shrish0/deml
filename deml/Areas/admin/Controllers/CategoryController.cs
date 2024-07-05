

using deml.Models;
using Microsoft.AspNetCore.Mvc;
using deml.DataAccess.Repository.IRepository;

namespace demlWEB.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.DisplayOrder.ToString() == obj.name)
            {
                ModelState.AddModelError("name", "name and display order can't be same");
            }
            if (obj.name.ToLower() == "test")
            {
                ModelState.AddModelError("", "not a valid name");
            }
            if (ModelState.IsValid)
            {
                _category.Add(obj);
                _category.Save();
                TempData["success"] = "created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "no such category";
                return RedirectToAction("Index");
            }
            //only for primary key
            Category? categoryFromDb1 = _category.Get(u => u.CategoryId == id);

            //for ANY KEY
            //Category categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //for list and then filtering
            //Category categoryFromDb3 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();

            if (categoryFromDb1 == null)
            {
                TempData["error"] = "no such category";
                return RedirectToAction("Index");

            }
            return View(categoryFromDb1);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.name.ToLower() == "test")
            {
                ModelState.AddModelError("", "not a valid name");
            }
            if (ModelState.IsValid)
            {
                _category.Update(obj);
                _category.Save();
                TempData["success"] = "Edit successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {

            //only for primary key
            Category? categoryFromDb1 = _category.Get(u => u.CategoryId == id);

            //for ANY KEY
            //Category categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //for list and then filtering
            //Category categoryFromDb3 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();

            if (categoryFromDb1 == null)
            {
                TempData["error"] = "no such category";
                return RedirectToAction("Index");
            }
            return View(categoryFromDb1);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {

            Category? obj = _category.Get(u => u.CategoryId == id);
            if (obj == null)
            {
                TempData["error"] = "no such category";
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                _category.Remove(obj);
                _category.Save();
                TempData["success"] = "Deletes successfully";
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
