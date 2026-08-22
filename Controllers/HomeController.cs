using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using First_MVC.Models;
using Microsoft.VisualBasic;

namespace First_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(int id)
    {
        string viewName = "Product";
        return (id == 4) ? View(viewName) : View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Product()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
