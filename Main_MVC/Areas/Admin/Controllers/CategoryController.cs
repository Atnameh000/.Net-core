
using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.Data;
using MVC.DataAccess.Repository.IRepository;

namespace First_MVC.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _Repo;
        public CategoryController(IUnitOfWork db)
        {
            _Repo = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _Repo.category.GetAll().ToList();
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
                // _db.Categories.Add(obj);
                // _db.SaveChanges();
                _Repo.category.Add(obj);
                _Repo.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            // List<Category> objCategoryList = _db.Categories.ToList();
            // return View("Index", objCategoryList);
            return View();
        }

        public IActionResult Delete(int id)
        {
            Category? data = _Repo.category.GetValue(obj => obj.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            // _db.Categories.Remove(obj);
            // _db.SaveChanges();
            _Repo.category.Remove(obj);
            _Repo.Save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            Category? data = _Repo.category.GetValue(obj => obj.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // _db.Categories.Update(obj);
                // _db.SaveChanges();
                _Repo.category.Update(obj);
                _Repo.Save();
                TempData["success"] = "Category Edited successfully";
                return RedirectToAction("Index");
            }

            return View();
        }


        //Region Api calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = _Repo.category.GetAll().ToList();
            return Json(new { data = categories });
        }

        //End region

    }
}