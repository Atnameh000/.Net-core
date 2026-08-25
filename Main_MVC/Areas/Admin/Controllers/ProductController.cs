using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders;
using MVC.DataAccess.Repository.IRepository;
using MVC.Models.Models;

namespace Main_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _Repo;
        private readonly IWebHostEnvironment _WebHostEnviroment;

        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _Repo = db;
            _WebHostEnviroment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> products = _Repo.product.GetAll(includeProp: "Category").ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _Repo.category
            .GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CategoryList = CategoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _WebHostEnviroment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images/Product");

                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    obj.ImageUrl = @"/Images/Product/" + filename;
                }
                _Repo.product.Add(obj);
                _Repo.Save();
                TempData["success"] = "Product Created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> CategoryList = _Repo.category
            .GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            Product obj = _Repo.product.GetValue(obj => obj.Id == id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Product obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _WebHostEnviroment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images/Product");

                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldPhotoPath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldPhotoPath))
                        {
                            System.IO.File.Delete(oldPhotoPath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    obj.ImageUrl = @"/Images/Product/" + filename;
                }
                _Repo.product.Update(obj);
                _Repo.Save();
                TempData["success"] = "Product Updated successfully";
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
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");

        }


        //Region Api calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _Repo.product.GetAll(includeProp: "Category").ToList();
            return Json(new { data = products });
        }

        //End region

    }
}