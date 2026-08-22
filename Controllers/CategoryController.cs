using First_MVC.Data;
using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
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
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            // List<Category> objCategoryList = _db.Categories.ToList();
            // return View("Index", objCategoryList);
            return View();
        }

        public IActionResult Delete(int id)
        {
            Category? data = _db.Categories.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            Category? data = _db.Categories.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



    }
}