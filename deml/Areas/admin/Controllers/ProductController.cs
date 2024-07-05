using deml.DataAccess.Repository.IRepository;
using deml.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace demlWEB.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _Product;

        private readonly ICategoryRepository _category;

        public ProductController(IProductRepository db, ICategoryRepository category)
        {
            _Product = db;
            _category = category;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _Product.Add(obj);
                _Product.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "No such product";
                return RedirectToAction("Index");
            }

            Product? productFromDb = _Product.Get(u => u.ProductId == id);

            if (productFromDb == null)
            {
                TempData["error"] = "No such product";
                return RedirectToAction("Index");
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _Product.Update(obj);
                _Product.Save();
                TempData["success"] = "Product edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "No such product";
                return RedirectToAction("Index");
            }

            Product? productFromDb = _Product.Get(u => u.ProductId == id);

            if (productFromDb == null)
            {
                TempData["error"] = "No such product";
                return RedirectToAction("Index");
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Product? obj = _Product.Get(u => u.ProductId == id);
            if (obj == null)
            {
                TempData["error"] = "No such product";
                return RedirectToAction("Index");
            }

            _Product.Remove(obj);
            _Product.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
