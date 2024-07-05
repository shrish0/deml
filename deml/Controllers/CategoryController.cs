using deml.Data;
using deml.Models;
using Microsoft.AspNetCore.Mvc;

namespace deml.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
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
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id==0 ) { 
                return NotFound();
            }
            //only for primary key
            Category? categoryFromDb1 = _db.Categories.Find(id);

            //for ANY KEY
            //Category categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //for list and then filtering
            //Category categoryFromDb3 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();

            if (categoryFromDb1 == null )
            {
                return NotFound();
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
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edit successfully";
                return RedirectToAction("Index");
            }
           
            return View();
        }

        public IActionResult Delete(int? id)
        {
            
            //only for primary key
            Category? categoryFromDb1 = _db.Categories.Find(id);

            //for ANY KEY
            //Category categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //for list and then filtering
            //Category categoryFromDb3 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();

            if (categoryFromDb1 == null)
            {
                return NotFound();
            }
            return View(categoryFromDb1);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
     
            Category? obj = _db.Categories.Find(id);
            if (obj == null) {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Deletes successfully";
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
