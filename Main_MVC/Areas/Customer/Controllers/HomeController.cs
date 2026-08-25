using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.Repository.IRepository;
using MVC.Models.Models;

namespace First_MVC.Controllers;


[Area("Customer")]
public class HomeController : Controller
{
    private readonly IUnitOfWork _Repo;

    public HomeController(IUnitOfWork db)
    {
        _Repo = db;
    }
    public IActionResult Index(int id)
    {
        IEnumerable<Product> productList = _Repo.product.GetAll(includeProp: "Category").ToList();
        return View(productList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Details(int productId)
    {
        Product product = _Repo.product.GetValue(product => product.Id == productId, includeProp: "Category");
        return View(product);
    }

}
