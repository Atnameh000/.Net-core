using Azure;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.Repository.IRepository;
using MVC.Models.Models;

namespace Main_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _Repo;

        public ProductController(IUnitOfWork db)
        {
            _Repo = db;
        }
        public IActionResult Index()
        {
            List<Product> products = _Repo.product.GetAll().ToList();
            return View(products);
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
                _Repo.product.Add(obj);
                _Repo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Product obj = _Repo.product.GetValue(obj => obj.Id == id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _Repo.product.Update(obj);
                _Repo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Product obj = _Repo.product.GetValue(obj => obj.Id == id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Product obj)
        {
            _Repo.product.Remove(obj);
            _Repo.Save();
            return RedirectToAction("Index");

        }
    }
}